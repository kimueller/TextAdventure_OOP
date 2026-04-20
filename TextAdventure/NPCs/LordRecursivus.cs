using TextAdventure.Rooms;

namespace TextAdventure.NPCs
{
    // Nachtportier: schaltet das Licht ein wenn man mit ihm spricht
    public class LordRecursivus : NPC
    {
        private bool _hasSpoken;

        public LordRecursivus() : base("Lord Recursivus")
        {
            _hasSpoken = false;
        }

        public override string[] Talk()
        {
            if (!_hasSpoken)
            {
                _hasSpoken = true;
                return new string[]
                {
                    "MUHahAhAHaHA! Du hast mich gefunden, Lord Recursivus, der Wächter der Unendlichkeit!",
                    "Du bist hier gefangen, bis Du das Rätsel der Rekursion gelöst hast!\n",
                    "Rätsel:",
                    "Ich wiederhole mich... immer und immer wieder...",
                    "Ich kann nicht aufhören...",
                    "Hilf mir... die Schleife zu beenden..."
                };
            }
            return new string[] {
                "[L]ord Recursivus:",
                "Ich wiederhole mich... immer und immer wieder...",
                "Ich kann nicht aufhören...",
                "Hilf mir... die Schleife zu beenden..."
            };
        }
    }
}

