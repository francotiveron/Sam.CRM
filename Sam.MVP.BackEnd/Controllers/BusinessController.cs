using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sam.Core.Models.Domain;
using Sam.Core.Service.Interfaces;

namespace Sam.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _service;
        private readonly IContextService _contextService;
        private readonly ILogger<BusinessController> _log;

        public BusinessController(IBusinessService service, IContextService contextService, ILogger<BusinessController> log)
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
        public async Task<IActionResult> GetAll()
        {
            var businessId = _contextService.GetBusinessId(HttpContext);
            try
            {
                var response = await _service.GetAll(businessId);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] BusinessModel model)
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
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] BusinessModel model)
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
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _service.Delete(id);

                if (!response.IsSuccessful)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}