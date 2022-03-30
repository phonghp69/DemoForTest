using backend.DTO;
using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentService _service;
        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<List<AssignmentDTO>> GetAllAssignment()
        {
            return await _service.GetAllAssignment();
        }

        [HttpGet("user")]
        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            return await _service.GetAssignmentByUserId(userId);
        }
    }
}