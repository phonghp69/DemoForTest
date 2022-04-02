using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Enums;

namespace backend.Entities
{
    public class ReturningRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        [Required]
        public int RequestedByUserId { get; set; }
        public virtual User? RequestedBy { get; set; }
        public int ProcessedByUserId { get; set; }
        public virtual User? ProcessedBy { get; set; }
        public int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
        [Required, DefaultValue(RequestState.WaitingForReturning)]
        public RequestState RequestState { get; set; }
    }
}