using TextAdventure.Players;


namespace TextAdventure.Rooms

{
    // Eingangshalle: Startpunkt, dunkel, Nachtportier wartet hier
    public class StartRoom : Room
    {
        public StartRoom() : base("Initialiserungs-Raum", isLightOn: false) { }
    }
}
