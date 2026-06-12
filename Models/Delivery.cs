using System;
using System.Collections.Generic;

namespace KursMVVM.Models;

public partial class Delivery
{
    public int IdDelivery { get; set; }

    public string Date { get; set; } = null!;

    public virtual ICollection<FactOrder> FactOrders { get; set; } = new List<FactOrder>();
}
