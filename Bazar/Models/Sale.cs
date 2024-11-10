using System;
using System.Collections.Generic;

namespace Bazar.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Product? Product { get; set; }
}
