using CrySecAdminPanel.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CrySecAdminPanel.ViewModel
{
    public partial class LoginViewModel
    {
        private ICommand _loginCom;
        CompanyService companyService = new CompanyService();
        public ICommand LoginCom { get; set; }
        
        internal abstract class LoginViewModelCommand : ICommand
        {
            protected LoginViewModel loginViewModel;

            public event EventHandler? CanExecuteChanged;

            protected LoginViewModelCommand(LoginViewModel loginViewModel)
            {
                this.loginViewModel = loginViewModel;
            }

            public abstract bool CanExecute(object? parameter);

            public abstract void Execute(object? parameter);
        }

        internal class LoginCommand : LoginViewModelCommand
        {
            public LoginCommand(LoginViewModel loginViewModel) : base(loginViewModel)
            {
            }

            public override bool CanExecute(object? parameter)
            {
                return true;
            }

            public override void Execute(object? parameter)
            {
                if (loginViewModel.CheckLogin())
                {
                    Window mainWindow = Application.Current.MainWindow;
                    mainWindow = new MainWindow();
                    ((parameter as Button).FindName("root") as Window).Close();
                    mainWindow.Show();
                } else {
                    Trace.WriteLine("LOGIN INCORRECTO");
                }
               
                

            }
        }

        private Boolean CheckLogin()
        {
            string password = new System.Net.NetworkCredential(string.Empty, Password).Password;
            return companyService.Login(Mail, password);
           
        }
    }
}
