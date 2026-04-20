using TextAdventure.NPCs;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Lichtschalter: schaltet das Licht im aktuellen Raum ein oder aus
    public class LightSwitch : Item
    {
        private HelloWorldNPC hellowWorldNPC; // optional: Nachtportier reagiert auf Schalten

        public LightSwitch(HelloWorldNPC helloWorldNPC = null) : base("Lichtschalter")
        {
            hellowWorldNPC = helloWorldNPC;
        }

        public override string[] Use(Room room)
        {
            room.IsLightOn = !room.IsLightOn;
            if (!room.IsLightOn && hellowWorldNPC != null)
            {
                // Nachtportier schaltet Licht wieder an
                hellowWorldNPC.ReactToLightSwitch();
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
