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
        public async Task<List<Assignment>> GetAllAssignment()
        {
            return await _service.GetAllAssignment();
        }
    }
}