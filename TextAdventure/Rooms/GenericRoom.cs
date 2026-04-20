namespace TextAdventure.Rooms
{
    // Generischer Raum ohne spezielles Verhalten
    public class GenericRoom : Room
    {
        public GenericRoom(string name, bool IsLightOn = true) : base(name, IsLightOn) { }
    }
}
