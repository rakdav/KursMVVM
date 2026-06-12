using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursMVVM.ViewModels
{
    public partial class ProductsPageViewModel:ViewModelBase
    {
        [ObservableProperty]
        private bool isDarkTheme;
        [ObservableProperty]
        private string userName = "Пользователь";
    }
}
