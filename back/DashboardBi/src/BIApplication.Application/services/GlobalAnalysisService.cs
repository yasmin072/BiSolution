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

