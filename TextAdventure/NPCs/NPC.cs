using TextAdventure.Interfaces;

namespace TextAdventure.NPCs
{
    // Abstrakte Basisklasse fuer alle Nicht-Spieler-Charaktere
    public abstract class NPC : ITalkable
    {
        public string Name { get; protected set; }

        protected NPC(string name)
        {
            Name = name;
        }

        // Jeder NPC muss eine Gespraechsantwort implementieren
        public abstract string[] Talk();
    }
}
