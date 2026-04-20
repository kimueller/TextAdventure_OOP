using System;
using System.Collections.Generic;
using TextAdventure.Interfaces;
using TextAdventure.Items;
using TextAdventure.NPCs;
using TextAdventure.Rooms;

namespace TextAdventure.Controls
{
    // Loesung: GameController steuert den Spielablauf und parst Benutzereingaben
    // Konsoleausgaben sind auf Program.cs und GameController beschraenkt
    public class GameController
    {
        private Player _player;
        private bool _gameRunning;

        public GameController(Player player)
        {
            _player = player;
            _gameRunning = true;
        }

        public bool IsRunning => _gameRunning;

        // Gibt die Eingabeaufforderung fuer den aktuellen Raum aus
        public void PrintPrompt()
        {
            Console.Write($"\nRaum {_player.CurrentRoom.Name}: ");
            WriteColour("[U]mschauen ", ConsoleColor.Cyan);
            WriteColour("[S]prich ", ConsoleColor.Yellow);
            WriteColour("[G]ehe ", ConsoleColor.Green);
            WriteColour("[N]utze", ConsoleColor.Magenta);
            Console.WriteLine();
            Console.Write("> ");
        }

        // Verarbeitet eine Eingabezeile
        public void HandleInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            string[] parts = input.Trim().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            string cmd = parts[0].ToUpper();

            if (cmd == "U" || cmd == "UMSCHAUEN")
            {
                DoLookAround();
            }
            else if (cmd == "S" || cmd == "SPRICH")
            {
                string target = parts.Length > 1 ? parts[1] : "";
                DoTalk(target);
            }
            else if (cmd == "G" || cmd == "GEHE")
            {
                string dir = parts.Length > 1 ? parts[1].ToUpper() : "";
                DoGo(dir);
            }
            else if (cmd == "N" || cmd == "NUTZE")
            {
                string target = parts.Length > 1 ? parts[1] : "";
                DoUse(target);
            }
            else
            {
                WriteLineColour("Unbekannter Befehl. Verfügbare Befehle: [U]mschauen [S]prich [G]ehe [N]utze", ConsoleColor.DarkGray);
            }
        }

        // --- Aktionen ---

        private void DoLookAround()
        {
            Room r = _player.CurrentRoom;
            if (!r.IsLit)
            {
                WriteLineColour($"Es ist dunkel in {r.Name} und Du siehst nichts.", ConsoleColor.DarkGray);
                return;
            }

            WriteLineColour($"Du schaust Dich in {r.Name} um.", ConsoleColor.White);

            // Himmelsrichtungen
            Console.WriteLine("Himmelsrichtungen: [N]orden, [S]üden, [W]esten, [O]sten");

            // NPCs
            Console.WriteLine("Es sind folgende Personen anwesend:");
            if (r.NPCs.Count == 0)
                WriteLineColour(" Keine Personen im Raum.", ConsoleColor.DarkGray);
            else
                foreach (NPC npc in r.NPCs)
                    WriteLineColour($" [{npc.Name[0]}] {npc.Name}", ConsoleColor.Yellow);

            // Items
            Console.WriteLine("Du siehst im Raum:");
            if (r.Items.Count == 0)
                WriteLineColour(" Keine Gegenstände im Raum.", ConsoleColor.DarkGray);
            else
                for (int i = 0; i < r.Items.Count; i++)
                {
                    WriteColour($" [{i + 1}] {r.Items[i].Name}", ConsoleColor.Magenta);
                    if (r.Items[i].ContainedItems.Count > 0)
                    {
                        Console.Write(" (enthält: ");
                        for (int j = 0; j < r.Items[i].ContainedItems.Count; j++)
                        {
                            if (j > 0) Console.Write(", ");
                            Console.Write(r.Items[i].ContainedItems[j].Name);
                        }
                        Console.Write(")");
                    }
                    Console.WriteLine();
                }
        }

        private void DoTalk(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                WriteLineColour("Mit wem oder was möchtest Du sprechen?", ConsoleColor.DarkGray);
                return;
            }

            Room r = _player.CurrentRoom;

            // Erst NPCs durchsuchen
            foreach (NPC npc in r.NPCs)
            {
                if (MatchesTarget(npc.Name, target))
                {
                    PrintLines(npc.Talk(), ConsoleColor.Yellow);
                    return;
                }
            }

