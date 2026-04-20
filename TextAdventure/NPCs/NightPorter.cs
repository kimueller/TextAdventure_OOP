using TextAdventure.Rooms;

namespace TextAdventure.NPCs
{
    // Nachtportier: schaltet das Licht ein wenn man mit ihm spricht
    public class NightPorter : NPC
    {
        private Room _room;
        private bool _hasSpoken;

        public NightPorter(Room room) : base("Nachtportier")
        {
            _room = room;
            _hasSpoken = false;
        }

        public override string[] Talk()
        {
            if (!_hasSpoken)
            {
                _hasSpoken = true;
                _room.IsLit = true;
                return new string[]
                {
                    "Du erschrickst und stotterst: \"Ich bin Dave, der neue Reinigungsmitarbeitende!\"",
                    "Der Nachtportier schaltet das Licht ein und wie durch ein Wunder lässt er Dich passieren.",
                    "[N]achtportier: \"Alles klar – wir hatten Dich bereits erwartet, bist spät dran...."
                };
            }
            return new string[] { "[N]achtportier: \"Ich habe Dir alles gesagt, was ich weiß. Beweg Dich!\"" };
        }

        // Wird aufgerufen wenn Spieler den Lichtschalter betaetigt (Nachtportier schaltet Licht wieder an)
        public void ReactToLightSwitch()
        {
            if (_hasSpoken)
                _room.IsLit = true;
        }
    }
}
