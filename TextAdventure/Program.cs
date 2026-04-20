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
            // Intro-Text
            HelperFunctions.WriteLineColour(
                "In einem Universum aus Daten und Algorithmen schlummert eine uralte Macht: der\n" +
                "allmächtige Compiler 'AC 9000'. Legenden erzählen von seinem unendlichen Wissen\n" +
                "und seiner Fähigkeit, jeden Code manipulieren zu können, jeden Datentyp casten\n" +
                "zu können und jede Schleife mit nur einem Durchlauf zu bewältigen. Einige\n" +
                "behaupten sogar, dass der Compiler die Gedanken des:der Programmier:in lesen\n" +
                "kann....\n\n" +
                "Du, Dave - ein:e mutige:r Programmier:in - begibst Dich auf die Suche nach\n" +
                "diesem sagenumwobenen Compiler. Angetrieben von Neugier und Abenteuerlust\n" +
                "machst Du Dich in die Hauptzentrale des Software-Megakonzerns MicroApple auf,\n" +
                "wo laut Gerüchten der Compiler in dessen Untiefen versteckt sein soll....",
                ConsoleColor.Cyan);

            // Map & Player initialisieren
            var (startRoom, allRooms) = MapBuilder.Build();
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
