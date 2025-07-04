//using BIApplication.API.Controllers.global;
using BIApplication.Application.services;
using BIApplication.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIApplication.API.Controllers.Territories
{
    [Route("api/territory")]
    [ApiController]
    public class TerritoryController : Controller

    {
        private readonly ITerritoryService territoryService;

        public TerritoryController(ITerritoryService service)
        {
            territoryService = service;
        }

       [HttpGet("totalTerritories")]
        public async Task<IActionResult> GetTerritoriesCount()
        {
            var result = await territoryService.GetTotalTerritoriesAsync();
            return Ok(result);
        }


     
/*
        [HttpGet("totalvente-territoireGroup")]
        public async Task<IActionResult> GetTotalVenteByTerritoryGroup()
        {
            var result = await territoryService.GetTotalVenteByTerritoryGroupAsync();
            return Ok(result);
        }*/
        [HttpGet("totalvente/onlineOrders")]
        public async Task<IActionResult> GetTotalVenteByTerrByCustomer()
        {
            var result = await territoryService.GetTotalventeByTerrPlacedByCustomerAsync();
            return Ok(result);
        }
        [HttpGet("TotalLine")]
        public async Task<IActionResult> GetTotalLineByTerritoryAsync()
        {
            var result = await territoryService.GetTotalLineByTerritoryAsync();
            return Ok(result);
        }
        [HttpGet("sumTotalLine")]
        public async Task<IActionResult> GetTotalSumParGroupe()
        {
            var result = await territoryService.GetTotalSumParGroupe();
            return Ok(result);
        }

    }
}
