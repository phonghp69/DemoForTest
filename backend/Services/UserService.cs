using backend.Data;
using backend.DTO;
using backend.Helpers;
using backend.Interfaces;
using backend.Models.Users;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _context;

        private readonly IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        public UserService
        (
            MyDbContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings
        )
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public UserService()
        {
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

            //validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                throw new AppException("Username or password is incorrect");
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticateResponse(user, tokenHandler.WriteToken(token));
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
    }
}