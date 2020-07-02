using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using Sam.Core.Models;
using Sam.Core.Models.Domain;
using Sam.Core.Service.Interfaces;

namespace Sam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowAll")]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        private readonly IBusinessUserService _userService;
        public RegisterController(IAuthenticationService service, IBusinessUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserRegisterRequest model)
        {
            model.Role = "Admin";
            var response = await _service.Register(model);
            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }

            var bu = Mapper.Map<UserRegisterRequest, BusinessUserModel>(model);
            await _userService.Add(bu);
            return Ok(response);
        }
    }
}