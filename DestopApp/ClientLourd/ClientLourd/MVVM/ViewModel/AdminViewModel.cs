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

        [ObservableProperty]
        private SiteModel site = new();

        [ObservableProperty]
        private ServiceModel service = new();

        // Властивості для оновлення сайтів (вже є)
        [ObservableProperty]
        private string oldSiteName;

        [ObservableProperty]
        private string newSiteName;

        // Нові властивості для оновлення сервісів
        [ObservableProperty]
        private string oldServiceName;

        [ObservableProperty]
        private string newServiceName;

        public ObservableCollection<SalarieModel> ListSalaries { get; } = new();
        public ObservableCollection<SiteModel> Sites { get; } = new();
        public ObservableCollection<ServiceModel> Services { get; } = new();

        public AdminViewModel()
        {
            LoadDataCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadData()
        {
            await LoadSalaries();
            await LoadSites();
            await LoadServices();
        }

        #region Salarie Methods
        [RelayCommand]
        private async Task CreateSalarie()
        {
            if (string.IsNullOrWhiteSpace(Salarie.Nom) || string.IsNullOrWhiteSpace(Salarie.Prenom))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (await APIserviceSalarie.PostSalarieAsync(Salarie))
            {
                await LoadSalaries();
                MessageBox.Show("Salarie created successfully!");
                Salarie = new SalarieModel();
            }
            else
            {
                MessageBox.Show("Failed to create Salarie.");
            }
        }

        [RelayCommand]
        private async Task DeleteSalarie(SalarieModel salarie)
        {
            if (salarie == null)
            {
                MessageBox.Show("Please select a Salarie to delete.");
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete {salarie.Nom} {salarie.Prenom}?", "Confirm Delete", MessageBoxButton.YesNo);

            if (confirm == MessageBoxResult.Yes)
            {
                if (await APIserviceSalarie.DeleteSalarieAsync(salarie))
                {
                    await LoadSalaries();
                    MessageBox.Show("Salarie deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete Salarie.");
                }
            }
        }

        [RelayCommand]
        private async Task LoadSalaries()
        {
            ListSalaries.Clear();
            foreach (var s in await APIserviceSalarie.GetSalarieAsync())
            {
                ListSalaries.Add(s);
            }
        }

        [RelayCommand]
        private void UpdateSalarie(SalarieModel salarie)
        {
            if (salarie == null) return;
            var updateWindow = new UpdateSalarieView(salarie);
            updateWindow.ShowDialog();
        }
        #endregion

        #region Site Methods
        [RelayCommand]
        private async Task LoadSites()
        {
            Sites.Clear();
            foreach (var s in await APIserviceSite.GetSitesAsync())
            {
                Sites.Add(s);
            }
        }

        [RelayCommand]
        private async Task CreateSite()
        {
            if (string.IsNullOrWhiteSpace(Site.SiteName))
            {
                MessageBox.Show("Enter a site name.");
                return;
            }

            if (await APIserviceSite.PostSiteAsync(Site.SiteName))
            {
                await LoadSites();
                MessageBox.Show($"Site '{Site.SiteName}' created successfully!");
                Site = new SiteModel();
            }
            else
            {
                MessageBox.Show("Failed to create Site.");
            }
        }

        [RelayCommand]
        private async Task DeleteSite()
        {
            if (string.IsNullOrWhiteSpace(Site.SiteName))
            {
                MessageBox.Show("Enter the site name to delete.");
                return;
            }

            if (await APIserviceSite.DeleteSiteAsync(Site.SiteName))
            {
                await LoadSites();
                MessageBox.Show($"Site '{Site.SiteName}' deleted successfully!");
                Site = new SiteModel();
            }
            else
            {
                MessageBox.Show("Failed to delete Site.");
            }
        }

        [RelayCommand]
        private async Task UpdateSite()
        {
            if (string.IsNullOrWhiteSpace(OldSiteName) || string.IsNullOrWhiteSpace(NewSiteName))
            {
                MessageBox.Show("Please enter both the old and new site names.");
                return;
            }

            if (await APIserviceSite.UpdateSiteAsync(OldSiteName, NewSiteName))
            {
                await LoadSites();
                MessageBox.Show($"Site '{OldSiteName}' updated to '{NewSiteName}' successfully!");
                OldSiteName = string.Empty;
                NewSiteName = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to update Site.");
            }
        }

        [RelayCommand]
        private async Task LoadServices()
        {
            Services.Clear();
            foreach (var s in await APIserviceService.GetServicesAsync())
            {
                Services.Add(s);
            }
        }

        [RelayCommand]
        private async Task CreateService()
        {
            if (string.IsNullOrWhiteSpace(Service.ServiceName))
            {
                MessageBox.Show("Enter a service name.");
                return;
            }

            if (await APIserviceService.PostServiceAsync(Service.ServiceName))
            {
                await LoadServices();
                MessageBox.Show($"Service '{Service.ServiceName}' created successfully!");
                Service = new ServiceModel();
            }
            else
            {
                MessageBox.Show("Failed to create Service.");
            }
        }

        [RelayCommand]
        private async Task DeleteService()
        {
            if (string.IsNullOrWhiteSpace(Service.ServiceName))
            {
                MessageBox.Show("Enter the service name to delete.");
                return;
            }

            if (await APIserviceService.DeleteServiceAsync(Service.ServiceName))
            {
                await LoadServices();
                MessageBox.Show($"Service '{Service.ServiceName}' deleted successfully!");
                Service = new ServiceModel();
            }
            else
            {
                MessageBox.Show("Failed to delete Service.");
            }
        }
        
        [RelayCommand]
        private async Task UpdateService()
        {
            if (string.IsNullOrWhiteSpace(OldServiceName) || string.IsNullOrWhiteSpace(NewServiceName))
            {
                MessageBox.Show("Please enter both the old and new service names.");
                return;
            }

            if (await APIserviceService.UpdateServiceAsync(OldServiceName, NewServiceName))
            {
                await LoadServices();
                MessageBox.Show($"Service '{OldServiceName}' updated to '{NewServiceName}' successfully!");
                OldServiceName = string.Empty;
                NewServiceName = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to update Service.");
            }
        }
        #endregion
    }
}
