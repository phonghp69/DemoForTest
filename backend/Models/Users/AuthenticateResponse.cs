using backend.Entities;

namespace backend.Models.Users
{
    public class AuthenticateResponse
    {
        public string? UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string IsFistLogin {get;set;}
        public AuthenticateResponse(User user, string token)
        {
            UserName = user.UserName;
            Role = user.Role.ToString();
            Token = token;
            IsFistLogin = user.IsFirstLogin.ToString();
        }
    }
}