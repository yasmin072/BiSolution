using BIApplication.Core.models.orders;

namespace BIApplication.Core.interfaces;

public interface IOrdersService
{
    Task<List<OrderCountDto>> GetOrdersCountAsync();

    Task<List<OrderFlagDto>> GetOrderFlagsAsync();
}