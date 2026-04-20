using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.Items;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    public class InterfacePassage : Room
    {
        public InterfacePassage() : base("Interface-Passage", "Norden --> Debugginglabor\nOsten --> Unused Refernces-Lager\nSüden --> Byte-Katakomben\nWesten --> Stackoverflowkammer", false)

        {
            //NPCs hinzufügen
            ByteSpider byteSpider = new ByteSpider();
            base.NPCs.Add(byteSpider);

            LightSwitch lightSwitch = new LightSwitch();
            base.Items.Add(lightSwitch);
        }
    }
}
