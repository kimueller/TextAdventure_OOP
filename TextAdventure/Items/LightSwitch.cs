using TextAdventure.NPCs;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Lichtschalter: schaltet das Licht im aktuellen Raum ein oder aus
    public class LightSwitch : Item
    {
        private NightPorter _porter; // optional: Nachtportier reagiert auf Schalten

        public LightSwitch(NightPorter porter = null) : base("Lichtschalter")
        {
            _porter = porter;
        }

        public override string[] Use(Room room)
        {
            room.IsLightOn = !room.IsLightOn;
            if (!room.IsLightOn && _porter != null)
            {
                // Nachtportier schaltet Licht wieder an
                _porter.ReactToLightSwitch();
                return new string[]
                {
                    "Das Licht geht aus. Nachtportier schaltet es wieder ein und schaut Dich böse an."
                };
            }
            if (room.IsLightOn)
                return new string[] { "Du schaltest das Licht ein. Es wird hell." };
            else
                return new string[] { "Du schaltest das Licht aus. Es wird dunkel." };
        }
    }
}
