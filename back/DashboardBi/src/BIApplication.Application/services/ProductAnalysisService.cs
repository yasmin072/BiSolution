using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models.product;
using BIApplication.Infrastructure.Data;

namespace BIApplication.Application.services;

public class ProductAnalysisService : IProductAnalysisService
{
    private readonly ICubeRepository _cubeRepository;

    public ProductAnalysisService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;
    }

    public async Task<List<TotalShippedProduct>> GetTotalShippedProducts()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "TotalProduct", "[Measures].[Product ID Distinct Count]" },
            { "Status", "[Dim Status].[Status ID].[Status ID].[MEMBER_CAPTION]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<TotalShippedProduct>(ProductMdxQueries.GetTotalProductShipped, columnMappings);
        
    }

    public async Task<List<Top3ProdTotalDue>> GetTop3ProdTotalDue()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "ProductName", "[Product1].[Product ID].[Product ID].[MEMBER_CAPTION]" },
            { "TotalDue", "[Measures].[Total Due]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<Top3ProdTotalDue>(ProductMdxQueries.GetTop3ProdTotalDue, columnMapping);
    }
    public async Task<List<Top3ProdTotalLine>> GetTop3ProdTotalLine()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "ProductName", "[Product1].[Product ID].[Product ID].[MEMBER_CAPTION]" },
            { "TotalLine", "[Measures].[Line Total]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<Top3ProdTotalLine>(ProductMdxQueries.GetTop3ProdTotalLine, columnMapping);
    }

    public async Task<List<ProductCountDto>> GetProductCounts()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "ProductCount", "[Measures].[Product ID Distinct Count]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<ProductCountDto>(ProductMdxQueries.GetTotalProduct, columnMapping);
    }
    
}