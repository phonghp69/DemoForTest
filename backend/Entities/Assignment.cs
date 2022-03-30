using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
        public virtual User User { get; set; }
        public virtual Asset Asset { get; set; }
        public int RequestId { get; set; }
        public virtual ReturningRequest ReturningRequest { get; set; }
    }
}