namespace WorldForging.Models.Locations
{
    public class CreateLocationModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public Location VMLocation { get; set; }
    }
}