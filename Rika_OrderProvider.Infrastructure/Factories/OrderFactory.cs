using Rika_OrderProvider.Infrastructure.Data.Entities;
using Rika_OrderProvider.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rika_OrderProvider.Infrastructure.Factories;

public static class OrderFactory
{
    public static OrderEntity CreateOrderEntity(OrderModel orderModel, string orderAddressId, string orderCustomerId)
    {
        return new OrderEntity
        {
            TotalAmount = orderModel.TotalAmount,
            PaymentMethod = orderModel.PaymentMethod,
            ShipmentMethod = orderModel.ShipmentMethod,
            OrderAddressId = orderAddressId,
            OrderCustomerId = orderCustomerId,
            OrderProducts = orderModel.OrderProducts.Select(x => new OrderProductEntity
            {
                ArticleNumber = x.ArticleNumber,
                Quantity = x.Quantity,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Color = x.Color,
                Size = x.Size
            }).ToList()
        };
    }


    public static GetOrderModel GetOrderModel(OrderEntity orderEntity)
    {
        return new GetOrderModel
        {
            OrderId = orderEntity.OrderId,
            OrderDate = orderEntity.OrderDate,
            TotalAmount = orderEntity.TotalAmount,
            PaymentMethod = orderEntity.PaymentMethod,
            ShipmentMethod = orderEntity.ShipmentMethod,
            OrderStatus = orderEntity.OrderStatus,
            OrderCustomer = new OrderCustomerModel
            {
                CustomerName = orderEntity.OrderCustomer.CustomerName,
                CustomerEmail = orderEntity.OrderCustomer.CustomerEmail,
                CustomerPhone = orderEntity.OrderCustomer.CustomerPhone
            },
            OrderAddress = new OrderAddressModel
            {
                Address = orderEntity.OrderAddress.Address,
                City = orderEntity.OrderAddress.City,
                PostalCode = orderEntity.OrderAddress.PostalCode,
                Country = orderEntity.OrderAddress.Country
            },
            OrderProducts = orderEntity.OrderProducts.Select(op => new OrderProductModel
            {
                ArticleNumber = op.ArticleNumber,
                ProductName = op.ProductName,
                UnitPrice = op.UnitPrice,
                Quantity = op.Quantity,
                Color = op.Color,
                Size = op.Size,
            }).ToList()
        };
    }
}
