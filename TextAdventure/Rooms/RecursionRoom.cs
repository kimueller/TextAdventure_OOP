using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    public class RecursionRoom : Room
    {
        public bool Solved { get; set; }

        public RecursionRoom() : base("Rekursionsraum", "Westen --> Garbage Collectorhalle")
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
    }
}
