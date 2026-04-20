using System.Collections.Generic;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Abstrakte Basisklasse fuer alle Gegenstaende im Spiel
    // Items koennen benutzt werden und ggf. weitere Items enthalten
    public abstract class Item
    {
        public string Name { get; protected set; }
        public List<Item> ContainedItems { get; protected set; }

        protected Item(string name)
        {
            Name = name;
            ContainedItems = new List<Item>();
        }

        // Gibt Beschreibung der Benutzung zurueck; kann den Raumzustand veraendern
        public abstract string[] Use(Room room);
    }
}
