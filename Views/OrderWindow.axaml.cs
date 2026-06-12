using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using KursMVVM.Models;
using KursMVVM.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace KursMVVM;

public partial class OrderWindow : Window
{
    public Order Order { get; private set; }
    public ObservableCollection<Client> ClientList { get; set; }
    public ObservableCollection<Product> ProductList { get; set; }
    public OrderWindow(Order order)
    {
        InitializeComponent();
        Order = order;
        
        using (KursContext db = new KursContext()) {
            ClientList = new ObservableCollection<Client>(getClients());
            ProductList=new ObservableCollection<Product>(getProducts());
        }
        DataContext = this;
    }
    private List<Client> getClients()
    {
        Task<List<Client>> task = Task.Run(() => new ClientsPageService().get());
        return task.Result;
    }
    private List<Product> getProducts()
    {
        Task<List<Product>> task = Task.Run(() => new ProductPageService().get());
        return task.Result;
    }
    private void Save_Click(object sender, RoutedEventArgs e)
    { 
        Close(Order);
    }
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close(null);
    }
}