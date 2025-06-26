using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models.orders;
using BIApplication.Infrastructure.Data;

namespace BIApplication.Application.services;

public class OrderService : IOrdersService
{
    private readonly ICubeRepository _cubeRepository;

    public OrderService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;
    }

    public async Task<List<OrderCountDto>> GetOrdersCountAsync()
    {
        var columnMapping = new Dictionary<string, string>
        {
            { "TotalOrders", "[Measures].[Sales Order ID Distinct Count]" }
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<OrderCountDto>(OrdersMdxQueries.OrderCount, columnMapping);

    }

    public async Task<List<OrderFlagDto>> GetOrderFlagsAsync()
    {
        var columnMapping = new Dictionary<string, string>
        {
            {"OnlineOrderFlag","[Dim Online Order Flag].[Online Order Flag ID].[Online Order Flag ID].[MEMBER_CAPTION]"},
            {"OrderQty" , "[Measures].[Order Qty]"}
            
        };
        return await _cubeRepository.ExecuteMdxQueryAsync<OrderFlagDto>(OrdersMdxQueries.OrderFlagMdx, columnMapping);
    }
}