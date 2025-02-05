using System.Windows.Controls;
using ClientLourd.Core;

namespace ClientLourd.MVVM.View;

public partial class AdminView : UserControl
{
    public AdminView()
    {
        InitializeComponent();
        Take();
    }

    async void Take()
    {
        var b = await APIserviceSalarie.GetSalarieAsync();
        foreach (var salarie in b)
        {
            Console.WriteLine(salarie.Nom);
        }
    }
}