using TextAdventure.Interfaces;

namespace TextAdventure.NPCs
{
    public abstract class NPC : ITalkable
    {
        /// <summary>
        /// Name des NPCs
        /// </summary>
        public string Name { get; protected set; }

        //Konstruktur der NPC Klasse, damit jeder NPC einen Namen hat
        protected NPC(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Talk-Methode fürs interagieren mit dem NPC, abstract weil sie immer überschrieben wird
        /// </summary>
        /// <returns>Dialog des NPCs</returns>
        public abstract string[] Talk();
    }
}
