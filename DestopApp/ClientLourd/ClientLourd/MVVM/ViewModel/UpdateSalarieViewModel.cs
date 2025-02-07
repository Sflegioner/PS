using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;
using System.Threading.Tasks;

namespace ClientLourd.MVVM.ViewModel
{
    public partial class UpdateSalarieViewModel : ObservableObject
    {
        [ObservableProperty]
        private SalarieModel salarie;

        public UpdateSalarieViewModel(SalarieModel salarie)
        {
            Salarie = new SalarieModel
            {
                Id = salarie.Id,
                Nom = salarie.Nom,
                Prenom = salarie.Prenom,
                Email = salarie.Email,
                TelephoneFixe = salarie.TelephoneFixe,
                TelephonePortable = salarie.TelephonePortable,
                serviceId = salarie.serviceId,
                siteId = salarie.siteId
            };
        }

        [RelayCommand]
        private async Task UpdateSalarie()
        {
            bool isUpdated = await APIserviceSalarie.PutSalarieAsync(Salarie);

            if (isUpdated)
            {
                MessageBox.Show("Salarie updated successfully!");
                Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)?.Close();
            }
            else
            {
                MessageBox.Show("Failed to update Salarie.");
            }
        }
    }
}