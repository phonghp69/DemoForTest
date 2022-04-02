using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.Enums;
using backend.DTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            return await _service.AddUser(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO user)
        {
            return await _service.UpdateUser( id,user);
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

        // [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            // only admins can access other user records
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin.ToString()))
                return null;

            return await _service.GetUserById(id);
          
        }
    }
}