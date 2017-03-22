using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldForging.Models.Users;

namespace WorldForging.Models
{
    public class Entity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        [InverseProperty("Entity1")]
        public  ICollection<EntityRelationship> EntityRelationships { get; set; }
        
        /// <summary>
        /// Current Item's Author: this property will be loaded on first use using EF's Lazy-Loading feature.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual EntityType EntityType { get; set; }
    }
}