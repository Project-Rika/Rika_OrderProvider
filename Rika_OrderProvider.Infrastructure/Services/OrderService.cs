using Rika_OrderProvider.Infrastructure.Data.Entities;
using Rika_OrderProvider.Infrastructure.Data.Repositories;
using Rika_OrderProvider.Infrastructure.Factories;
using Rika_OrderProvider.Infrastructure.Helpers;
using Rika_OrderProvider.Infrastructure.Models;
using Rika_OrderProvider.Infrastructure.Services.Interfaces;
using System.Diagnostics;

namespace Rika_OrderProvider.Infrastructure.Services;



public class OrderService : IOrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly OrderAddressRepository _orderAddressRepository;
    private readonly OrderCustomerRepository _orderCustomerRepository;
    public OrderService(OrderRepository orderRepository, OrderAddressRepository orderAddressRepository, OrderCustomerRepository orderCustomerRepository)
    {
        _orderRepository = orderRepository;
        _orderAddressRepository = orderAddressRepository;
        _orderCustomerRepository = orderCustomerRepository;
    }

    public async Task<ResponseResult> CreateOrderAsync(OrderModel orderModel)
    {
        try
        {
            var orderAddressId = await GetOrCreateOrderAddress(orderModel.OrderAddress.Address, orderModel.OrderAddress.City, orderModel.OrderAddress.PostalCode, orderModel.OrderAddress.Country);
            if (orderAddressId == null)
            {
                return ResponseFactory.Error("Error creating order address");
            }

            var orderCustomerId = await GetOrCreateOrderCustomer(orderModel.OrderCustomer.CustomerName, orderModel.OrderCustomer.CustomerEmail, orderModel.OrderCustomer.CustomerPhone);
            if (orderCustomerId == null)
            {
                return ResponseFactory.Error("Error creating order customer");
            }

            var createdOrder = await _orderRepository.CreateAsync(OrderFactory.CreateOrderEntity(orderModel, orderAddressId, orderCustomerId));
            return createdOrder != null ? ResponseFactory.Ok(createdOrder) : ResponseFactory.Error("Error creating order");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseFactory.Error("Something went wrong, please try again");
        }
    }

    private async Task<string> GetOrCreateOrderAddress(string address, string city, string postalCode, string country) 
    {
        try
        {
            var orderAddress = await _orderAddressRepository.GetOneAsync(x => x.Address == address && x.PostalCode == postalCode);
            if (orderAddress != null)
            {
                return orderAddress.OrderAddressId;
            }
            else
            {
                var addressTest = new OrderAddressEntity { Address = address, City = city, PostalCode = postalCode, Country = country };
                var createdOrderAddress = await _orderAddressRepository.CreateAsync(addressTest);
                if (createdOrderAddress != null)
                {
                    return createdOrderAddress.OrderAddressId;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return null!;

    }

    private async Task<string> GetOrCreateOrderCustomer(string name, string email, string phone)
    {
        try
        {
            var orderCustomer = await _orderCustomerRepository.GetOneAsync(x => x.CustomerName == name && x.CustomerEmail == email && x.CustomerPhone == phone);
            if (orderCustomer != null)
            {
                return orderCustomer.OrderCustomerId;
            }
            else
            {
                var createdOrderCustomer = await _orderCustomerRepository.CreateAsync(new OrderCustomerEntity { CustomerName = name, CustomerEmail = email, CustomerPhone = phone });
                if (createdOrderCustomer != null)
                {
                    return createdOrderCustomer.OrderCustomerId;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return null!;

    }

    public Task<ResponseResult> DeleteOrderAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseResult> GetAllOrdersAsync()
    {
        var result = await _orderRepository.GetAllAsync();

        return result.Count > 0 ? ResponseFactory.Ok(result.Select(OrderFactory.GetOrderModel).ToList()) : ResponseFactory.NotFound();
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
