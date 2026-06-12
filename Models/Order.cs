using System;
using System.Collections.Generic;

namespace KursMVVM.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int IdClient { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<FactOrder> FactOrders { get; set; } = new List<FactOrder>();

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
