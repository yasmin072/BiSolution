using BIApplication.Core.models.product;

namespace BIApplication.Core.interfaces;

public interface IProductAnalysisService
{
    Task<List<TotalShippedProduct>> GetTotalShippedProducts();
    Task<List<Top3ProdTotalDue>> GetTop3ProdTotalDue();
    Task<List<Top3ProdTotalLine>> GetTop3ProdTotalLine();
    Task<List<ProductCountDto>> GetProductCounts();
    Task<List<QtyOrderByYearMonth>> GetOrderQtyByProdCatByYearMonth();
}