using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursMVVM.Models
{
    public class ClientMap:ClassMap<Client>
    {
        public ClientMap()
        {
           // Map(m => m.IdClient).Name("IdClient");
            Map(m => m.Surname).Name("Surname");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.Address).Name("Address");
            Map(m => m.Phone).Name("Phone");
            Map(m => m.NumberDogovor).Name("NumberDogovor");
            Map(m => m.DataDogovor).Name("DataDogovor");
        }
    }
}