            // Dann sprechbare Items
            if (!r.IsLit)
            {
                WriteLineColour("Es ist zu dunkel um irgendjemanden oder etwas zu sehen.", ConsoleColor.DarkGray);
                return;
            }
            for (int i = 0; i < r.Items.Count; i++)
            {
                bool matchIndex = target == (i + 1).ToString();
                bool matchName  = MatchesTarget(r.Items[i].Name, target);
                if (matchIndex || matchName)
                {
                    if (r.Items[i] is ITalkable talkable)
                    {
                        string[] lines = talkable.Talk();
                        // Pruefen ob Gewinn-Token enthalten
                        bool win = false;
                        foreach (string line in lines)
                            if (line == "GAME_WIN") win = true;

                        foreach (string line in lines)
                            if (line != "GAME_WIN")
                                WriteLineColour(line, ConsoleColor.Cyan);

                        if (win) TriggerWin();
                        return;
                    }
                    else
                    {
                        WriteLineColour($"Mit {r.Items[i].Name} kann man nicht sprechen.", ConsoleColor.DarkGray);
                        return;
                    }
                }
            }

            WriteLineColour($"'{target}' ist hier nicht zu finden.", ConsoleColor.DarkGray);
        }

        private void DoGo(string direction)
        {
            Room r = _player.CurrentRoom;
            Room next = null;
            string dirName = "";

            switch (direction)
            {
                case "N": case "NORDEN": case "NORD":
                    next = r.North; dirName = "Norden"; break;
                case "S": case "SUEDEN": case "SÜDEN":
                    next = r.South; dirName = "Süden"; break;
                case "W": case "WESTEN": case "WEST":
                    next = r.West; dirName = "Westen"; break;
                case "O": case "OSTEN": case "OST":
                    next = r.East; dirName = "Osten"; break;
                default:
                    WriteLineColour("Unbekannte Richtung. Benutze N, S, W oder O.", ConsoleColor.DarkGray);
                    return;
            }

            if (next == null)
            {
                WriteLineColour($"Du versuchst nach {dirName} zu gehen - Du läufst mit voller Wucht gegen eine verschlossene Türe. Autsch!", ConsoleColor.Red);
                return;
            }

            _player.LastDirection = dirName;
            _player.CurrentRoom = next;
            string[] enterLines = next.Enter(_player);
            foreach (string line in enterLines)
                WriteLineColour(line, ConsoleColor.Green);
        }

        private void DoUse(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                WriteLineColour("Was möchtest Du benutzen?", ConsoleColor.DarkGray);
                return;
            }

            Room r = _player.CurrentRoom;

            if (!r.IsLit)
            {
                // Lichtschalter koennen auch im Dunkeln gefunden werden (durch Ertasten)
                foreach (Item item in r.Items)
                    if (item is LightSwitch)
                    {
                        if (MatchesTarget(item.Name, target) || target == (r.Items.IndexOf(item)+1).ToString())
                        {
                            PrintLines(item.Use(r), ConsoleColor.Magenta);
                            return;
                        }
                    }
                WriteLineColour("Es ist zu dunkel um etwas zu benutzen.", ConsoleColor.DarkGray);
                return;
            }

            for (int i = 0; i < r.Items.Count; i++)
            {
                bool matchIndex = target == (i + 1).ToString();
                bool matchName  = MatchesTarget(r.Items[i].Name, target);
                if (matchIndex || matchName)
                {
                    PrintLines(r.Items[i].Use(r), ConsoleColor.Magenta);
                    return;
                }
            }

            WriteLineColour($"'{target}' ist hier nicht zu finden.", ConsoleColor.DarkGray);
        }

        // --- Hilfsmethoden ---

        private bool MatchesTarget(string name, string target)
        {
            // Erlaubt Abkuerzungen: erster Buchstabe oder vollstaendiger Name
            return name.StartsWith(target, StringComparison.OrdinalIgnoreCase)
                || name.Equals(target, StringComparison.OrdinalIgnoreCase);
        }

        private void TriggerWin()
        {
            Console.WriteLine();
            WriteLineColour("Game Over - vielen Dank für das Spielen von 'Quest for the Almighty Compiler'.", ConsoleColor.Cyan);
            _gameRunning = false;
        }

        private void PrintLines(string[] lines, ConsoleColor colour)
        {
            foreach (string line in lines)
                WriteLineColour(line, colour);
        }

        // --- Konsolen-Hilfsmethoden (analog zur Aufgabenstellung) ---
        public static void WriteColour(string text, ConsoleColor colour = ConsoleColor.White)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = old;
        }

        public static void WriteLineColour(string text, ConsoleColor colour = ConsoleColor.White)
        {
            WriteColour(text + Environment.NewLine, colour);
        }
    }
}
