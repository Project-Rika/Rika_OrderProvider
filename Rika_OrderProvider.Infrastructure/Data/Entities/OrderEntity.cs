using System.ComponentModel.DataAnnotations;

namespace Rika_OrderProvider.Infrastructure.Data.Entities;

public class OrderEntity
{
    [Key]
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string TotalAmount { get; set; } = string.Empty;
    public string PaymnetMehod { get; set; } = string.Empty;
    public string ShipmentMethod { get; set; } = string.Empty;

    public string OrderCustomerId { get; set; } = null!;
    public OrderCustomerEntity OrderCustomer { get; set; } = null!;

    public string OrderAddressId { get; set; } = null!;
    public OrderAddressEntity OrderAddress { get; set; } = null!;

    public ICollection<OrderProductEntity> OrderProducts { get; set; } = [];

}