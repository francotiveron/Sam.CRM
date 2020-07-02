using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sam.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sam.Core.Models;

namespace Sam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public ResetPasswordController(IAuthenticationService userService)
        {
            _service = userService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangePasswordModel model)
        {
            var response = await _service.ResetPassword(model);
            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserLoginRequest model)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            model.IpAddress = ip;
            var response = await _service.RequestResetPassword(model);
            if (!response.IsSuccessful)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}