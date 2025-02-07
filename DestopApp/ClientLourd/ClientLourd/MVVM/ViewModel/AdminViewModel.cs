using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;
using ClientLourd.MVVM.View;

namespace ClientLourd.MVVM.ViewModel
{
    public partial class AdminViewModel : ObservableObject
    {
        [ObservableProperty]
        private SalarieModel salarie = new();

        public ObservableCollection<SalarieModel> ListSalaries { get; } = new();

        public AdminViewModel()
        {
            LoadSalariesCommand.Execute(null);
        }

        [RelayCommand]
        private async Task CreateSalarie()
        {
            if (await APIserviceSalarie.PostSalarieAsync(Salarie))
            {
                ListSalaries.Add(new SalarieModel
                {
                    Id = Salarie.Id,
                    Nom = Salarie.Nom,
                    Prenom = Salarie.Prenom,
                    TelephoneFixe = Salarie.TelephoneFixe,
                    TelephonePortable = Salarie.TelephonePortable,
                    Email = Salarie.Email,
                    serviceId = Salarie.serviceId,
                    siteId = Salarie.siteId
                });
                MessageBox.Show("Salarie created successfully!");
                Salarie = new SalarieModel();
            }
            else
            {
                MessageBox.Show("Failed to create Salarie.");
            }
        }

        [RelayCommand]
        private async Task LoadSalaries()
        {
            ListSalaries.Clear();
            foreach (var salarie in await APIserviceSalarie.GetSalarieAsync())
            {
                ListSalaries.Add(salarie);
            }
        }

        [RelayCommand]
        private async Task DeleteSalarie(SalarieModel salarie)
        {
            if (salarie == null) return;

            if (await APIserviceSalarie.DeleteSalarieAsync(salarie))
            {
                ListSalaries.Remove(salarie);
                MessageBox.Show("Salarie deleted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to delete Salarie.");
            }
        }

        [RelayCommand]
        private void UpdateSalarie(SalarieModel salarie)
        {
            if (salarie == null) return;

            var updateWindow = new UpdateSalarieView(salarie);
            updateWindow.ShowDialog();
        }
    }
}
