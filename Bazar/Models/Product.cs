using System;
using System.Collections.Generic;

namespace Bazar.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public decimal? Rating { get; set; }

    public int? Stock { get; set; }

    public string? Brand { get; set; }

    public string? Sku { get; set; }

    public decimal? Weight { get; set; }

    public string? WarrantyInformation { get; set; }

    public string? ShippingInformation { get; set; }

    public string? AvailabilityStatus { get; set; }

    public string? ReturnPolicy { get; set; }

    public int? MinimumOrderQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Barcode { get; set; }

    public string? QrCode { get; set; }

    public string? Thumbnail { get; set; }

    public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
