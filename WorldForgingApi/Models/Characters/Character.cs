namespace WorldForging.Models
{
    public class Character
    {
        public int CharacterId { get; set; }


        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
    }
}