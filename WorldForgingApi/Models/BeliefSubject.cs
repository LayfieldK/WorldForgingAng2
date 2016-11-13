namespace WorldForging.Models
{
    public class BeliefSubject
    {
        public int BeliefSubjectId { get; set; }

        public int BeliefId { get; set; }
        public Belief Belief { get; set; }

        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}