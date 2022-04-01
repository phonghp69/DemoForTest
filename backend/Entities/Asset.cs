using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Enums;

namespace backend.Entities
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        public int CategoryId { get; set; }
        // public string CategoryName{get;set;}
        public string AssetName { get; set; }
        [Required]
        public string? AssetCode{get;set;}
        [Required, DefaultValue(AssetState.WaitingForRecycle)]
        public AssetState AssetState { get; set; }
        public virtual Category Category { get; set; }
    }
}