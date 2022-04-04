using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Models.Users;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            return await _context.Users.Select(x => x.UserEntityToDTO()).ToListAsync();
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser != null)
            {
                return foundUser.UserEntityToDTO();
            }
            return null;
        }

        public async Task<IActionResult> AddUser(UserDTO user)
        {
            if (_context.Users != null)
            {
                try
                {
                    await _context.Users.AddAsync(user.UserDTOToEntity());
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }

        public Task<IActionResult> UpdateUser(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ChangePasswordFirstLogin(FirstLogin login)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(x => x.UserName == login.UserName);
                if (foundUser != null && foundUser.IsFirstLogin == true)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(login.NewPassword);
                    foundUser.IsFirstLogin = false;

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ChangePassWord(ChangePassword changePassword)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(x => x.UserName == changePassword.UserName);
                if (foundUser != null && changePassword.NewPassword == changePassword.ConfirmPassword)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}