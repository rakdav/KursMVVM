using Avalonia.Data.Converters;
using KursMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KursMVVM.Converters
{
    public class ViewModelToViewConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                HomePageViewModel => new HomePageView { DataContext = value },
                ClientsPageViewModel => new AboutPageView { DataContext = value },
                ProductsPageViewModel => new SettingsPageView { DataContext = value },
                OrdersPageViewModel=>new OrdersPageView { DataContext = value },
                GraphPageViewModel=>new GraphPageView { DataContext = value },
                ReportPageViewModel=>new ReportPageView {DataContext=value },
                _=>null
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
