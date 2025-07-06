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
    [HttpGet("totalDueByYear")]
    public async Task<IActionResult> GetSalesByTotalDueByYearAsync()
    {
        var result = await globalAnalysisService.GetSalesByTotalDueByYearAsync();
        return Ok(result);
    }
    [HttpGet("totalDueByMonth")]
    public async Task<IActionResult> GetSalesByTotalDueByMonthAsync()
    {
        var result = await globalAnalysisService.GetSalesByTotalDueByMonthAsync();
        return Ok(result);
        
    }
    [HttpGet("Total-Clients")]
    public async Task<IActionResult> GetTotalClients()
    {
        var result = await globalAnalysisService.GetTotalClientsAsync();
        return Ok(result);
    }
   /* [HttpGet("Total-Offers")]
    public async Task<IActionResult> GetTotalOffresSpecials()
    {
        var result = await globalAnalysisService.GetTotalOffresSpecialsAsync();
        return Ok(result);
    }*/
}