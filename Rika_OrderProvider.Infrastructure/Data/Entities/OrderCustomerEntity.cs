using System.ComponentModel.DataAnnotations;

namespace Rika_OrderProvider.Infrastructure.Data.Entities;

public class OrderCustomerEntity
{
    [Key]
    public string OrderCustomerId { get; set; } = Guid.NewGuid().ToString();
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public ICollection<OrderEntity> Orders { get; set; } = [];

}