using CrySecAdminPanel.ViewModel;
using MaterialDesignThemes.Wpf;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CrySecAdminPanel.Views
{
    /// <summary>
    /// Lógica de interacción para MembersView.xaml
    /// </summary>
    public partial class MembersView : Page
    {
        public MembersView()
        {
            InitializeComponent();
            CryUserViewModel cvm = new CryUserViewModel();
            this.DataContext = cvm;
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            var userViewModel = ((CryUserViewModel)this.DataContext);
            var user = (sender as Button).DataContext as CryUser;
            userViewModel.DeleteUser(user.Id);
            Trace.WriteLine(user.Id);
        }

        private void ShowDelete(object sender, RoutedEventArgs e)
        {
            ((((sender as Button).Parent as Grid).Parent as Grid).Parent as Card).Background = new SolidColorBrush(Color.FromRgb(227, 111, 115)); ;  //Colors.Blue;// "#E36F73";
            foreach (Grid x in (((sender as Button).Parent as Grid).Parent as Grid).Children)
            {
                if (x.Name == "GridStandard") x.Visibility = Visibility.Collapsed;
                if (x.Name == "GridDelete") x.Visibility = Visibility.Visible;

            }
        }


        private void CancelDelete(object sender, RoutedEventArgs e)
        {
            (((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as Grid).Parent as Card).Background = new SolidColorBrush(Color.FromRgb(255,255,255));
            foreach (Grid x in ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as Grid).Children)
            {
                if (x.Name == "GridDelete") x.Visibility = Visibility.Collapsed;
                if (x.Name == "GridStandard") x.Visibility = Visibility.Visible;

            }
        }

        private void TS_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            TS.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }
    }
}
