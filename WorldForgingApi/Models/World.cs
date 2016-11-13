using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldForging.Models
{
    public class World
    {
        public int WorldId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }

        public  ICollection<Subject> Subjects { get; set; }


        public  ICollection<Entity> Entities { get; set; }

    }
}