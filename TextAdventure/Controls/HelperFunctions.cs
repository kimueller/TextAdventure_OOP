using System;

namespace TextAdventure.Controls
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Checkt ob die Eingabe mit einer Aktion übereinstimmt, auch Abkürzungen, Ausgeschrieben etc..
        /// </summary>
        /// <param name="name">das richtige item/NPC mit dem man inteagieren will</param>
        /// <param name="target">Eingabe des Nutzers</param>
        /// <returns></returns>
        public static bool MatchesTarget(string name, string target)
        {
            return name.StartsWith(target, StringComparison.OrdinalIgnoreCase)
                || name.Equals(target, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Beendet das Spiel, wenn man den Compiler gebändigt hat
        /// </summary>
        /// <returns>false, damit die while schleife bricht</returns>
        public static bool StopGame()
        {
            Console.WriteLine();
            WriteLineColour("Game Over - vielen Dank für das Spielen von 'Quest for the Almighty Compiler'.", ConsoleColor.Cyan);
            return false;
        }

        /// <summary>
        /// Printet mehrere Zeilen in einer bestimmten Farbe (damit es übersichtlicher ist)
        /// </summary>
        /// <param name="lines">Lines zum printen</param>
        /// <param name="colour">Farbe in der geprintet wird</param>
        public static void PrintLines(string[] lines, ConsoleColor colour)
        {
            foreach (string line in lines)
                WriteLineColour(line, colour);
        }

        /// <summary>
        /// Schreibe bestimmten Textabschnitt in einer bestimmten Farbe
        /// </summary>
        /// <param name="text">Text zum printen</param>
        /// <param name="colour">Farbe in der geprintet wird</param>
        public static void WriteColour(string text, ConsoleColor colour = ConsoleColor.White)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = old;
        }

        /// <summary>
        /// Printet eine Zeile in einer bestimmten Farbe
        /// </summary>
        /// <param name="text">text zum printen</param>
        /// <param name="colour">Farbe in der geprintet wird</param>
        public static void WriteLineColour(string text, ConsoleColor colour = ConsoleColor.White)
        {
            WriteColour(text + Environment.NewLine, colour);
        }
    }
}
