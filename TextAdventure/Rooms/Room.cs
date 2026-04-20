using System.Collections.Generic;
using TextAdventure.Items;
using TextAdventure.NPCs;
using TextAdventure.Players;


namespace TextAdventure.Rooms
{
    // Abstrakte Basisklasse fuer alle Raeume
    // Raeume haben bis zu 4 Nachbarraeume (Himmelsrichtungen), Items und NPCs
    public abstract class Room
    {
        public string Name { get; protected set; }
        public bool IsLightOn { get; set; }

        public Room North { get; set; }
        public Room South { get; set; }
        public Room West  { get; set; }
        public Room East  { get; set; }

        public List<Item> Items { get; protected set; }
        public List<NPC>  NPCs  { get; protected set; }

        protected Room(string name, bool isLightOn = true)
        {
            Name  = name;
            IsLightOn = isLightOn;
            Items = new List<Item>();
            NPCs  = new List<NPC>();
        }

        // Wird aufgerufen wenn Spieler den Raum betritt
        public virtual string[] Enter(Player player)
        {
            return new string[] { $"Du gehst nach {player.LastDirection} und betrittst {Name}." };
        }

        // Wird aufgerufen wenn Spieler den Raum verlaesst
        public virtual string[] Leave(Player player)
        {
            return new string[] { };
        }
    }
}
