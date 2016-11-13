using System.Collections.Generic;

namespace WorldForging.Models
{
    public class BeliefRelationship
    {
        public int BeliefRelationshipId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<EntityBelief> EntityBeliefs { get; set; }
    }
}