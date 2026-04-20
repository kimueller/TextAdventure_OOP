using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class GarbageCollectorHall : Room
    {
        public GarbageCollectorHall() : base("Halle der Garbage Collectors", "\nOsten --> Rekursionsraum\nWesten --> Initalisierungsraum\nSüden --> Debugginglabor")
        {
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst die Halle der Garbage Collectors",
                "Hier stapeln sich die Überreste von längst vergessenen Datenstrukturen," +
                "die von den unermüdlichen Garbage Collectors beseitigt wurden.",
            };
        }
    }
}
