using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Utilities;

namespace TS.BlogSystem.Core.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = GuidUtils.GenerateComb();
        }
        public Guid Id { get; set; }
    }
}
