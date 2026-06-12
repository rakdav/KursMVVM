using System;
using System.Collections.Generic;

namespace KursMVVM.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
