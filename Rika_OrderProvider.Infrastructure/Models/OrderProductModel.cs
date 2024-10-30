﻿using System.ComponentModel.DataAnnotations;

namespace Rika_OrderProvider.Infrastructure.Models;

public class OrderProductModel
{
    [Required]
    public string ProductName { get; set; } = null!;

    [Required]
    public string UnitPrice { get; set; } = null!;

    [Required]
    public string Quantity { get; set; } = null!;

    [Required]
    public string Color { get; set; } = null!;

    [Required]
    public string Size { get; set; } = null!;
}