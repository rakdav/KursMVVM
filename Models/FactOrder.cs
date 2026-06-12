using System;
using System.Collections.Generic;

namespace KursMVVM.Models;

public partial class FactOrder
{
    public int IdFact { get; set; }

    public int IdOrder { get; set; }

    public int IdDelivery { get; set; }

    public int Quantity { get; set; }

    public virtual Delivery IdDeliveryNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
