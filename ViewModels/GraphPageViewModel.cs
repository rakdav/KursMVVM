using CommunityToolkit.Mvvm.ComponentModel;
using KursMVVM.Models;
using KursMVVM.Services;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.ViewModels
{
    public partial class GraphPageViewModel:ViewModelBase
    {
        private DaliveryPageService pageService;
        [ObservableProperty]
        private ObservableCollection<FactOrder> factOrders = new();
        [ObservableProperty]
        private ISeries[] seriesCollection;
        public GraphPageViewModel()
        {
            pageService = new DaliveryPageService();
            FactOrders = new ObservableCollection<FactOrder>(geFactOrders());
            SeriesCollection = getPlanFactSeriesCollection();
        }
        private List<FactOrder> geFactOrders()
        {
            Task<List<FactOrder>> task = Task.Run(() => pageService.get());
            return task.Result;
        }
        private ISeries[] getPlanFactSeriesCollection()
        {
            ObservableValue[] fact= new ObservableValue[FactOrders.Count];
            ObservableValue[] plan= new ObservableValue[FactOrders.Count];
            for (int i = 0; i < FactOrders.Count; i++)
            {
                fact[i] = new(FactOrders[i].Quantity);
                using (KursContext db = new KursContext())
                {
                    plan[i] = new(db.Orders.FirstOrDefault(p => p.IdOrder == FactOrders[i].IdOrder)!.Quantity);
                }
            }
            return SeriesCollection = [
                new ColumnSeries<ObservableValue>
                {
                    Name = "План",
                    Values =plan,
                    Fill = new SolidColorPaint(new SKColor(255, 0, 0))
                },
                new ColumnSeries<ObservableValue>
                {
                    Name = "Факт",
                    Values =fact,
                    Fill = new SolidColorPaint(new SKColor(0, 0, 255))
                }
            ];
        }
    }
}
