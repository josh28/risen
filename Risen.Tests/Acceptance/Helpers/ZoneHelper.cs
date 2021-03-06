﻿using System.Collections.Generic;
using System.Linq;
using Risen.Server;
using Risen.Server.Data;
using Risen.Server.Entities;
using Risen.Server.ReferenceTypes;
using Risen.Server.Utility;
using TechTalk.SpecFlow;

namespace Risen.Tests.Acceptance.Helpers
{
    public static class ZoneHelper
    {
        public static Zone GetZoneFromContext()
        {
            return (Zone)ScenarioContext.Current.Single(o => o.Value.GetType() == typeof(Zone)).Value;
        }

        public static Zone BuildMapFromMapType(string mapType)
        {
            switch(mapType.ToLower())
            {
                case "cube":
                    return BuildCubeZone();
                case "north to south hallway":
                    return NorthToSouthHallway();
                default:
                    return new Zone();
            }
        }

        private static Zone NorthToSouthHallway()
        {
            var zone = CreateEmptyZone(3, 5);

            //var room00 = new Room { Id = 1, Coordinates = new Point(0, 0), Zone = zone };
            //var room01 = new Room { Id = 2, Coordinates = new Point(0, 1), Zone = zone };
            //var room02 = new Room { Id = 3, Coordinates = new Point(0, 2), Zone = zone };
            //var room10 = new Room { Id = 4, Coordinates = new Point(1, 0), Zone = zone };
            //var room11 = new Room { Id = 5, Coordinates = new Point(1, 1), Zone = zone };
            //var room12 = new Room { Id = 6, Coordinates = new Point(1, 2), Zone = zone };
            //var room20 = new Room { Id = 7, Coordinates = new Point(2, 0), Zone = zone };
            //var room21 = new Room { Id = 8, Coordinates = new Point(2, 1), Zone = zone };
            //var room22 = new Room { Id = 9, Coordinates = new Point(2, 2), Zone = zone };
            //var room30 = new Room { Id = 10, Coordinates = new Point(3, 0), Zone = zone };
            //var room31 = new Room { Id = 11, Coordinates = new Point(3, 1), Zone = zone };
            //var room32 = new Room { Id = 12, Coordinates = new Point(3, 2), Zone = zone };
            //var room40 = new Room { Id = 13, Coordinates = new Point(4, 0), Zone = zone };
            //var room41 = new Room { Id = 14, Coordinates = new Point(4, 1), Zone = zone };
            //var room42 = new Room { Id = 15, Coordinates = new Point(4, 2), Zone = zone };

            //room01.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.South, room11}};
            //room11.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room01}, {DirectionRef.South, room21}};
            //room21.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room11}, {DirectionRef.South, room31}};
            //room31.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room21}, {DirectionRef.South, room41}};
            //room41.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room31}};

            //zone.Rooms.Add(room00);
            //zone.Rooms.Add(room01);
            //zone.Rooms.Add(room02);
            //zone.Rooms.Add(room10);
            //zone.Rooms.Add(room11);
            //zone.Rooms.Add(room12);
            //zone.Rooms.Add(room20);
            //zone.Rooms.Add(room21);
            //zone.Rooms.Add(room22);
            //zone.Rooms.Add(room30);
            //zone.Rooms.Add(room31);
            //zone.Rooms.Add(room32);
            //zone.Rooms.Add(room40);
            //zone.Rooms.Add(room41);
            //zone.Rooms.Add(room42);

            return zone;
        }

        private static Zone BuildCubeZone()
        {
            return LoadCubeFromDatabase();
            //var zone = CreateEmptyZone(3, 3);

            //var room00 = new Room { Id = 1, Coordinates = new Point(0, 0), Zone = zone };
            //var room01 = new Room { Id = 2, Coordinates = new Point(0, 1), Zone = zone };
            //var room02 = new Room { Id = 3, Coordinates = new Point(0, 2), Zone = zone };
            //var room10 = new Room { Id = 4, Coordinates = new Point(1, 0), Zone = zone };
            //var room11 = new Room { Id = 5, Coordinates = new Point(1, 1), Zone = zone };
            //var room12 = new Room { Id = 6, Coordinates = new Point(1, 2), Zone = zone };
            //var room20 = new Room { Id = 7, Coordinates = new Point(2, 0), Zone = zone };
            //var room21 = new Room { Id = 8, Coordinates = new Point(2, 1), Zone = zone };
            //var room22 = new Room { Id = 9, Coordinates = new Point(2, 2), Zone = zone };

            //room00.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.East, room01}, {DirectionRef.South, room10}};
            //room01.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.East, room02}, {DirectionRef.South, room11}, {DirectionRef.West, room00}};
            //room02.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.South, room12}, {DirectionRef.West, room01}};
            //room10.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room00}, {DirectionRef.East, room11}, {DirectionRef.South, room20}};
            //room11.RoomExits = new Dictionary<DirectionRef, Room>
            //                   {
            //                       {DirectionRef.North, room01},
            //                       {DirectionRef.East, room12},
            //                       {DirectionRef.South, room21},
            //                       {DirectionRef.West, room10}
            //                   };
            //room12.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room02}, {DirectionRef.South, room22}, {DirectionRef.West, room11}};
            //room20.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.North, room10}, {DirectionRef.East, room21}};
            //room21.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.West, room20}, {DirectionRef.North, room11}, {DirectionRef.East, room22}};
            //room22.RoomExits = new Dictionary<DirectionRef, Room> {{DirectionRef.West, room21}, {DirectionRef.North, room12}};

            //zone.Rooms.Add(room00);
            //zone.Rooms.Add(room01);
            //zone.Rooms.Add(room02);
            //zone.Rooms.Add(room10);
            //zone.Rooms.Add(room11);
            //zone.Rooms.Add(room12);
            //zone.Rooms.Add(room20);
            //zone.Rooms.Add(room21);
            //zone.Rooms.Add(room22);

            //return zone;
        }

        private static Zone LoadCubeFromDatabase()
        {
            var repository = new Repository();
            var zone = repository.FindOne<Zone>(o => o.Name == "Aldest");
            return zone;
        }

        private static Zone CreateEmptyZone(int mapWidth, int mapHeight)
        {
            return new Zone {Rooms = new List<Room>(mapWidth*mapHeight)};
        }

        public static void SpawnPlayerAtCenterOfMap(Player player, string mapType)
        {
            Room playerOrigin = null;

            switch (mapType.ToLower().Replace(" ", string.Empty))
            {
                case "cube":
                    playerOrigin = player.MoveTo(new Point(1, 1));
                    break;
                case "northtosouthhallway":
                    playerOrigin = player.MoveTo(new Point(2, 1));
                    break;
            }

            ScenarioContext.Current.Add("PlayerOrigin", playerOrigin);
        }
    }
}
