using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class DebuggingLabor : Room
    {
        public DebuggingLabor() : base("Debugginglabor", "\nNorden --> Halle der Garbage Collectors\nSüden --> Interface-Passage")
        {
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst das Debugginglabor",
                "Hier wurde früher am AC9000 getestet....bis es dem AC9000 reichte.",
            };
        }
    }
}
