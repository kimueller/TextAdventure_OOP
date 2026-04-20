using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure.Controls
{
    public static class HelperFunctions
    {

        // --- Hilfsmethoden ---

        public static bool MatchesTarget(string name, string target)
        {
            // Erlaubt Abkuerzungen: erster Buchstabe oder vollstaendiger Name
            return name.StartsWith(target, StringComparison.OrdinalIgnoreCase)
                || name.Equals(target, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StopGame()
        {
            Console.WriteLine();
            WriteLineColour("Game Over - vielen Dank für das Spielen von 'Quest for the Almighty Compiler'.", ConsoleColor.Cyan);
            return false;
        }

        public static void PrintLines(string[] lines, ConsoleColor colour)
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
