namespace WorldForging.Models
{
    public class ReasonSubject
    {
        public int ReasonSubjectId { get; set; }

        public int ReasonId { get; set; }
        public Reason Reason { get; set; }

        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}