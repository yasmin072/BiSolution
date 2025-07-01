//using BIApplication.Core.models.product;
using BIApplication.Core.models.territory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIApplication.Core.interfaces
{
    public interface ITerritoryService
    {
       Task<List<TerritoryCountDto>> GetTotalTerritoriesAsync();
        Task<List<TotalVenteByTerritoryPlacedByCustomerDto>> GetTotalventeByTerrPlacedByCustomerAsync();
        Task<List<TotalLineByTerritoryDto>> GetTotalLineByTerritoryAsync();

        // Task<List<TotalVenteByTerritoryGroupDto>> GetTotalVenteByTerritoryGroupAsync(); // Nouvelle méthode
    }
}
