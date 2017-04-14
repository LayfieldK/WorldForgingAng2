using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldForging.Models.Users;

namespace WorldForging.Models
{
    public class Relationship
    {
        #region Constructor
        public Relationship()
        {

        }
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int? InverseRelationshipId { get; set; }



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

        [ForeignKey("InverseRelationshipId")]
        public virtual Relationship InverseRelationship { get; set; }

        #endregion Related Properties
    }

    public class RelationshipDTO
    {
        #region Constructor
        public RelationshipDTO()
        {

        }
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public int? InverseRelationshipId { get; set; }



        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        #endregion Properties

    }
}
