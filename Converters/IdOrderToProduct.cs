using Avalonia.Data.Converters;
using KursMVVM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KursMVVM.Converters
{
    public class IdOrderToProduct : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            using (KursContext db=new KursContext()) 
            {
                int id = int.Parse(value!.ToString()!);
                int idProduct= db.Orders.FirstOrDefault(p=>p.IdOrder==id)!.IdProduct;
                Product product= db.Products.FirstOrDefault(p => p.IdProduct == idProduct)!;
                return parameter switch
                {
                    "NameProduct" => product.NameProduct,
                    "Price" => product.Price,
                    _ => product
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
