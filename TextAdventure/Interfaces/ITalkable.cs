namespace TextAdventure.Interfaces
{
    public interface ITalkable
    {
        /// <summary>
        /// Sprich mit NPC oder Item
        /// </summary>
        /// <returns>Antwort des NPCs oder Items</returns>
        string[] Talk();
    }
}
