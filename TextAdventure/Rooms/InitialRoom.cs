using TextAdventure.NPCs;
using TextAdventure.Players;


namespace TextAdventure.Rooms

{
    // Eingangshalle: Startpunkt, dunkel, Nachtportier wartet hier
    public class InitialRoom : Room
    {
        public InitialRoom() : base("Initialiserungs-Raum", "Osten --> Garbage Collector Halle", isLightOn: false) 
        {
            HelloWorldNPC helloWorldNPC = new HelloWorldNPC(this);
            base.NPCs.Add(helloWorldNPC);
        }
    }
}


