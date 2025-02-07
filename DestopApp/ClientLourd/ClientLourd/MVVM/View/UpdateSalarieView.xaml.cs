using System.Windows;
using ClientLourd.MVVM.Model;
using ClientLourd.MVVM.ViewModel;

namespace ClientLourd.MVVM.View
{
    public partial class UpdateSalarieView : Window
    {
        public UpdateSalarieView(SalarieModel salarie)
        {
            InitializeComponent();
            DataContext = new UpdateSalarieViewModel(salarie);
        }
    }
}