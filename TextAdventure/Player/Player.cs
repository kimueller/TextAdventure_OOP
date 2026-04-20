using TextAdventure.Rooms;

namespace TextAdventure.Player
{
    // Repräsentiert den Spieler Dave
    public class Player
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; set; }
        public string LastDirection { get; set; }

        public Player(string name = "Dave")
        {
            Name = name;
            LastDirection = "";
        }
    }
}
