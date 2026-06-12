using KursMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursMVVM.Services
{
    public class NavigationService
    {
        private readonly MainWindowViewModel _mainViewModel;
        private readonly Dictionary<string, object> _pages = new();
        public NavigationService(MainWindowViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public void RegisterPage(string key, object pageViewModel)
        {
            _pages[key] = pageViewModel;
        }
        public void NavigateTo(string key)
        {
            if (_pages.TryGetValue(key, out var page))
            {
                _mainViewModel.CurrentPage = page;
            }
        }
    }
}
