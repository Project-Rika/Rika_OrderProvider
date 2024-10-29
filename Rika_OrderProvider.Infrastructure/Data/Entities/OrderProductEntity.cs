using System.ComponentModel.DataAnnotations;

namespace Rika_OrderProvider.Infrastructure.Data.Entities;

public class OrderProductEntity
{
    [Key]
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string UnitPrice { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
}