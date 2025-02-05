using System.Windows;
using System.Windows.Controls;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;
using ClientLourd.MVVM.ViewModel;

namespace ClientLourd.MVVM.View;

public partial class CommonView : UserControl
{
    public CommonView()
    {
        InitializeComponent();
        DataContext = new CommonViewModel();
    }
    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is CommonViewModel vm)
            vm.ApplyFilter();
    }
    private void OnItemClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (sender is Border border && border.DataContext is SalarieModel salarie)
        {
            if (DataContext is CommonViewModel vm)
                vm.OpenDetailsWindow(salarie);
        }
    }


}