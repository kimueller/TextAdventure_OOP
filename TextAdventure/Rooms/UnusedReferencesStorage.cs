using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.NPCs;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class UnusedReferencesStorage : Room
    {
        public UnusedReferencesStorage() : base("Unused Referenceslager", "Osten --> Legacy Codearchive\nWesten --> Interface-Passage")
        {
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst das Unsued Referenceslager",
                "Hier werden alle ungenutzten Referenzen und veralteten Bibliotheken aufbewahrt, die in den Projekten nicht mehr verwendet werden.",
            };
        }
    }
}
