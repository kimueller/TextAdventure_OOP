using TextAdventure.Rooms;

namespace TextAdventure.Players
{
    // Repräsentiert den Spieler Peter
    public class Player
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; set; }
        public string LastDirection { get; set; }

        public Player(string name = "Peter")
        {
            Name = name;
            LastDirection = "";
        }
    }
}
