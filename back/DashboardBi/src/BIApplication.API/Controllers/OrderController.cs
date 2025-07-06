using BIApplication.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers;
[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrderController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }
    
    [HttpGet("totalOrders")]
    public async Task<IActionResult> GetTotalOrders()
    {
        var result = await _ordersService.GetOrdersCountAsync();
       return Ok(result);
    }
    [HttpGet("orderFlag")]
    public async Task<IActionResult> GetOnlineOrderFlagsAsync()
    {
        var result = await _ordersService.GetOrderFlagsAsync();
        
        return Ok(result);
    }
    [HttpGet("orderFlagByTerritory")]
    public async Task<IActionResult> GetOrderFlagsByTerritoryAsync()
    {
        var result = await _ordersService.GetOrderFlagsByTerritoryAsync();
        
        return Ok(result);
    }



}