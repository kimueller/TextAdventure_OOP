using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.Items;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    public class LegacyCodeArchive : Room
    {
        public LegacyCodeArchive() : base("Legacy Code-Archiv", "Westen --> Unused Refernces-Lager")
        {
            Vault vault = new Vault("Die schwere Tresortür ist offen!");
            base.Items.Add(vault);
        }
    }
}
