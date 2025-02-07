using System.Windows.Controls;
using ClientLourd.Core;
using ClientLourd.MVVM.ViewModel;

namespace ClientLourd.MVVM.View;

public partial class AdminView : UserControl
{
    public AdminView()
    {
        InitializeComponent();
        DataContext = new AdminViewModel();
    }
    
}