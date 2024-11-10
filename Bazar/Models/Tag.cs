using System;
using System.Collections.Generic;

namespace Bazar.Models;

public partial class Tag
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? Tag1 { get; set; }

    public virtual Product? Product { get; set; }
}
