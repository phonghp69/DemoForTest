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
        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] AssignmentDTO assignment)
        {
            return await _service.AddAssignment(assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AssignmentDTO assignment)
        {
            return await _service.UpdateAssignment(assignment,id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            return await _service.DeleteAssignment(id);
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