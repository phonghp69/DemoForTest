using backend.Models.Users;

namespace backend.Interfaces
{
    public interface IAuthenticateService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}