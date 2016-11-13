namespace WorldForging.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}