using System;
using System.Collections.Generic;

namespace ShopBridge.Entities.Entities;

public partial class Item:BaseEntity
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string Image { get; set; }
}
