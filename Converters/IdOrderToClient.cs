using Avalonia.Data.Converters;
using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KursMVVM.Converters
{
    public class IdOrderToClient : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            using (KursContext db = new KursContext())
            {
                int id = int.Parse(value!.ToString()!);
                int idProduct = db.Orders.FirstOrDefault(p => p.IdOrder == id)!.IdProduct;
                Client client = db.Clients.FirstOrDefault(p=>p.IdClient==id)!;
                return parameter switch
                {
                    "FIO" => client.Surname+" "+client.FirstName.Substring(0,1)+"."+client.LastName!.Substring(0,1)+".",
                    "Dogovor"=>client.NumberDogovor,
                    _ => client
                };
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Order order)
            {
                return order.IdOrder;
            }
            return null;
        }
    }
}
