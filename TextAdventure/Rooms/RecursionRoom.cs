using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.NPCs;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class RecursionRoom : Room
    {
        public bool Solved { get; set; }

        public RecursionRoom() : base("Rekursionsraum", "Westen --> Halle der Garbage Collectors")
        {
            LordRecursivus lordRecursivus = new LordRecursivus();
            base.NPCs.Add(lordRecursivus);
        }

        public bool ReactToAnswer(string input)
        {
            if (input.ToLower().Contains("return"))
            {
                Solved = true;
            }
            return Solved;
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst den Rekursionsraum",
                "In der Mitte des Raumes steht Lord Recursivus...",
            };
        }
    }
}
