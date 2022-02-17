using CrySecAdminPanel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WPF;
using CrySecAdminPanel.Views;

namespace CrySecAdminPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.Current.Properties["CompanyId"] = 13;
            CompanyViewModel cvm = new CompanyViewModel();
            this.DataContext = cvm;
            MainFrame.Content = new HomeView();
        }

        //Despliegue del menú lateral
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        //Carga de las vistas correspondientes a cada sección
        private void LoadHomeView(object sender, RoutedEventArgs e) => MainFrame.Content = new HomeView();
        private void LoadMembersView(object sender, RoutedEventArgs e) => MainFrame.Content = new MembersView();
        private void LoadMessagesView(object sender, RoutedEventArgs e) =>  MainFrame.Content = new MessagesView();
        private void LoadGroupsView(object sender, RoutedEventArgs e) => MainFrame.Content = new GroupsView();
        private void LoadUsageView(object sender, RoutedEventArgs e) => MainFrame.Content = new UsageView();
        private void LoadPropertiesView(object sender, RoutedEventArgs e) => MainFrame.Content = new PropertiesView();

        //Botones ventana
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            var move = sender as System.Windows.Controls.Grid;
            var win = Window.GetWindow(this);
            win.DragMove();
        }

    }
}
