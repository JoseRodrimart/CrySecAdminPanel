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
using System.Windows.Shapes;

namespace CrySecAdminPanel.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginButton.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkValidation(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as LoginViewModel).IsLoginEnabled = true;
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            if (Validation.GetErrors(((TextBox)sender)).Count() > 0) LoginButton.IsEnabled = false;
            // (this.DataContext as LoginViewModel).IsLoginEnabled = false;
            else LoginButton.IsEnabled = true;
                // (this.DataContext as LoginViewModel).IsLoginEnabled = true;

            //(this.DataContext as LoginViewModel).LoginCom;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
             (this.DataContext as LoginViewModel).Password = ((PasswordBox)sender).SecurePassword; 
        }
    }
}
