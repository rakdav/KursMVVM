using Avalonia.Data.Converters;
using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KursMVVM.Converters
{
    public class IdClientToFIO : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int id = (int)value!;
            using (KursContext db=new KursContext())
            {
               Client client=db.Clients.FirstOrDefault(p=>p.IdClient == id)!;
                return client.FirstName + " " + client.LastName + " " + client.Surname;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
