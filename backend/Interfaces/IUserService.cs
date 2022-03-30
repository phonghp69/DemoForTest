using backend.DTO;
using backend.Models.Users;

namespace backend.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Task<List<UserDTO>> GetAllUser();
        public Task<UserDTO> GetUserById(int id);
    }
}