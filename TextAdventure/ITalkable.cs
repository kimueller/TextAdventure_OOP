namespace TextAdventure
{
    // Interface fuer alle Objekte, mit denen der Spieler sprechen kann (NPCs und bestimmte Items)
    public interface ITalkable
    {
        string[] Talk();
    }
}
