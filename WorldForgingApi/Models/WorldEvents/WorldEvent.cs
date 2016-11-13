namespace WorldForging.Models
{
    public class WorldEvent
    {
        public int WorldEventId { get; set; }

        public int? EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}