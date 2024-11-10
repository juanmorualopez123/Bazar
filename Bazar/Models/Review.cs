using System;
using System.Collections.Generic;

namespace Bazar.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Date { get; set; }

    public string? ReviewerName { get; set; }

    public string? ReviewerEmail { get; set; }

    public virtual Product? Product { get; set; }
}
