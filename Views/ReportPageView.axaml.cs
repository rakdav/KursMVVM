using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KursMVVM;

public partial class ReportPageView : UserControl
{
    public ReportPageView()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}