using BIApplication.Application.services;
using BIApplication.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers.global;

[Route("api/cube")]
[ApiController]
public class CubeController : ControllerBase

{
    private readonly IGlobalAnalysisService globalAnalysisService;

    public CubeController(IGlobalAnalysisService service)
    {
        globalAnalysisService = service;
    }

    [HttpGet("sales-bikes")]
    public async Task<IActionResult> GetSalesByBikes()
    {
        var result = await globalAnalysisService.GetSalesByBikesAsync();
        return Ok(result);
    }
}