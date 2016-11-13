namespace WorldForging.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public int WorldId { get; set; }
        public World World { get; set; }
        
        
    }
}