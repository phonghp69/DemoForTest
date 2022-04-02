using backend.Interfaces;
using backend.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateService _service;
        public AuthenticateController(IAuthenticateService service)
        {
            _service = service;
        }
        
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _service.Authenticate(model);
            return Ok(response);
        }
    }
}