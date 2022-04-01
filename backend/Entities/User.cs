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
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool IsFirstLogin { get; set; } = true;
        [Required]
        public string? StaffCode{get;set;}
        [Required]
        public Role Role { get; set; }
        public DateTime JoindedDate { get; set; }
        public DateTime DateOfBirth{get;set;}
        public virtual ICollection<ReturningRequest> Requests { get; set; }
        public virtual ICollection<ReturningRequest> Processed { get; set; }
        public virtual ICollection<Assignment> AssignedBy { get; set; }
        public virtual ICollection<Assignment> AssignedTo { get; set; }
    }
}