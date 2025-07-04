using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models.territory;
using BIApplication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIApplication.Application.services
{
    public class TerritoryService : ITerritoryService
    {
        private readonly ICubeRepository _cubeRepository;

        public TerritoryService(ICubeRepository cubeRepository)
        {
            _cubeRepository = cubeRepository ?? throw new ArgumentNullException(nameof(cubeRepository));
        }

        public async Task<List<TerritoryCountDto>> GetTotalTerritoriesAsync()
        {
            var columnMappings = new Dictionary<string, string>
            {
                { "TotalTerritory", "[Measures].[Nbre de territoires]" }
            };
            return await _cubeRepository.ExecuteMdxQueryAsync<TerritoryCountDto>(TerritoryMdxQueries.GetTotalTerritoriesAsync, columnMappings);
        }

        public async Task<List<TotalVenteByTerritoryPlacedByCustomerDto>> GetTotalventeByTerrPlacedByCustomerAsync()
        {
            var columnMappings = new Dictionary<string, string>
            {
                { "totalLine", "[Measures].[Line Total - Sum]"},
                { "TerritoryName", "[Territory].[Name].[Name].[MEMBER_CAPTION]" }

                // Seulement la mesure, sans [Measures]. préfixe
                // TerritoryName est mappé via l'axe des lignes
                // PlacedByCustomer est statique à 1
            };
            return await _cubeRepository.ExecuteMdxQueryAsync<TotalVenteByTerritoryPlacedByCustomerDto>(
                TerritoryMdxQueries.GetTotalventeByTerrPlacedByCustomerAsync, columnMappings);
        }

        public async Task<List<TotalLineByTerritoryDto>> GetTotalLineByTerritoryAsync()
        {
            var columnMappings = new Dictionary<string, string>
            {
                { "territoryName", "[Territory].[Name].[Name].[MEMBER_CAPTION]" },
                { "totalLine", "[Measures].[Line Total]" }
                

            };
            return await _cubeRepository.ExecuteMdxQueryAsync<TotalLineByTerritoryDto>(TerritoryMdxQueries.TotalLineByTerritory, columnMappings);

        }
        public async Task<List<TotalLineSumParGroupe>> GetTotalSumParGroupe()
        {
            var columnMapping = new Dictionary<string, string>
            {
                { "TotalSum", "[Measures].[Line Total - Sum]" },
                { "Groupe", "[Territory].[Name].[Name].[MEMBER_CAPTION]" }
            };
            return await _cubeRepository.ExecuteMdxQueryAsync<TotalLineSumParGroupe>(TerritoryMdxQueries.GetTotalSumParGroupeAsync, columnMapping);
        }

        /*  public async Task<List<TotalVenteByTerritoryGroupDto>> GetTotalVenteByTerritoryGroupAsync()
          {
              var columnMappings = new Dictionary<string, string>
      {
          { "LineTotalSum", "[Measures].[Line Total - Sum]" } // Seulement la mesure, TerritoryGroup est mappé via l'index
      };
              return await _cubeRepository.ExecuteMdxQueryAsync<TotalVenteByTerritoryGroupDto>(TerritoryMdxQueries.GetTotalVenteByTerritoryGroupAsync, columnMappings);
          }*/
    
}
}