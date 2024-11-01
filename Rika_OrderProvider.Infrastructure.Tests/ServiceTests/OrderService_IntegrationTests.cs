using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Rika_OrderProvider.Infrastructure.Data.Contexts;
using Rika_OrderProvider.Infrastructure.Data.Entities;
using Rika_OrderProvider.Infrastructure.Data.Repositories;
using Rika_OrderProvider.Infrastructure.Models;
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

    private async void SeedDatabase()
    {
        var orderCustomer = new OrderCustomerEntity()
        {
            CustomerEmail = "hej@hej.se",
            CustomerName = "John Doe",
            CustomerPhone = "1234567"
        };

        var orderAddress = new OrderAddressEntity()
        {
            Address = "vägvägen 1",
            City = "Malmö",
            PostalCode = "123 45",
            Country = "Sweden"
        };

        var orderProducts = new List<OrderProductEntity>
        {
            new() 
            {
                ArticleNumber = "1",
                ProductName = "Product 1",
                UnitPrice = "50",
                Quantity = "2",
                Color = "Red",
                Size = "M"
            },
            new()
            {
                ArticleNumber = "2",
                ProductName = "Product 1",
                UnitPrice = "50",
                Quantity = "2",
                Color = "Red",
                Size = "M"
            }
        };

        _dbContext.OrderCustomers.Add(orderCustomer);
        _dbContext.OrderAddresses.Add(orderAddress);
        await _dbContext.SaveChangesAsync();

        var order = new OrderEntity()
        {
            TotalAmount = "200",
            PaymentMethod = "Card",
            ShipmentMethod = "DHL",
            OrderCustomerId = orderCustomer.OrderCustomerId,
            OrderAddressId = orderAddress.OrderAddressId,
            OrderProducts = orderProducts
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
    }


    [Fact]
    public async Task CreateOrder_ShouldCreateOrder_AndReturnOK()
    {
        // Arrange
        var orderModel = new OrderModel
        {
            TotalAmount = "600",
            PaymentMethod = "Card",
            ShipmentMethod = "DHL",
            OrderCustomer = new Models.OrderCustomerModel
            {
                CustomerName = "Emil",
                CustomerEmail = "emil@domain.com",
                CustomerPhone = "0701234567"
            },
            OrderAddress = new Models.OrderAddressModel
            {
                Address = "street 1",
                City = "city",
                PostalCode = "123 45",
                Country = "sweden"
            },
            OrderProducts =
            [
               new() {
                   ArticleNumber = "112233",
                   ProductName = "jacket",
                   UnitPrice = "200",
                   Quantity = "1",
                   Color = "black",
                   Size = "m"
            },
               new() {
                   ArticleNumber = "225566",
                   ProductName = "shoes",
                   UnitPrice = "400",
                   Quantity = "1",
                   Color = "white",
                   Size = "44"
               }
            ]
        };

        // Act
        var result = await _orderService.CreateOrderAsync(orderModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("OK", result.StatusCode.ToString());
    }

    [Fact]
    public async Task CreateOrder_ShouldNotCreateOrder_AndReturnError()
    {
        // Arrange
        var orderModel = new OrderModel
        {
            TotalAmount = "600",
            PaymentMethod = "Card",
            ShipmentMethod = "DHL",
            OrderCustomer = new Models.OrderCustomerModel
            {
                CustomerName = "Emil",
                CustomerEmail = "emil@domain.com",
                CustomerPhone = "0701234567"
            },
            OrderProducts =
            [
               new() {
                   ArticleNumber = "112233",
                   ProductName = "jacket",
                   UnitPrice = "200",
                   Quantity = "1",
                   Color = "black",
                   Size = "m"
            },
               new() {
                   ArticleNumber = "225566",
                   ProductName = "shoes",
                   UnitPrice = "400",
                   Quantity = "1",
                   Color = "white",
                   Size = "44"
               }
            ]
        };

        // Act
        var result = await _orderService.CreateOrderAsync(orderModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("ERROR", result.StatusCode.ToString());
    }


    [Fact]
    public async Task GetAllOrders_ShouldReturnOrders_InList()
    {
        //arrange

        //Act
        var result = await _orderService.GetAllOrdersAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Equal("OK", result.StatusCode.ToString());
    }
}
