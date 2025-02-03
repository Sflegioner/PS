using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientLourd.Core;
using ClientLourd.MVVM.View;

namespace ClientLourd;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new CommonView();
    }

    private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
    private void MinimazeWindow_MouseLeftButtonDown(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }
    
    private void WindowStateButton_Click(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        else
            Application.Current.MainWindow.WindowState = WindowState.Normal;
    }
    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    public void LoginCheck(object sender, RoutedEventArgs e)
    {
        string username = LoginNameInput.Text;
        string password = PasswordInput.Text;
        ConnectedUser.ChaeckIfIsAdmin(username, password);
        Console.WriteLine(ConnectedUser.IsAdmin);
        LoginField.Visibility = Visibility.Hidden;
    }

    public void ChangeToCommonPage(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new CommonView();
    }
    public void ChangeToAdminPage(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new AdminView();
    }




}