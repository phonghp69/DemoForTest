using backend.DTO;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReturningRequestController : ControllerBase
    {
        private IReturningRequestService _service;
        public ReturningRequestController(IReturningRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddReturningRequest([FromBody] ReturningRequestDTO ReturningRequest)
        {
            return await _service.AddReturningRequest(ReturningRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReturningRequest(int id, [FromBody] ReturningRequestDTO ReturningRequest)
        {
            return await _service.UpdateReturningRequest(id, ReturningRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturningRequest(int id)
        {
            return await _service.DeleteReturningRequest(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturningRequestDTO>> GetReturningRequest(int id)
        {
            return await _service.GetReturningRequest(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ReturningRequestDTO>>> GetAllReturningRequests()
        {
            return await _service.GetAllReturningRequests();
        }
    }
}