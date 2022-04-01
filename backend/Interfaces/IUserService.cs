using backend.DTO;
using backend.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Task<IActionResult> AddUser(UserDTO user);
        public Task<IActionResult> UpdateUser(int id, UserDTO user);
        public Task<IActionResult> DeleteUser(int id);
        public Task<List<UserDTO>> GetAllUser();
        public Task<UserDTO> GetUserById(int id);
    }
}