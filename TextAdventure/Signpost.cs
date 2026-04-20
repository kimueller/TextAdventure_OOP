namespace TextAdventure
{
    // Wegweiser: zeigt an wohin eine Richtung fuehrt
    public class Signpost : Item
    {
        private string _description;

        public Signpost(string description) : base("Wegweiser")
        {
            _description = description;
        }

        public override string[] Use(Room room)
        {
            return new string[] { $"Du schaust Dir den Wegweiser an. {_description}" };
        }
    }
}
