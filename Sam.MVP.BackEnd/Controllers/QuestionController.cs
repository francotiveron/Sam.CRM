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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        private readonly IContextService _contextService;
        private readonly ILogger<QuestionController> _log;

        public QuestionController(IQuestionService service, IContextService contextService, ILogger<QuestionController> log)
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
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] QuestionModel model)
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
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] QuestionModel model)
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
            catch(Exception x)
            {
                _log.LogError(ExceptionLogger.ExceptionDetails(x));
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}