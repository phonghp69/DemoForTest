using backend.Data;
using backend.Entities;
using backend.Interfaces;
using backend.Helpers;
using backend.Models.Users;
using Microsoft.Extensions.Options;


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

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}