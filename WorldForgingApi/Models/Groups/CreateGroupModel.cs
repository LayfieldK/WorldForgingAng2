using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WorldForging.Models.Groups
{
    public class CreateGroupModel
    {
        public int WorldId { get; set; }
        public Entity VMEntity { get; set; }
        public Group VMGroup { get; set; }
        public string SelectedGroupType { get; set; }
        public ICollection<SelectListItem> GroupTypes { get; set; }
    }
}