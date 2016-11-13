namespace WorldForging.Models
{
    public class EntityBelief
    {
        public int EntityBeliefId {get;set;}

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int BeliefId { get; set; }
        public Belief Belief { get; set; }
    }
}