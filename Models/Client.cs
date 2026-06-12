using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace KursMVVM.Models;

public class Client
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Surname { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int? NumberDogovor { get; set; }

    public string? DataDogovor { get; set; }
    [XmlIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
