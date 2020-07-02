using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sam.Core.Models;
using Sam.Core.Service.Interfaces;

namespace Sam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public ChangePasswordController(IAuthenticationService userService)
        {
            _service = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ChangePasswordModel model)
        {
            var response = await _service.ChangePassword(model);
            if (!response.IsSuccessful)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}