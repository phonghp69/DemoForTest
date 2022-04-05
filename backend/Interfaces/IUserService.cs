using backend.DTO;
using backend.Entities;
using backend.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        public Task<IActionResult> AddUser(UserDTO user);
        public Task<IActionResult> UpdateUser(int id, UserDTO user);
        public Task<IActionResult> DeleteUser(int id);
        public Task ChangePasswordFirstLogin(FirstLogin login);
        public Task ChangePassWord(ChangePassword changePassword);
        public Task<List<UserDTO>> GetAllUser();
        public Task<UserDTO> GetUserById(int id);
    }
}