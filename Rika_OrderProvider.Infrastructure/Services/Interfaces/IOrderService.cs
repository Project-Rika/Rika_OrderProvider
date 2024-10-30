using Rika_OrderProvider.Infrastructure.Helpers;
using Rika_OrderProvider.Infrastructure.Models;

namespace Rika_OrderProvider.Infrastructure.Services.Interfaces;

public interface IOrderService
{
    Task<ResponseResult> CreateOrderAsync (OrderModel orderModel);
    Task<ResponseResult> GetOneOrderAsync(Guid orderId);
    Task<ResponseResult> GetAllOrdersAsync();
    Task<ResponseResult> UpdateOrderAsync(Guid orderId, OrderModel orderModel);
    Task<ResponseResult> DeleteOrderAsync(Guid orderId);

}
