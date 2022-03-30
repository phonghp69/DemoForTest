using backend.Data;
using backend.Utilities;
using backend.Interfaces;
using backend.Helpers;
using backend.Models.Users;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using backend.DTO;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _context;

        private readonly IJwtUtils _jwtUtils;
        private readonly AppSetting _appSetting;
        public UserService
        (
            MyDbContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSetting> appSetting
        )
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSetting = appSetting.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

            //validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                throw new AppException("Username or password is incorrect");
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken);
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
    }
}