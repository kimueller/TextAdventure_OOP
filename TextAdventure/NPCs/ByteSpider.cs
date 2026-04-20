using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.Rooms;

namespace TextAdventure.NPCs
{
    public class ByteSpider : NPC
    {
        public ByteSpider() : base("ByteSpider")
        {
        }

        public override string[] Talk()
        {
            return new string[]
            {
                "01110011 01110011 01110011",
                "0x53 0x53 0x53",
                "0xDE 0xAD 0xBE 0xEF",
                "01001000 01101001",
            };
        }
    }
}
