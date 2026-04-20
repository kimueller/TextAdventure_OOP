using TextAdventure.Rooms;

namespace TextAdventure.NPCs
{
    // Nachtportier: schaltet das Licht ein wenn man mit ihm spricht
    public class HelloWorldNPC : NPC
    {
        private Room _room;
        private bool _hasSpoken;

        public HelloWorldNPC(Room room) : base("Hello Van World")
        {
            _room = room;
            _hasSpoken = false;
        }

        public override string[] Talk()
        {
            if (!_hasSpoken)
            {
                _hasSpoken = true;
                _room.IsLightOn = true;
                return new string[]
                {
                    "Du erschrickst und stotterst: \"Ich bins! Auf der Suche nach dem AC9000!\"",
                    "Hello Van World schaltet das Licht ein und wie durch ein Wunder lässt er Dich passieren.",
                    "[H]ello Van World: \"Alles klar – wir hatten Dich bereits erwartet, bist spät dran...."
                };
            }
            return new string[] { "[H]ello Van World: \"Ich habe Dir alles gesagt, was ich weiß. Beweg Dich!\"" };
        }

        public void ReactToLightSwitch()
        {
            if (_hasSpoken)
                _room.IsLightOn = true;
        }
    }
}
