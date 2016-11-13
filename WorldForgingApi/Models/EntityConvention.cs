namespace WorldForging.Models
{
    public class EntityConvention
    {
        public int EntityConventionId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int ConventionId { get; set; }
        public Convention Convention { get; set; }
    }
}