using CommunityToolkit.Mvvm.ComponentModel;
using KursMVVM.Models;
using KursMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.ViewModels
{
    public partial class DeliveryPageViewModel:ViewModelBase
    {
        private DaliveryPageService pageService;
        [ObservableProperty]
        private ObservableCollection<FactOrder> factOrders = new();
        public DeliveryPageViewModel()
        {
            pageService = new DaliveryPageService();
            FactOrders = new ObservableCollection<FactOrder>(getOrders());
        }
        private List<FactOrder> getOrders()
        {
            Task<List<FactOrder>> task = Task.Run(() => pageService.get());
            return task.Result;
        }
    }
}
