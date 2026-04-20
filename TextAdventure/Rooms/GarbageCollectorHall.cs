using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.NPCs;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class GarbageCollectorHall : Room
    {
        public GarbageCollectorHall() : base("Halle der Garbage Collectors", "Osten --> Rekursionsraum\nWesten --> Initalisierungsraum")
        {
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst die Halle der Garbage Collectors",
                "Hier stapeln sich die Überreste von längst vergessenen Datenstrukturen," +
                "die von den unermüdlichen Garbage Collectors beseitigt wurden.",
            };
        }
    }
}
