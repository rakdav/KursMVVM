using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursMVVM.Models;
using KursMVVM.Services;
using KursMVVM.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace KursMVVM.ViewModels
{
    public partial class ClientsPageViewModel : ViewModelBase
    {
        private WindowNotificationManager _notificationManager;
        private ClientsPageService pageService;
        [ObservableProperty]
        private ObservableCollection<Client> clients = new();
        [ObservableProperty]
        private Client selectedClient;
        public ClientsPageViewModel()
        {
            pageService = new ClientsPageService();
            _notificationManager = new WindowNotificationManager(MainWindow.Instance)
            {
                Position = NotificationPosition.BottomRight,
                MaxItems = 3
            };
            Load();
        }
        private void Load()
        {
            Clients.Clear();
            Clients = new ObservableCollection<Client>(getClients());
        }
        private List<Client> getClients()
        {
            Task<List<Client>> task = Task.Run(() => pageService.get());
            return task.Result;
        }
        [RelayCommand]
        private async Task Add()
        {
            try
            {
                var dialog = new ClientWindow(new
                    Client());
                Client result = await dialog.ShowDialog<Client>(MainWindow.Instance!);
                if (result != null)
                {
                    await pageService.Add(result);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Load();
            }
        }
        [RelayCommand]
        private async Task Edit(object param)
        {
            if (param != null)
            {
                Client client = (Client)param;
                ClientWindow dialog = new ClientWindow(client);
                Client result = await dialog.ShowDialog<Client>(MainWindow.Instance!);
                if (result != null)
                {
                    await pageService.Edit(result);
                    Load();
                }
            }
        }
        [RelayCommand]
        private async Task Delete(object param)
        {
            if (param != null)
            {
                var box = MessageBoxManager
        .GetMessageBoxStandard("Внимание", "Вы действительно хотите удалить объект?", ButtonEnum.OkCancel);
                ButtonResult result = await box.ShowAsync();
                if (result == ButtonResult.Ok)
                {
                    Client client = (Client)param;
                    await pageService.Delete(client.IdClient);
                    Load();
                }
            }
        }
        [RelayCommand]
        private async Task Load(object param)
        {
            var topLavel = TopLevel.GetTopLevel(MainWindow.Instance);
            if (topLavel != null)
            {
                var files = await topLavel.StorageProvider.OpenFilePickerAsync(
                    new FilePickerOpenOptions
                    {
                        Title = "Select a Text File",
                        AllowMultiple = false,
                        FileTypeFilter = new[]
                    {
                        new FilePickerFileType("csv") { Patterns = new[] { "*.csv" } },
                        new FilePickerFileType("json") { Patterns = new[] { "*.json" } },
                        new FilePickerFileType("xml") { Patterns = new[] { "*.xml" } },
                    }
                    });
                if (files.Count > 0)
                {
                    var selectedFile = files[0];
                    switch (selectedFile.Name.Split('.')[1])
                    {
                        case "csv":
                            LoadCSVClient loadCSV = new LoadCSVClient();
                            await loadCSV.LoadList(selectedFile.Path.AbsolutePath);
                            break;
                        case "json":
                            LoadJSONClient loadJSON = new LoadJSONClient();
                            await loadJSON.LoadList(selectedFile.Path.AbsolutePath);
                            break;
                        case "xml":
                            LoadXMLClient loadXML = new LoadXMLClient();
                            await loadXML.LoadList(selectedFile.Path.AbsolutePath);
                            break;
                    }
                    Load();
                }
            }
        }
        [RelayCommand]
        private async Task Upload(object param)
        {
            var topLavel = TopLevel.GetTopLevel(MainWindow.Instance);
            if (topLavel != null)
            {
                var files = await topLavel.StorageProvider.SaveFilePickerAsync(
                    new FilePickerSaveOptions
                    {
                        Title = "Select a Text File",
                        FileTypeChoices = new[]
                    {
                        new FilePickerFileType("csv") { Patterns = new[] { "*.csv" } },
                        new FilePickerFileType("xlsx") { Patterns = new[] { "*.xlsx" } },
                        new FilePickerFileType("pdf") { Patterns = new[] { "*.pdf" } },
                    }
                    });
                switch (files!.Name.Split('.')[1])
                {
                    case "csv":
                        LoadCSVClient loadCSV = new LoadCSVClient();
                        await loadCSV.Upload(files.Path.AbsolutePath, getClients());
                        break;
                    case "pdf":
                        LoadPDFClient loadPDF = new LoadPDFClient();
                        await loadPDF.Upload(files.Path.AbsolutePath, getClients());
                        break;
                    case "xlsx":
                        LoadExcelClient loadExcel = new LoadExcelClient();
                        await loadExcel.Upload(files.Path.AbsolutePath,getClients());
                        break;
                }
                _notificationManager.Show(new Notification(
                   "Файл сохранён",
                   "Ваш документ "+ files!.Name + " успешно сохранён.",
                   NotificationType.Success,
                   TimeSpan.FromSeconds(1)));
            }
        }
    }
}
