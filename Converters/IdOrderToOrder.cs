using Avalonia.Data.Converters;
using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KursMVVM.Converters
{
    public class IdOrderToOrder : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            using (KursContext db = new KursContext())
            {
                int id = int.Parse(value!.ToString()!);
                Order order = db.Orders.FirstOrDefault(p=>p.IdOrder==id)!;
                return order.Quantity;
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
