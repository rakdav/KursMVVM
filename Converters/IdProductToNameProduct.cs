using Avalonia.Data.Converters;
using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KursMVVM.Converters
{
    public class IdProductToNameProduct : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
                int id = (int)value!;
                using (KursContext db = new KursContext())
                {
                    return db.Products.FirstOrDefault(p => p.IdProduct == id)!.NameProduct;
                }
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
