using System.Collections.Generic;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Generisches Container-Item (z.B. Schrank): enthaelt weitere Items, die angezeigt werden
    public class Vault : Item
    {
        private string _useDescription;

        public Vault(string useDescription) : base("Vault")
        {
            _useDescription = useDescription;
            PrimaryKey primaryKey = new PrimaryKey();
            base.ContainedItems.Add(primaryKey);
        }

        public override string[] Use(Room room)
        {
            var lines = new List<string>
            {
                _useDescription,
                "Darin befinden sich:",
                $"\t- {ContainedItems[0].Name} - Code: Sesam"
            };
            return lines.ToArray();
        }
    }
}
