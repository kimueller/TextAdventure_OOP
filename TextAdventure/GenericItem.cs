namespace TextAdventure
{
    // Generisches Item mit konfigurierbarer Use-Ausgabe
    public class GenericItem : Item
    {
        private string[] _useLines;

        public GenericItem(string name, params string[] useLines) : base(name)
        {
            _useLines = useLines;
        }

        public override string[] Use(Room room)
        {
            return _useLines;
        }
    }
}
