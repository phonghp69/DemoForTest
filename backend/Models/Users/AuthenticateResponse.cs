using System.ComponentModel.DataAnnotations;
using backend.Entities;
using backend.Enum;

namespace backend.Models.Users
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Token = token;
        }
    }
}