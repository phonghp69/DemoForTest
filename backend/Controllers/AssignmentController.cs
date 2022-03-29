using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class AssignmentController : Controller
    {
        private IAssignmentService _service;
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger, IAssignmentService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<List<Assignment>> GetAllCategory()
        {
            return await _service.GetAllAssignment();
        }
    }
}