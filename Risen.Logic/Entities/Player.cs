﻿using System.Collections.Generic;
using Risen.Logic.Enums;
using Risen.Logic.Utility;

namespace Risen.Logic.Entities
{
    public class Player
    {
        public Player()
        {
        }

        public Player(Room spawnRoom)
        {
            CurrentRoom = spawnRoom;
        }

        public string GivenName { get; set; }
        public string Surname { get; set; }
        public CharacterClass Class  { get; set; }
        public byte Level { get; set; }
        public Room CurrentRoom { get; set; }

        public void MoveTo(Direction exit)
        {
            CurrentRoom = CurrentRoom.Exits[exit];
        }

        public Room MoveTo(Point roomCoordinates)
        {
            CurrentRoom = ZoneCache.MovePlayerTo(this, roomCoordinates);
            return CurrentRoom;
        }
    }

    public class CharacterClass
    {
        public string Name { get; set; }
        public ExperienceTable ExperienceTable { get; set; }
    }

    public class ExperienceTable
    {
        public Dictionary<byte, int> LevelDefinitions { get; set; } 
    }
}
