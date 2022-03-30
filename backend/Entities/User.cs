using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using backend.Enums;

namespace backend.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required, MaxLength(250)]
        public string UserName { get; set; }

        [Required, MaxLength(250)]
        [JsonIgnore]
        public string PasswordHash { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Role Role { get; set; }
        public DateTime JoindedDate { get; set; }
        public virtual ICollection<ReturningRequest> Requests { get; set; }
        public virtual ICollection<ReturningRequest> Processed { get; set; }
        public virtual ICollection<Assignment> AssignedBy { get; set; }
        public virtual ICollection<Assignment> AssignedTo { get; set; }
    }
}