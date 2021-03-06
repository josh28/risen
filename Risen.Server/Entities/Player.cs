﻿using Risen.Server.ReferenceTypes;

namespace Risen.Server.Entities
{
    public class Player : MobileEntity
    {
        public Player()
        {
        }

        public Player(Room spawnRoom)
        {
            CurrentRoom = spawnRoom;
        }

        public virtual User User { get; set; }
        public virtual PlayerClass Class { get; set; }
        public virtual byte Level { get; set; }
        public virtual long Experience { get; set; }
        public virtual Attributes Attributes { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
