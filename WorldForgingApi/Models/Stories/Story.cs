using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WorldForging.Models
{
    public class Story
    {
        public int StoryId { get; set; }

        public String UrlAffix { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }

        public int? EntityId { get; set; }
        public virtual Entity Entity { get; set; }

        public int WorldId { get; set; }
        public World World { get; set; }
    }
}
