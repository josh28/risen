﻿using FluentNHibernate.Mapping;

namespace Risen.Server.Entities.Maps
{
    public class ZoneMap : ClassMap<Zone>
    {
        public ZoneMap()
        {
            Id(o => o.Id, "ZoneId");
            Map(o => o.Name);
            Map(o => o.Rooms);
        }
    }
}