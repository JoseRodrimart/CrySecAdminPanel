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
            CompanyViewModel cvm = new CompanyViewModel();
            this.DataContext = cvm;
            MainFrame.Content = new MembersView();
            ButtonUsers.Background = Brushes.LightBlue;


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
        private void LoadHomeView(object sender, RoutedEventArgs e){
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new HomeView();

        }

        private void ClearSelectedOption()
        {
            ButtonHome.Background = Brushes.Transparent;
            ButtonUsers.Background = Brushes.Transparent;
            ButtonMessages.Background = Brushes.Transparent;
            ButtonGroups.Background = Brushes.Transparent;
            ButtonUsage.Background = Brushes.Transparent;
            ButtonProperties.Background = Brushes.Transparent;
        }

        private void LoadMembersView(object sender, RoutedEventArgs e)
        {
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new MembersView();
        }
        private void LoadMessagesView(object sender, RoutedEventArgs e)
        {
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new MessagesView();
        }
        private void LoadGroupsView(object sender, RoutedEventArgs e)
        {
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new GroupsView();
        }
        private void LoadUsageView(object sender, RoutedEventArgs e) {
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new UsageView(); }
        private void LoadPropertiesView(object sender, RoutedEventArgs e) {
            ClearSelectedOption();
            (sender as Button).Background = Brushes.LightBlue;
            MainFrame.Content = new PropertiesView(); 
        }

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

        private void changedSelection(object sender, SelectionChangedEventArgs e)
        {
            switch(((sender as ListView).SelectedItem as Button).Name)
            {
                case "UserViewList": MainFrame.Content = new MembersView(); break;
                case "GroupsViewList": MainFrame.Content = new GroupsView(); break;
                default: break;
            }
        }
    }
}
