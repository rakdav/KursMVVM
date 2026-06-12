using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursMVVM.Services;
using KursMVVM.Views;

namespace KursMVVM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    [ObservableProperty]
    private object? currentPage;
    [ObservableProperty]
    private string title;
    public MainWindowViewModel()
    {
        _navigationService = new NavigationService(this);
        _navigationService.RegisterPage("Home", new HomePageViewModel());
        _navigationService.RegisterPage("Products", new ProductsPageViewModel());
        _navigationService.RegisterPage("Clients", new ClientsPageViewModel());
        _navigationService.RegisterPage("Orders", new OrdersPageViewModel());
        _navigationService.RegisterPage("Graphics", new GraphPageViewModel());
        _navigationService.RegisterPage("Reports", new ReportPageViewModel());
        // Переходим на главную страницу
        _navigationService.NavigateTo("Home");
        title = "Магазин";
    }
    [RelayCommand]
    public void Navigate(string pageKey)
    {
        _navigationService.NavigateTo(pageKey);
    }
}
