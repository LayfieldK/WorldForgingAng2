using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldForging.Models.Comments;
using WorldForging.Models.Users;

namespace WorldForging.Models
{
    public class EntityRelationship
    {
        #region Constructor
        public EntityRelationship()
        {

        }
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string Description { get; set; }

        public int? Entity1Id { get; set; }

        public int? Entity2Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        #endregion Properties

        #region Related Properties
        /// <summary>
        /// Current Item's Author: this property will be loaded on first use using EF's Lazy-Loading feature.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual EntityRelationship InverseEntityRelationship { get; set; }

        [ForeignKey("Entity1Id")]
        public virtual Entity Entity1 { get; set; }

        [ForeignKey("Entity2Id")]
        public virtual Entity Entity2 { get; set; }

        public virtual Relationship Relationship { get; set; }

        #endregion Related Properties
    }

    public class EntityRelationshipDTO
    {
        #region Constructor
        public EntityRelationshipDTO()
        {

        }
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }

        public string RelationshipDescription { get; set; }

        public string RelationshipId { get; set; }

        public int? Entity1Id { get; set; }

        public string Entity1Name { get; set; }

        public int? Entity2Id { get; set; }

        public string Entity2Name { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        #endregion Properties

        #region Related Properties
        /// <summary>
        /// Current Item's Author: this property will be loaded on first use using EF's Lazy-Loading feature.
        /// </summary>
        
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual ApplicationUser Author { get; set; }
        [JsonIgnore]
        public virtual Relationship Relationship { get; set; }

        #endregion Related Properties
    }
}
