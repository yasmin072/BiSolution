using BIApplication.Core.interfaces;
using BIApplication.Core.models.product;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductAnalysisService _productAnalysisService;

    public ProductController(IProductAnalysisService productAnalysisService)
    {
        _productAnalysisService = productAnalysisService;
    }

    [HttpGet("shipped")]
    public async Task<IActionResult> GetShippedProducts()
    {
        var result = await _productAnalysisService.GetTotalShippedProducts();
        return Ok(result);
    }

    [HttpGet("top3ProdByTotalDue")]
    public async Task<IActionResult> GetTop3ProdTotalDue()
    {
        var result = await _productAnalysisService.GetTop3ProdTotalDue();
        return Ok(result);
    }

    [HttpGet("top3ProdByTotalLine")]
    public async Task<IActionResult> GetTop3ProdTotalLine()
    {
        var result = await _productAnalysisService.GetTop3ProdTotalLine();
        return Ok(result);
    }
    [HttpGet("totalProduct")]
    public async Task<IActionResult> GetProductCounts()
    {
        var result = await _productAnalysisService.GetProductCounts();
        return Ok(result);
    }
    
    [HttpGet("order-qty-by-year-month")]
    public async Task<ActionResult<List<QtyOrderByYearMonth>>> GetQtyCommandeeByYearMonth()
    {
        var result = await _productAnalysisService.GetOrderQtyByProdCatByYearMonth();
        return Ok(result);
    }
}