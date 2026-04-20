using TextAdventure.Items;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class LegacyCodeArchive : Room
    {
        public LegacyCodeArchive() : base("Legacy Code-Archiv", "\nWesten --> Unused Refernces-Lager")
        {
            Vault vault = new Vault("Die schwere Tresortür ist offen!");
            base.Items.Add(vault);
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst das Legacy Code-Archiv",
                "Hier lagern die Überreste von längst vergessenen Projekten, die von den Entwicklern als 'Legacy Code' bezeichnet wurden."
            };
        }
    }
}
