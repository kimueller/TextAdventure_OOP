using TextAdventure.Interfaces;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    // Der allmächtige Compiler AC 9000 – Ziel des Spiels
    // Kann benutzt und gesprochen werden (ITalkable)
    public class AC9000 : Item, ITalkable
    {
        public AC9000() : base("Almighty Compiler 9000") { }

        public override string[] Use(Room room)
        {
            return new string[]
            {
                "Du zitterst und versuchst AC9000 zu benutzen; nichts passiert. Vielleicht solltest versuchen mit ihm zu reden...."
            };
        }

        public string[] Talk()
        {
            return new string[]
            {
                "Du sprichst den allmächtigen Compiler an.",
                "Er antwortet: \"Gratulation, Du hast mich gefunden!\"",
                "GAME_WIN" // Spezieller Token der GameController abfaengt
            };
        }
    }
}
