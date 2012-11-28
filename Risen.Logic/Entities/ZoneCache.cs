﻿using System.Collections.Generic;
using System.Linq;
using Risen.Server.Utility;

namespace Risen.Server.Entities
{
    public class ZoneCache
    {
        static ZoneCache()
        {
            Cache = new List<Zone>();
        }

        public static List<Zone> Cache { get; set; }

        public void LoadZoneIntoCache(uint zoneId)
        {
            Cache.Add(new Zone()); // call fluent for value in the future
        }

        public static Room MoveMobileEntityTo(MobileEntity mob, Point roomCoordinates)
        {
            var targetRoom = mob.CurrentRoom.Zone.Rooms.First(o => o.Coordinates == roomCoordinates);
            mob.CurrentRoom = targetRoom;

            return targetRoom;
        }
    }
}