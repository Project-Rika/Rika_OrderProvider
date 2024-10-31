﻿using Microsoft.EntityFrameworkCore;
using Rika_OrderProvider.Infrastructure.Data.Contexts;
using Rika_OrderProvider.Infrastructure.Data.Entities;
using Rika_OrderProvider.Infrastructure.Data.Repositories;
using Rika_OrderProvider.Infrastructure.Services;
using Rika_OrderProvider.Infrastructure.Services.Interfaces;

namespace Rika_OrderProvider.Infrastructure.Tests.ServiceTests;

public class OrderService_IntegrationTests
{
    private readonly OrderService _orderService;
    private readonly OrderDbContext _dbContext;
    public OrderService_IntegrationTests()
    {
        var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;
        _dbContext = new OrderDbContext(options);

        var orderRepository = new OrderRepository(_dbContext);
        var orderAddressRepository = new OrderAddressRepository(_dbContext);
        var orderCustomerRepository = new OrderCustomerRepository(_dbContext);

        _orderService = new OrderService(orderRepository, orderAddressRepository, orderCustomerRepository);

        SeedDatabase();

    }

    private void SeedDatabase()
    {
        var orderCustomer = new OrderCustomerEntity()
        {
            CustomerEmail = "hej@hej.se",
            CustomerName = "John Doe",
            CustomerPhone = "1234567"
        };

        var orderAddress = new OrderAddressEntity() {
            Address = "vägvägen 1",
            City = "Malmö",
            PostalCode = "123 45",
            Country = "Sweden"
        };

        var orderProducts = new List<OrderProductEntity>
        {
            new() {
                ArticleNumber = "1",
                ProductName = "Product 1",
                UnitPrice = "50",
                Quantity = "2"
            },
            new()
            {
                ArticleNumber = "2",
                ProductName = "Product 1",
                UnitPrice = "50",
                Quantity = "2"
            }
        };


        var order = new OrderEntity()
        {
            TotalAmount = "200",
            PaymentMethod = "Card",
            ShipmentMethod = "Dbl",
            OrderCustomerId = orderCustomer.OrderCustomerId,
            OrderAddressId = orderAddress.OrderAddressId,
            OrderProducts = orderProducts
        };

        _dbContext.Orders.Add(order);
        _dbContext.SaveChangesAsync();
    }






    [Fact]
    public async Task GetAllOrders_ShouldReturnOrders_InList()
    {
        //Arrange

        //Act
        var result = await _orderService.GetAllOrdersAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Equal("OK", result.StatusCode.ToString());
    }
}
