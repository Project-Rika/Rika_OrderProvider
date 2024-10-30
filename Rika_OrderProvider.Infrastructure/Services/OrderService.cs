using Rika_OrderProvider.Infrastructure.Data.Repositories;
using Rika_OrderProvider.Infrastructure.Factories;
using Rika_OrderProvider.Infrastructure.Helpers;
using Rika_OrderProvider.Infrastructure.Models;
using Rika_OrderProvider.Infrastructure.Services.Interfaces;

namespace Rika_OrderProvider.Infrastructure.Services;



public class OrderService : IOrderService
{
    private readonly OrderRepository _orderRepository;
    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<ResponseResult> CreateOrderAsync(OrderModel orderModel)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseResult> DeleteOrderAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseResult> GetAllOrdersAsync()
    {
        var result = await _orderRepository.GetAllAsync();

        return result.Count > 0 ? ResponseFactory.Ok(result) : ResponseFactory.NotFound();
    }

    public Task<ResponseResult> GetOneOrderAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseResult> UpdateOrderAsync(Guid orderId, OrderModel orderModel)
    {
        throw new NotImplementedException();
    }
}
