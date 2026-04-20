using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    public class PrimaryKey : Item
    {

        public PrimaryKey() : base("Primärschlüssel")
        {
        }

        public override string[] Use(Room room)
        {
            return new string[] { $"Der Schlüssel zum Bändigens des Compilers!" };
        }
    }
}
