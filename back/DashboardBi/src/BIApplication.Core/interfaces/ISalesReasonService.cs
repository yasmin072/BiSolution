using BIApplication.Core.models.salesReason;

namespace BIApplication.Core.interfaces;

public interface ISalesReasonService
{
    Task<List<LineTotalByCategoryAndReasonDto>> GetLineTotalByCategoryAndReasonAsync();
    Task<List<LineTotalBySubCategoryAndReasonDto>> GetLineTotalBySubCategoryAndReasonAsync();
    Task<List<LineTotalByProductAndReasonDto>> GetLineTotalByProductAndReasonAsync();
    Task<List<LineTotalByTerritoryAndReasonDto>> GetLineTotalByTerritoryAndReasonAsync();
    Task<List<TotalLineBySalesReasonDto>> GetTotalLineBySalesReasonAsync();

}