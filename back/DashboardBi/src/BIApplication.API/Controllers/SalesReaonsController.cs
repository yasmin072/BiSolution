using BIApplication.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers;
[Route("api/salesReaons")]
[ApiController]
public class SalesReaonsController : ControllerBase
{
    private readonly ISalesReasonService _salesReasonService;

    public SalesReaonsController(ISalesReasonService salesReasonService)
    {
        _salesReasonService = salesReasonService;
    }

    [HttpGet("TotalLineByCategory")]
    public async Task<IActionResult> GetSalesReaonsByCategoryAsync()
    {
        var result = await _salesReasonService.GetLineTotalByCategoryAndReasonAsync();
        return Ok(result);
    }
    [HttpGet("TotalLineBySubCategory")]
    public async Task<IActionResult> GetLineTotalBySubCategoryAndReasonAsync()
    {
        var result = await _salesReasonService.GetLineTotalBySubCategoryAndReasonAsync();
        return Ok(result);
    }
    [HttpGet("TotalLineByProduct")]
    public async Task<IActionResult> GetLineTotalByProductAndReason()
    {
        var result = await _salesReasonService.GetLineTotalByProductAndReasonAsync();
        return Ok(result);
    }
    [HttpGet("TotalLineByTerritory")]
    public async Task<IActionResult> GetLineTotalByTerritoryAndReason()
    {
        var result = await _salesReasonService.GetLineTotalByTerritoryAndReasonAsync();
        return Ok(result);
    }
}