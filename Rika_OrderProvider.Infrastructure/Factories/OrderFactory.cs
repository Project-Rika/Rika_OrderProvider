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
            PaymnetMehod = orderModel.PaymnetMehod,
            ShipmentMethod = orderModel.ShipmentMethod,
            OrderAddressId = orderAddressId,
            OrderCustomerId = orderCustomerId,
            OrderProducts = orderModel.OrderProducts.Select(x => new OrderProductEntity
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Color = x.Color,
                Size = x.Size
            }).ToList()
        };
    }
}
