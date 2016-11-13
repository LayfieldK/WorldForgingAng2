namespace WorldForging.Models
{
    public class ReasonEntity
    {
        public int ReasonEntityId { get; set; }

        public int ReasonId { get; set; }
        public Reason Reason { get; set; }

        public int? EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}