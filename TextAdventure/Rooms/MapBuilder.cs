using System;
using System.Collections.Generic;
using TextAdventure.Items;
using TextAdventure.NPCs;

namespace TextAdventure.Rooms
{
    // Baut die Spielwelt auf und gibt Startraum + alle Raeume zurueck
    // Loesung: AC9000 wird in einem zufaelligen Raum (ausser Eingangshalle) platziert
    public static class MapBuilder
    {
        public static (Room startRoom, List<Room> allRooms) Build()
        {
            // --- Raeume erstellen ---
            EntryHall entryHall = new EntryHall();
            Room staircase = new GenericRoom("Stiegenhaus");
            Room hallway1 = new GenericRoom("Kellergang I");
            Room hallway2 = new GenericRoom("Kellergang II");
            Room broom = new GenericRoom("Besenkammer");
            Room oldServer = new GenericRoom("Alter Serverraum");
            Room abandonedOffice = new GenericRoom("Verlassenes Büro");
            Room coldRoom = new GenericRoom("Kühlraum", isLit: false);
            Room warehouse = new GenericRoom("Lagerhalle");

            // --- Verbindungen gemaess Beispielmap ---
            // Eingangshalle <-> Stiegenhaus (Osten)
            entryHall.East = staircase;
            staircase.West = entryHall;

            // Stiegenhaus <-> Kellergang I (Sueden)
            staircase.South = hallway1;
            hallway1.North = staircase;

            // Kellergang I <-> Kellergang II (Sueden)
            hallway1.South = hallway2;
            hallway2.North = hallway1;

            // Kellergang II <-> Besenkammer (Osten)
            hallway2.East = broom;
            broom.West = hallway2;

            // Besenkammer <-> Alter Serverraum (Osten)
            broom.East = oldServer;
            oldServer.West = broom;

            // Alter Serverraum <-> Verlassenes Büro (Norden)
            oldServer.North = abandonedOffice;
            abandonedOffice.South = oldServer;

            // Alter Serverraum <-> Kühlraum (Sueden)
            oldServer.South = coldRoom;
            coldRoom.North = oldServer;

            // Alter Serverraum <-> Lagerhalle (Osten)
            oldServer.East = warehouse;
            warehouse.West = oldServer;

            // --- Alle Raeume fuer Statue und AC9000-Platzierung ---
            List<Room> allRooms = new List<Room>
            {
                entryHall, staircase, hallway1, hallway2,
                broom, oldServer, abandonedOffice, coldRoom, warehouse
            };

            // --- NPCs erstellen ---
            NightPorter porter = new NightPorter(entryHall);
            entryHall.NPCs.Add(porter);

            GenericNPC janitor = new GenericNPC("Reinigungskraft",
                "[R]einigungskraft: \"Ich hab hier nichts gesehen und nichts gehört. Weitergehen!\"");
            broom.NPCs.Add(janitor);

            // --- Items erstellen ---
            LightSwitch lightSwitch = new LightSwitch(porter);
            Signpost signpost = new Signpost("Ein Pfeil nach Osten ist mit 'Stiegenhaus' beschriftet.");
            entryHall.Items.Add(lightSwitch);
            entryHall.Items.Add(signpost);

            // Statue schaltet alle Raeume ein
            Statue statue = new Statue(allRooms);
            oldServer.Items.Add(statue);

            // Schrank in Lagerhalle mit Item drin (Item in Item)
            ContainerItem cabinet = new ContainerItem("Aktenschrank",
                "Du öffnest den Aktenschrank. Es riecht nach altem Papier.");
            cabinet.ContainedItems.Add(new GenericItem("Verstaubtes Handbuch",
                "Du blätterst im Handbuch, verstehst aber nichts."));
            warehouse.Items.Add(cabinet);

            // Notizblock im Verlassenen Büro
            GenericItem notepad = new GenericItem("Notizbuch",
                "Du liest das Notizbuch: 'Der Compiler ist nah – suche im Dunkeln!'");
            abandonedOffice.Items.Add(notepad);

            // Thermometer im Kühlraum
            GenericItem thermometer = new GenericItem("Thermometer",
                "Das Thermometer zeigt -4°C an. Hier ist es eiskalt!");
            coldRoom.Items.Add(thermometer);

            // --- AC9000 in zufaelligem Raum platzieren (nicht Eingangshalle) ---
            List<Room> candidateRooms = new List<Room>
            {
                staircase, hallway1, hallway2, broom,
                oldServer, abandonedOffice, coldRoom, warehouse
            };
            Random rng = new Random();
            Room ac9000Room = candidateRooms[rng.Next(candidateRooms.Count)];
            ac9000Room.Items.Add(new AC9000());

            return (entryHall, allRooms);
        }
    }
}
