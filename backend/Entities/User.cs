using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? UserName { get; set; }

        [Required, MaxLength(250)]
        public string? PasswordHash { get; set; }

        [Required, MaxLength(250)]
        public string? FirstName { get; set; }
        [Required, MaxLength(250)]
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public DateTime JoindedDate { get; set; }
        public ICollection<ReturningRequest> Requests { get; set; }
        public ICollection<ReturningRequest> Processed { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
    }
}