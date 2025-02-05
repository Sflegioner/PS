using System.Windows.Controls;
using ClientLourd.Core;
using ClientLourd.MVVM.Model;

namespace ClientLourd.MVVM.View;

public partial class CommonView : UserControl
{
    public CommonView()
    {
        InitializeComponent();
        ShowAllSites();
    }

    public async void ShowAllSites()
    {
        List<SiteModel> sites = await APIserviceSite.GetSitesAsync();
    
        foreach (var site in sites)
        {
            Console.WriteLine($"ID: {site.Id}, Назва: {site.SiteName}");
        }
    }
}