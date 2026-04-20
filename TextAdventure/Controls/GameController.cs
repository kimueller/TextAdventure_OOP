using System;
using TextAdventure.Interfaces;
using TextAdventure.Items;
using TextAdventure.NPCs;
using TextAdventure.Players;
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

        /// <summary>
        /// Gibt den momentanen Raum und die möglichen Aktionen aus. 
        /// Wird vor jeder Eingabeaufforderung aufgerufen.
        /// </summary>
        public void PrintPrompt()
        {
            Console.Write($"\n{_player.CurrentRoom.Name}: ");
            HelperFunctions.WriteColour("[U]mschauen ", ConsoleColor.Cyan);
            HelperFunctions.WriteColour("[S]prich ", ConsoleColor.Yellow);
            HelperFunctions.WriteColour("[G]ehe ", ConsoleColor.Green);
            HelperFunctions.WriteColour("[N]utze", ConsoleColor.Magenta);
            Console.WriteLine();
            Console.Write("> ");
        }

        /// <summary>
        /// Checkt den input --> wenn er korrekt ist, führe die Aktion aus
        /// </summary>
        /// <param name="input">Gewünschte Aktion</param>
        public void HandleInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            string[] parts = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string cmd = parts[0].ToUpper();

            if (cmd == "U" || cmd == "UMSCHAUEN")
            {
                LookAround();
            }
            else if (cmd == "S" || cmd == "SPRICH")
            {
                string target = parts.Length > 1 ? parts[1] : "";
                Talk(target);
            }
            else if (cmd == "G" || cmd == "GEHE")
            {
                string dir = parts.Length > 1 ? parts[1].ToUpper() : "";
                Go(dir);
            }
            else if (cmd == "N" || cmd == "NUTZE")
            {
                string target = parts.Length > 1 ? parts[1] : "";
                Use(target);
            }
            else
            {
                HelperFunctions.WriteLineColour("Unbekannter Befehl. Verfügbare Befehle: [U]mschauen [S]prich [G]ehe [N]utze", ConsoleColor.DarkGray);
            }

        }

        /// <summary>
        /// Kontrolliert, ob die Antowrt für das Rekursionsquiz richtig ist
        /// </summary>
        /// <param name="recursionRoom">den Recursionsraum für die Properties</param>
        public void CheckRecursiveQuizAnswer(RecursionRoom recursionRoom)
        {
            // solange das Rätsel noch nicht gelöst ist, fragt er nach der Antwort seines Rätsels
            while (!recursionRoom.Solved)
            {
                Console.Write("Deine Antwort: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (recursionRoom.ReactToAnswer(input))
                {
                    HelperFunctions.WriteLineColour("Richtig! Du hast das Rätsel gelöst.", ConsoleColor.Green);
                }
                else
                {
                    HelperFunctions.WriteLineColour("Falsch. Versuche es erneut.", ConsoleColor.Red);
                }
            }
        }



        // Aktionen

        /// <summary>
        /// Schaut sich im raum umher und gibt NPCs/Items im raum an, oder wenn das Licht aus ist dass man nichts sieht
        /// </summary>
        private void LookAround()
        {
            Room r = _player.CurrentRoom;
            if (!r.IsLightOn)
            {
                HelperFunctions.WriteLineColour($"Es ist dunkel in {r.Name} und Du siehst nichts.", ConsoleColor.DarkGray);
                return;
            }

            HelperFunctions.WriteLineColour($"Du schaust Dich in {r.Name} um.", ConsoleColor.White);

            // Himmelsrichtungen
            Console.WriteLine("Himmelsrichtungen: [N]orden, [S]üden, [W]esten, [O]sten");

            // NPCs
            Console.WriteLine("Es sind folgende Personen anwesend:");
            if (r.NPCs.Count == 0)
            {
                HelperFunctions.WriteLineColour(" Keine Personen im Raum.", ConsoleColor.DarkGray);
            }
            else
            {
                foreach (NPC npc in r.NPCs)
                {
                    HelperFunctions.WriteLineColour($" [{npc.Name[0]}] {npc.Name}", ConsoleColor.Yellow);
                }
            }

            // Items
            Console.WriteLine("Du siehst im Raum:");
            if (r.Items.Count == 0)
                HelperFunctions.WriteLineColour(" Keine Gegenstände im Raum.", ConsoleColor.DarkGray);
            else
                for (int i = 0; i < r.Items.Count; i++)
                {
                    HelperFunctions.WriteColour($" [{i + 1}] {r.Items[i].Name}", ConsoleColor.Magenta);
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

        /// <summary>
        /// Rede mit einem NPC/Item
        /// </summary>
        /// <param name="target">NPC/Items mit dem man reden will</param>
        private void Talk(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                HelperFunctions.WriteLineColour("Mit wem oder was möchtest Du sprechen?", ConsoleColor.DarkGray);
                return;
            }

            Room r = _player.CurrentRoom;

            // Erst NPCs durchsuchen
            foreach (NPC npc in r.NPCs)
            {
                if (HelperFunctions.MatchesTarget(npc.Name, target))
                {
                    HelperFunctions.PrintLines(npc.Talk(), ConsoleColor.Yellow);
                    if (r is RecursionRoom recursionRoom && npc is LordRecursivus)
                    {
                        CheckRecursiveQuizAnswer(recursionRoom);
                    }
                    return;
                }
            }

            if (!r.IsLightOn)
            {
                HelperFunctions.WriteLineColour("Es ist zu dunkel um irgendjemanden oder etwas zu sehen.", ConsoleColor.DarkGray);
                return;
            }
            for (int i = 0; i < r.Items.Count; i++)
            {
                bool matchIndex = target == (i + 1).ToString();
                bool matchName = HelperFunctions.MatchesTarget(r.Items[i].Name, target);
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
                                HelperFunctions.WriteLineColour(line, ConsoleColor.Cyan);

                        if (win) _gameRunning = HelperFunctions.StopGame();
                        return;
                    }
                    else
                    {
                        HelperFunctions.WriteLineColour($"Mit {r.Items[i].Name} kann man nicht sprechen.", ConsoleColor.DarkGray);
                        return;
                    }
                }
            }

            HelperFunctions.WriteLineColour($"'{target}' ist hier nicht zu finden.", ConsoleColor.DarkGray);
        }

        /// <summary>
        /// Gehe in diese Richtung
        /// </summary>
        /// <param name="direction">Richtung in der man gehen soll(Himmelsrichtungen)</param>
        private void Go(string direction)
        {
            Room r = _player.CurrentRoom;
            if (r is RecursionRoom room && room.Solved == false)
            {
                HelperFunctions.WriteLineColour(
                    $"Du kannst den {r.Name} nicht verlassen!\n" +
                    $"Lord Recursivus hat dicg in seiner Rekursion gefangen!\n" +
                    $"Löse sein Rätsel um aus dem Raum zu entkommen! (Rede mit ihm.)",
                    ConsoleColor.Red);

            }
            Room next = null;
            string dirName = "";

            //switch case für die Bestimmung der Richtung
            switch (direction)
            {
                case "N":
                case "NORDEN":
                case "NORD":
                    next = r.North;
                    dirName = "Norden";
                    break;
                case "S":
                case "SUEDEN":
                case "SÜDEN":
                    next = r.South;
                    dirName = "Süden";
                    break;
                case "W":
                case "WESTEN":
                case "WEST":
                    next = r.West;
                    dirName = "Westen";
                    break;
                case "O":
                case "OSTEN":
                case "OST":
                    next = r.East;
                    dirName = "Osten";
                    break;
                default:
                    HelperFunctions.WriteLineColour("Unbekannte Richtung. Benutze N, S, W oder O.", ConsoleColor.DarkGray);
                    return;
            }

            //Wenn in dieser Richtung kein Raum ist, gebe eine Meldung aus
            if (next == null)
            {
                HelperFunctions.WriteLineColour($"Du versuchst nach {dirName} zu gehen - Du läufst mit voller Wucht gegen eine verschlossene Türe. Autsch!", ConsoleColor.Red);
                return;
            }

            _player.LastDirection = dirName;
            _player.CurrentRoom = next;
            string[] enterLines = next.Enter(_player);
            foreach (string line in enterLines)
                HelperFunctions.WriteLineColour(line, ConsoleColor.DarkGray);
        }

        /// <summary>
        /// Interagiere mit einem Item
        /// </summary>
        /// <param name="target">Item mit dem man interargieren will</param>
        private void Use(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                HelperFunctions.WriteLineColour("Was möchtest Du benutzen?", ConsoleColor.DarkGray);
                return;
            }

            Room r = _player.CurrentRoom;

            if (!r.IsLightOn)
            {
                // Lichtschalter koennen auch im Dunkeln gefunden werden (durch Checken mit der Use-Methode)
                foreach (Item item in r.Items)
                    if (item is LightSwitch)
                    {
                        if (HelperFunctions.MatchesTarget(item.Name, target) || target == (r.Items.IndexOf(item) + 1).ToString())
                        {
                            HelperFunctions.PrintLines(item.Use(r), ConsoleColor.Magenta);
                            return;
                        }
                    }
                HelperFunctions.WriteLineColour("Es ist zu dunkel um etwas zu benutzen.", ConsoleColor.DarkGray);
                return;
            }

            for (int i = 0; i < r.Items.Count; i++)
            {
                bool matchIndex = target == (i + 1).ToString();
                bool matchName = HelperFunctions.MatchesTarget(r.Items[i].Name, target);
                if (matchIndex || matchName)
                {
                    HelperFunctions.PrintLines(r.Items[i].Use(r), ConsoleColor.Magenta);
                    return;
                }
            }

            HelperFunctions.WriteLineColour($"'{target}' ist hier nicht zu finden.", ConsoleColor.DarkGray);
        }
    }
}
