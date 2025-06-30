using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models.product;
using BIApplication.Infrastructure.Data;
using Microsoft.AnalysisServices.AdomdClient;

namespace BIApplication.Application.services;

public class GlobalAnalysisService : IGlobalAnalysisService
{
    private readonly ICubeRepository _cubeRepository;
    public GlobalAnalysisService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository ?? throw new ArgumentNullException(nameof(cubeRepository));
    }

    public async Task<List<BikeCategProductsDto>> GetSalesByBikesAsync()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "totalline", "[Measures].[Line Total]" },
            //{ "categoryName", "[Product1].[Product Category ID].[MEMBER_CAPTION]" } // À ajuster
            {"categoryName", "[Product1].[Product Category ID].[Product Category ID].[MEMBER_CAPTION]" }
             // À ajuster
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<BikeCategProductsDto>(MdxQueries.GetSalesByBikesAsync, columnMappings);
    }

    public async Task<List<TotalDueByYear>> GetSalesByTotalDueByYearAsync()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "year", "[Dim Date].[Year].[Year].[MEMBER_CAPTION]" },
            { "TerritoryName", "[Territory].[Name].[Name].[MEMBER_CAPTION]" },
            { "TotalDue", "[Measures].[Total Due]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<TotalDueByYear>(MdxQueries.totalDueYear, columnMapping);
    }
    public async Task<List<TotalDueByMonth>> GetSalesByTotalDueByMonthAsync()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "TerritoryName", "[Territory].[Name].[Name].[MEMBER_CAPTION]" },
          
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<TotalDueByMonth>(MdxQueries.totalDueMonth, columnMapping);
    }
    
    


    // Exemple pour une autre requête
    /*public async Task<List<TotLineSubCatSalesReason>> GetTotLineSubCatSalesReasonAsync()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "TotalLine", "[Measures].[Line Total]" },
            { "ProductSubCategory", "[Product].[Product Subcategory].[Product Subcategory].[MEMBER_CAPTION]" },
            { "SalesReason", "[Sales Reason].[Sales Reason].[Name].[MEMBER_CAPTION]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<TotLineSubCatSalesReason>(MdxQueries.GetTotLineSubCatSalesReason, columnMappings);
    }*/

}

