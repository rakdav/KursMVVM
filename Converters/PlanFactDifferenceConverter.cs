using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KursMVVM.Converters
{
    public class PlanFactDifferenceConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            int plan;
            int fact;
            int.TryParse(values[0]?.ToString(), out plan);
            int.TryParse(values[1]?.ToString(), out fact);
            return parameter switch {
                "Difference"=>(plan - fact).ToString(),
                "Procent"=>(plan!=0)?(((double)fact/plan)*100).ToString("F2")+"%":"0%",
                _=>"0"
            };
        }
        public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
