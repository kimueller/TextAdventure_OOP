using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure.Items;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    public class StackoverflowChamber : Room
    {
        public List<Room> CanidateRooms { get; set; }
        public StackoverflowChamber(List<Room> candidateRooms) : base("Stackoverflow-Kammer", "Osten --> Interface-Passage")
        {
            CanidateRooms = candidateRooms;

            PathfinderModule pathfinderModule = new PathfinderModule();
            base.Items.Add(pathfinderModule);
        }
    }
}
