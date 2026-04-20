namespace TextAdventure.Rooms
{
    // Generischer Raum ohne spezielles Verhalten
    public class GenericRoom : Room
    {
        public GenericRoom(string name, bool isLit = true) : base(name, isLit) { }
    }
}
