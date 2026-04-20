using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.NPCs;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class DebuggingLabor : Room
    {
        public DebuggingLabor() : base("Debugginglabor", "Norden --> Halle der Garbage Collectors\nSüden --> Interface-Passage")
        {
        }

        public override string[] Enter(Player player)
        {
            return new string[] { 
                "Du betrittst das Debugginglabor",
                "Hier wurde früher am AC9000 getestet....bis es dem AC9000 reichte.",          
            };
        }
    }
}
