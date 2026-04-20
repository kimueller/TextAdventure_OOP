namespace TextAdventure.NPCs
{
    // Generischer NPC mit konfigurierbaren Antworten
    public class GenericNPC : NPC
    {
        private string[] _lines;

        public GenericNPC(string name, params string[] lines) : base(name)
        {
            _lines = lines;
        }

        public override string[] Talk()
        {
            return _lines;
        }
    }
}
