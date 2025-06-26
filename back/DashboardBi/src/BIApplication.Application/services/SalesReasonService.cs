using System.Text.Json;
using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models.salesReason;
using BIApplication.Infrastructure.Data;

namespace BIApplication.Application.services;

public class SalesReasonService : ISalesReasonService
{
    private readonly ICubeRepository _cubeRepository;

    public SalesReasonService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;
    }

    public async Task<List<LineTotalByCategoryAndReasonDto>> GetLineTotalByCategoryAndReasonAsync()
    {
        {
            var columnMappings = new Dictionary<string, string>
            {
                { "CategoryName", "[Product1].[Product Category ID].[Product Category ID].[MEMBER_CAPTION]" },
                { "SalesReasonName", "[Sales Reason].[Name].[Name].[MEMBER_CAPTION]" }
            };

            return await _cubeRepository.ExecuteMdxQueryAsync<LineTotalByCategoryAndReasonDto>(
                SalesReaonsMdxQueries.GetLineTotalByCategoryAndReason, columnMappings);

        }
        
    }
    public async Task<List<LineTotalBySubCategoryAndReasonDto>> GetLineTotalBySubCategoryAndReasonAsync()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "SubCategoryName", "[Product1].[Product Subcategory ID].[Product Subcategory ID].[MEMBER_CAPTION]" },
            { "SalesReasonName", "[Sales Reason].[Name].[Name].[MEMBER_CAPTION]" }
        };

        return await _cubeRepository.ExecuteMdxQueryAsync<LineTotalBySubCategoryAndReasonDto>(
            SalesReaonsMdxQueries.GetLineTotalBySubCategoryAndReason, columnMappings);
    }
    public async Task<List<LineTotalByProductAndReasonDto>> GetLineTotalByProductAndReasonAsync()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "ProductName", "[Product1].[Product ID].[Product ID].[MEMBER_CAPTION]" },
            { "SalesReasonName", "[Sales Reason].[Name].[Name].[MEMBER_CAPTION]" }
        };

        return await _cubeRepository.ExecuteMdxQueryAsync<LineTotalByProductAndReasonDto>(
            SalesReaonsMdxQueries.GetLineTotalByProductAndReason, columnMappings);
    }
    public async Task<List<LineTotalByTerritoryAndReasonDto>> GetLineTotalByTerritoryAndReasonAsync()
    {
        var columnMappings = new Dictionary<string, string>
        {
            { "TerritoryName", "[Territory].[Name].[Name].[MEMBER_CAPTION]" },
            { "SalesReasonName", "[Sales Reason].[Name].[Name].[MEMBER_CAPTION]" }
        };
        var results =    await _cubeRepository.ExecuteMdxQueryAsync<LineTotalByTerritoryAndReasonDto>(
            SalesReaonsMdxQueries.GetLineTotalByTerritoryAndReason, columnMappings);
        return results;
    }
    
}