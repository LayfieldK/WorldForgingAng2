using System.Collections.Generic;

namespace WorldForging.Models
{
    public class EntityDesire
    {
        public int EntityDesireId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int DesireId { get; set; }
        public Desire Desire { get; set; }

        public virtual ICollection<EntityDesireReason> EntityDesireReasons { get; set; }
    }
}