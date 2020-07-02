using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Sam.Core.Utils;
using Sam.Core.Models.Domain;
using Sam.Core.Models;
using Sam.Core.Service.Interfaces;
using Sam.Core.Service.Interfaces.Domain;

namespace Sam.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _service;
        private readonly IContextService _contextService;
        private readonly ILogger<UserPermissionController> _log;

        public UserPermissionController(IUserPermissionService service, IContextService contextService, ILogger<UserPermissionController> log)
        {
            _service = service;
            _contextService = contextService;
            _log = log;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            if (result == null)
            {
                _log.LogWarning($"Cannot find BusinessModel by id={id}");
                return NotFound($"Cannot find BusinessModel by id={id}");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]Guid userid)
        {
            var businessId = _contextService.GetBusinessId(HttpContext);
            try
            {
                var response = await _service.GetAll(userid);
                return Ok(response);
            }
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] UserPermissionModel model)
        {
            try
            {
                var response = await _service.Add(model);

                if (!response.IsSuccessful)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UserPermissionModel model)
        {
            try
            {
                var response = await _service.Update(model);

                if (!response.IsSuccessful)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id, [FromBody] UserPermissionModel model)
        {
            try
            {
                var response = await _service.Remove(model);

                if (!response.IsSuccessful)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}