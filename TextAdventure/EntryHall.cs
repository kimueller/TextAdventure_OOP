namespace TextAdventure
{
    // Eingangshalle: Startpunkt, dunkel, Nachtportier wartet hier
    public class EntryHall : Room
    {
        public EntryHall() : base("Eingangshalle", isLit: false) { }

        public override string[] Enter(Player player)
        {
            // Beim allerersten Betreten (Spielstart) wird eine andere Nachricht angezeigt
            return new string[] { $"Du gehst nach {player.LastDirection} und betrittst {Name}." };
        }
    }
}
