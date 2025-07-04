using BIApplication.Core.models.product;

namespace BIApplication.Core.interfaces;

public interface IGlobalAnalysisService
{
  //  public async Task<List<BikeCategProductsDto>> GetSalesByBikesAsync();

  Task<List<BikeCategProductsDto>> GetSalesByBikesAsync(); 
  
  Task<List<TotalDueByYear>> GetSalesByTotalDueByYearAsync();
  Task<List<TotalDueByMonth>> GetSalesByTotalDueByMonthAsync();
  Task<List<TotalClients>> GetTotalClientsAsync();
 // Task<List<TotalOffres>> GetTotalOffresSpecialsAsync();
  //Task<List>GetBikesAsync();
}