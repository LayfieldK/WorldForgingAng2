using System.ComponentModel.DataAnnotations.Schema;

namespace WorldForging.Models
{
    public class EntityEntity
    {
        public int EntityEntityId { get; set; }

        public int Entity1Id { get; set; }
        [ForeignKey("Entity1Id"),Column(Order = 0)]
        public Entity Entity1 { get; set; }

        public int? Entity2Id { get; set; }
        [ForeignKey("Entity2Id"), Column(Order = 1)]
        public Entity Entity2 { get; set; }

        public int EntityRelationshipId { get; set; }
        public EntityRelationship EntityRelationship { get; set; }
    }
}