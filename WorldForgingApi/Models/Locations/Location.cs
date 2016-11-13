namespace WorldForging.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}