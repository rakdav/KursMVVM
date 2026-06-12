using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KursMVVM;

public partial class GraphPageView : UserControl
{
    public GraphPageView()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}