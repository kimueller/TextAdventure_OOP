using System.Collections.Generic;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Statue von Tim Gates: schaltet alle Raeume der Map ein wenn benutzt
    public class Statue : Item
    {
        private List<Room> _allRooms;
        private bool _used;

        public Statue(List<Room> allRooms) : base("Statue von Tim Gates")
        {
            _allRooms = allRooms;
            _used = false;
        }

        public override string[] Use(Room room)
        {
            if (!_used)
            {
                _used = true;
                foreach (Room r in _allRooms)
                    r.IsLightOn = true;
                return new string[]
                {
                    "Die Statue macht klack und Du siehst nun ein Schild auf dem steht: \"Alle Räume sind nun erhellt!\""
                };
            }
            return new string[] { "Die Statue steht reglos da und tut nichts weiter." };
        }
    }
}
