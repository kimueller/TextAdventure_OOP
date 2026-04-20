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
        public static Room Build()
        {
            // --- Raeume erstellen ---
            InitialRoom initalRoom = new InitialRoom();
            Room garbageCollectorHall = new GarbageCollectorHall();
            Room recursionRoom = new RecursionRoom();
            Room debuggingLabor = new DebuggingLabor();
            Room interfacePassage = new InterfacePassage();
            Room byteCatacombs = new ByteCatacombs();
            Room unusedReferencesStorage = new UnusedReferencesStorage();
            Room legacyCodeArchive = new LegacyCodeArchive();

            // --- AC9000 in zufaelligem Raum platzieren (nicht Eingangshalle) ---
            List<Room> candidateRooms = new List<Room>
            {
                garbageCollectorHall, recursionRoom, debuggingLabor, interfacePassage,
                byteCatacombs, unusedReferencesStorage, legacyCodeArchive
            };

            Room stackoverflowChamber = new StackoverflowChamber(candidateRooms);

            // Räume verbinden
            initalRoom.East = garbageCollectorHall;

            garbageCollectorHall.West = initalRoom;
            garbageCollectorHall.South = debuggingLabor;
            garbageCollectorHall.East = recursionRoom;


            recursionRoom.West = garbageCollectorHall;

            debuggingLabor.North = garbageCollectorHall;
            debuggingLabor.South = interfacePassage;

            interfacePassage.North = debuggingLabor;
            interfacePassage.West = stackoverflowChamber;
            interfacePassage.South = byteCatacombs;
            interfacePassage.East = unusedReferencesStorage;

            stackoverflowChamber.East = interfacePassage;

            byteCatacombs.North = interfacePassage;

            unusedReferencesStorage.West = interfacePassage;
            unusedReferencesStorage.East = legacyCodeArchive;

            legacyCodeArchive.West = unusedReferencesStorage;


            // --- Alle Raeume fuer Statue und AC9000-Platzierung ---
            List<Room> allRooms = new List<Room>
            {
                initalRoom, garbageCollectorHall, recursionRoom, debuggingLabor, interfacePassage, byteCatacombs, stackoverflowChamber, unusedReferencesStorage, legacyCodeArchive
            };

            return initalRoom;
        }
    }
}
