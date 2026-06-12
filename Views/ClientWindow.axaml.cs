using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using KursMVVM.Models;
using System.Linq.Expressions;

namespace KursMVVM;

public partial class ClientWindow : Window
{
    public Client Client { get; set; }
    public ClientWindow(Client _client)
    {
        InitializeComponent();
        Client = _client;
        DataContext = this;
    }
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        Close(Client);
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close(null);
    }
}