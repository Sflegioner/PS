using System.Windows;
using ClientLourd.MVVM.Model;

namespace ClientLourd.MVVM.View;

public partial class DetailsWindow : Window
{
    public DetailsWindow(SalarieModel salarie)
    {
        InitializeComponent();
        DataContext = salarie;
    }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}