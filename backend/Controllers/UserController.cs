using Microsoft.AspNetCore.Mvc;
using backend.Authorization;
using backend.Entities;
using backend.Models.Users;
using backend.Interfaces;
using backend.Enums;
using backend.Authorization;
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

        [HttpGet("all")]
        public async Task<List<UserDTO>> GetAllUser()
        {
            return await _service.GetAllUser();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            return await _service.GetUserById(id);
        }
    }
}