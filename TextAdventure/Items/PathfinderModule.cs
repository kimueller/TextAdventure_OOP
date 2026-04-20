using System;
using System.Collections.Generic;
using TextAdventure.Rooms;

namespace TextAdventure.Items
{
    public class PathfinderModule : Item
    {


        public PathfinderModule() : base("Execption-Schriftrolle")
        {

        }

        public override string[] Use(Room room)
        {
            var stackoverflowChamber = (StackoverflowChamber) room;
            Random rng = new Random();
            Room ac9000Room = stackoverflowChamber.CanidateRooms[rng.Next(stackoverflowChamber.CanidateRooms.Count)];
            ac9000Room.Items.Add(new AC9000());

            return new string[]
            {
                "Das Pathfinder-Modul zeigt dir, wo der Compiler ist:",
                "Compiler befindet sich in: " + ac9000Room.Name
            };
        }
    }
}
