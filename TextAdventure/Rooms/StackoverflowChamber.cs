using System.Collections.Generic;
using TextAdventure.Items;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class StackoverflowChamber : Room
    {
        public List<Room> CanidateRooms { get; set; }
        public StackoverflowChamber(List<Room> candidateRooms) : base("Stackoverflow-Kammer", "\nOsten --> Interface-Passage")
        {
            CanidateRooms = candidateRooms;

            PathfinderModule pathfinderModule = new PathfinderModule();
            base.Items.Add(pathfinderModule);
        }
        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst die Stackoverflow-Kammer",
                "Die Kammer ist überfüllt mit sehr schlecht gefragten Problemen/Fragen...",
                "...und noch schlechteren Antworten."
            };
        }
    }
}
