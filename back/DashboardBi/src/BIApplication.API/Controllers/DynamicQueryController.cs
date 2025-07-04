using BIApplication.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers;


    [ApiController]
    [Route("api/buildMdx")]
    public class DynamicQueryController : ControllerBase
    {
        private readonly IDynamicQueryService _queryService;

        public DynamicQueryController(IDynamicQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("results")]
        public async Task<IActionResult> Get([FromQuery] string dimension, [FromQuery] string hierarchy, [FromQuery] string level, [FromQuery] string measure)
        {
            var result = await _queryService.GetDynamicResultsAsync(dimension, hierarchy, level, measure);
            return Ok(result);
        }
    }
