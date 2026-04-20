using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.Items;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    public class ByteCatacombs : Room
    {
        public ByteCatacombs() : base("Byte-Katakomben", "Norden --> Interface-Passage", false)
        {
            //Item 
            ExceptionScroll exceptionScroll = new ExceptionScroll();
            base.Items.Add(exceptionScroll);

            //Lichtschalter
            LightSwitch lightSwitch = new LightSwitch();
            base.Items.Add(lightSwitch);
        }
    }
}
