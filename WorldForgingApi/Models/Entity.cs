using System.Collections.Generic;

namespace WorldForging.Models
{
    public class Entity
    {
        public int EntityId { get; set; }

        public int? WorldId { get; set; }
        public World World { get; set; }

        public  ICollection<EntityBelief> EntityBeliefs { get; set; }

        public ICollection<EntityDesire> EntityDesires { get; set; }

        public  ICollection<EntityConvention> EntityConventions { get; set; }

        //public ICollection<EntityEntity> Entity1Relationships { get; set; }

        //public ICollection<EntityEntity> Entity2Relationships { get; set; }


    }
}