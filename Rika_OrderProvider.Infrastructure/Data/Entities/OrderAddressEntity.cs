using System.ComponentModel.DataAnnotations;

namespace Rika_OrderProvider.Infrastructure.Data.Entities;

public class OrderAddressEntity
{
    [Key]
    public string OrderAddressId { get; set; } = Guid.NewGuid().ToString();
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ICollection<OrderEntity> Orders { get; set; } = [];
}