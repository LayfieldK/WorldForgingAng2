namespace WorldForging.Models
{
    public class EntityRelationshipReason
    {
        public int EntityRelationshipReasonId { get; set; }

        public int EntityRelationshipId { get; set; }
        public EntityRelationship EntityRelationship { get; set; }
    }
}