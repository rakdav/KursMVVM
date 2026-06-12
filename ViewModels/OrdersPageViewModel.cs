using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursMVVM.Models;
using KursMVVM.Services;
using KursMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.ViewModels
{
    public partial class OrdersPageViewModel:ViewModelBase
    {
        private OrderPageService orderPageService;
        [ObservableProperty]
        private ObservableCollection<Order> orders = new();
        [ObservableProperty]
        private Order selectedOrder;
        public OrdersPageViewModel()
        {
            orderPageService=new OrderPageService();
            Load();
        }
        private void Load()
        {
            Orders.Clear();
            Orders = new ObservableCollection<Order>(getOrders());
        }
        private List<Order> getOrders()
        {
            Task<List<Order>> task = Task.Run(() => orderPageService.get());
            return task.Result;
        }
        [RelayCommand]
        private async Task Add()
        {
            try
            {
                var dialog = new OrderWindow(new Order());
                Order result = await dialog.ShowDialog<Order>(MainWindow.Instance!);
                if (result != null)
                {
                    await orderPageService.Add(result);
                }
            }
            catch { }
            finally
            {
                Load();
            }
        }
    }
}
