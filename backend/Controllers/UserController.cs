using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.Enums;
using backend.DTO;
using backend.Models.Users;
using backend.Authorization;
using backend.Entities;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IUserService _service;
        public UsersController(IUserService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            return await _service.AddUser(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO user)
        {
            return await _service.UpdateUser(id, user);
        }

        [HttpPut("/first-login")]
        public async Task ChangePasswordFirstLogin(FirstLogin login)
        {
            await _service.ChangePasswordFirstLogin(login);
        }

        [HttpPut("/change-password")]
        public async Task ChangePassword(ChangePassword changePassword)
        {
            await _service.ChangePassWord(changePassword);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await _service.DeleteUser(id);
        }

        [HttpGet("all")]
        public async Task<List<UserDTO>> GetAllUser()
        {
            return await _service.GetAllUser();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.UserId && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}