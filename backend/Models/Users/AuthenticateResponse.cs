using backend.Entities;
using backend.Enums;

namespace backend.Models.Users
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public bool IsFistLogin { get; set; }
        public string? StaffCode{get;set;}
        public DateTime JoindedDate { get; set; }
        public DateTime DateOfBirth{get;set;}
        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Role = user.Role;
            Token = token;
            IsFistLogin = user.IsFirstLogin;
            StaffCode = user.StaffCode;
            JoindedDate = user.JoindedDate;
            DateOfBirth = user.DateOfBirth;

        }
    }
}