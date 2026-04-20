using System;
using TextAdventure.Controls;
using TextAdventure.Interfaces;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    public class AC9000 : Item, ITalkable
    {
        bool _hasSpoken;
        bool _solved = false;
        public AC9000() : base("Almighty Compiler 9000") { }

        /// <summary>
        /// Überschriebene Use-Methode für AC9000
        /// </summary>
        /// <param name="room">Raum in der der Compiler ist</param>
        /// <returns>Antworten des Compilers</returns>
        public override string[] Use(Room room)
        {
            HelperFunctions.WriteLineColour("Mit [c] oder [cancel] kannst du abbrechen, wenn du die Lösung noch nicht weißt!", ConsoleColor.Green);
            var isCorrect = CheckCompilerCode();
            if (isCorrect)
            {
                return new string[]
                {
                    "Du hast den versteckten Code gefunden und eingegeben. AC9000 ist jetzt gebändigt und steht dir zur Verfügung!",
                    "Rede mit ihm, um mit ihm das Abenteuer zu starten und das Spiel zu beenden!"
                };
            }
            else
            {
                return new string[]
                {
                    "Finde den Code um den Compiler zu bändigen!"
                };
            }

        }

        /// <summary>
        /// Sprich mit dem Compiler, um mehr über ihn zu erfahren oder um das Spiel zu gewinnen, wenn er bereits gebändigt ist
        /// </summary>
        /// <returns>Antwort des Compilers</returns>
        public string[] Talk()
        {
            if (_solved)
            {
                return new string[]
                {
                    "AC9000: Du hast mich überwältigt!",
                    "AC9000: Ich stehe dir zu Diensten!",
                    "GAME_WIN"
                };
            }
            if (!_hasSpoken)
            {
                _hasSpoken = true;
                return new string[]
                {
                    "Du sprichst mit AC9000, dem allmächtigen Compiler. Er antwortet mit einer Stimme, die wie ein Echo klingt:",
                    "Dieser Compiler ist unendlich mächtig, unendlich weise und unendlich...",
                    "...um ihn zu bändigen, musst du den verstecken Code finden und eingeben."
                };
            }
            return new string[]
            {
                "AC9000: Ich habe dir bereits alles gesagt, was ich weiß. Finde den versteckten Code und gib ihn ein!"
            };
        }

        /// <summary>
        /// Checkt, ob der code Richtig ist oder nicht
        /// </summary>
        /// <returns>Boolen ob es richtig oder falsh ist</returns>
        public bool CheckCompilerCode()
        {
            while (!_solved)
            {
                Console.Write("Deine Antwort: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.ToLower().Equals("sesam"))
                {
                    HelperFunctions.WriteLineColour("Richtig! Du hast ihn gebändigt!", ConsoleColor.Green);
                    return _solved = true;
                }
                else if (input.ToLower().Equals("c") || input.ToLower().Equals("cancel"))
                {
                    HelperFunctions.WriteLineColour("Du hast den Versuch abgebrochen.", ConsoleColor.Yellow);
                    break;
                }
                else
                {
                    HelperFunctions.WriteLineColour("Falsch. Versuche es erneut.", ConsoleColor.Red);
                }
            }
            return _solved;

        }
    }
}
