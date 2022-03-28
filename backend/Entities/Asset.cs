using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Enums;

namespace Back_end.DB.Entities
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId{get;set;}
        public int CategoryId{get;set;}
        public int AssignmentId{get;set;}
        public string Name{get;set;}
        public string AssetStatus{get;set;}
        [Required, DefaultValue(AssetState.WaitingForRecycle)]
        public AssetState AssetState{get;set;}
        public Assignment Assignment{get;set;}
        public Category Category{get;set;}
    }
}