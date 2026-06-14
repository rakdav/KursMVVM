using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KursMVVM.Converters
{
    public class PlanFactColorConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            int plan;
            int fact;
            int.TryParse(values[0]?.ToString(), out plan);
            int.TryParse(values[1]?.ToString(), out fact);
            if(plan != 0)
            {
                if(((double)fact / plan)>100) return new SolidColorBrush(Colors.Green);
                else if (((double)fact / plan)>=90&& ((double)fact / plan)<=100) 
                    return new SolidColorBrush(Colors.Yellow);
            }
            return new SolidColorBrush(Colors.Red);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
