﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorldForging.Models;

namespace WorldForging.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ArticleViewModel
    {
        #region Constructor
        public ArticleViewModel()
        {

        }
        #endregion Constructor

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Notes { get; set; }
        public ICollection<EntityRelationshipDTO> EntityRelationships { get; set; }
        [DefaultValue(0)]
        public int Type { get; set; }
        [DefaultValue(0)]
        public int Flags { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        #endregion Properties
    }
}
