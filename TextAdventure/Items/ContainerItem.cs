using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Generisches Container-Item (z.B. Schrank): enthaelt weitere Items, die angezeigt werden
    public class ContainerItem : Item
    {
        private string _useDescription;

        public ContainerItem(string name, string useDescription) : base(name)
        {
            _useDescription = useDescription;
        }

        public override string[] Use(Room room)
        {
            var lines = new System.Collections.Generic.List<string>();
            lines.Add(_useDescription);
            if (ContainedItems.Count > 0)
            {
                lines.Add("Darin befinden sich:");
                foreach (Item item in ContainedItems)
                    lines.Add($"  - {item.Name}");
            }
            return lines.ToArray();
        }
    }
}
