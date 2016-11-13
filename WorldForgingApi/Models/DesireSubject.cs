namespace WorldForging.Models
{
    public class DesireSubject
    {
        public int DesireSubjectId { get; set; }

        public int DesireId { get; set; }
        public Desire Desire { get; set; }

        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}