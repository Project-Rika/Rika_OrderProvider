using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rika_OrderProvider.Infrastructure.Data.Entities;


public class OrderProductEntity
{
    public string OrderId { get; set; } = null!;
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string UnitPrice { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;

  
    [ForeignKey("OrderId")]
    [JsonIgnore]
    public OrderEntity Order { get; set; } = null!;
}