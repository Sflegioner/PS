using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ClientLourd.MVVM.Model;
using ClientLourd.Core;
using ClientLourd.MVVM.View;

public class CommonViewModel
{
    public ObservableCollection<SalarieModel> ListSalaries { get; set; } = new();
    private List<SalarieModel> allSalaries = new();

    public string SearchByNameText { get; set; } = "";
    public string SearchBySiteText { get; set; } = "";
    public string SearchByServiceText { get; set; } = "";
    
    public SalarieModel? SelectedSalarie { get; set; }

    public CommonViewModel() => LoadSalariesAsync();

    private async void LoadSalariesAsync()
    {
        allSalaries = await APIserviceSalarie.GetSalarieAsync();
        ApplyFilter();
    }

    public void ApplyFilter()
    {
        ListSalaries.Clear();
        foreach (var salarie in allSalaries.Where(s =>
                     (string.IsNullOrWhiteSpace(SearchByNameText) || s.Nom.Contains(SearchByNameText, System.StringComparison.OrdinalIgnoreCase)) &&
                     (string.IsNullOrWhiteSpace(SearchBySiteText) || s.Site.Contains(SearchBySiteText, System.StringComparison.OrdinalIgnoreCase)) &&
                     (string.IsNullOrWhiteSpace(SearchByServiceText) || s.Service.Contains(SearchByServiceText, System.StringComparison.OrdinalIgnoreCase))))
        {
            ListSalaries.Add(salarie);
        }
    }
    
    
    public void OpenDetailsWindow(SalarieModel salarie)
    {
        if (salarie != null)
        {
            var detailsWindow = new DetailsWindow(salarie);
            detailsWindow.ShowDialog();
        }
    }
}

