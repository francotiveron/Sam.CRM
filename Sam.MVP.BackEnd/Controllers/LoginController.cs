using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sam.Core.Models;
using Sam.Core.Service.Interfaces;

namespace Sam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowAll")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _userService;

        public LoginController(IAuthenticationService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserLoginRequest model)
        {
            var ip = HttpContext.Connection.RemoteIpAddress;

            model.IpAddress = ip.ToString();
            var response = await _userService.Login(model);
            if (!response.IsSuccessful)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}