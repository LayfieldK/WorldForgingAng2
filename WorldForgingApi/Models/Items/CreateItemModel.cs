namespace WorldForging.Models.Items
{
    public class CreateItemModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public Item VMItem { get; set; }
    }
}