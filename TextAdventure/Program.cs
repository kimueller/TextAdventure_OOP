using System;
using TextAdventure.Controls;
using TextAdventure.Rooms;
using TextAdventure.Players;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperFunctions.WriteLineColour(
                "In einem Universum aus Daten und Algorithmen schlummert eine uralte Macht:\n" +
                "der allmächtige Compiler 'AC 9000'. Legenden berichten von seinem\n" +
                "unendlichen Wissen und seiner Fähigkeit, jeden Code zu manipulieren,\n" +
                "jeden Datentyp zu casten und jede noch so komplexe Schleife in nur\n" +
                "einem einzigen Durchlauf zu bezwingen.\n\n" +

                "Manche behaupten sogar, der Compiler könne die Gedanken von\n" +
                "Programmierer:innen lesen – Fehler erkennen, bevor sie überhaupt\n" +
                "geschrieben wurden.\n\n" +

                "Du, Dave – ein:e mutige:r Programmierer:in – begibst dich auf die Suche\n" +
                "nach diesem sagenumwobenen Artefakt. Angetrieben von Neugier,\n" +
                "Ehrgeiz und dem Wunsch, den perfekten Code zu schreiben.\n\n" +

                "Dein Weg führt dich tief hinein in das gefürchtete Bit-Labyrinth –\n" +
                "ein Ort, an dem sich Logik und Wahnsinn vermischen.\n" +
                "Hier existieren Räume, die sich selbst neu kompilieren,\n" +
                "und Kreaturen, die aus purem Code bestehen.\n\n" +

                "Irgendwo in diesen Untiefen wartet der AC 9000.\n" +
                "Doch nicht jeder, der ihn sucht, kehrt zurück...\n\n" +

                "Initialisierung gestartet...",
                ConsoleColor.Cyan);

            // Map & Player initialisieren
            var startRoom = MapBuilder.Build();
            Player player = new Player("Peter");
            player.CurrentRoom = startRoom;

            // Dunkel-Intro + NPC-Schrei
            Console.WriteLine($"\nDu stehst in {startRoom.Name}. Es ist stockdunkel. " +
                              "Aus dem Raum heraus hörst Du eine Person schreien:");
            HelperFunctions.WriteLineColour("[N]achtportier: \"Halt, stehen bleiben! Wer ist da?\"",
                ConsoleColor.Yellow);

            // Spielschleife
            GameController controller = new GameController(player);
            while (controller.IsRunning)
            {
                controller.PrintPrompt();
                string input = Console.ReadLine();
                controller.HandleInput(input);
            }
        }
    }
}
