using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrySecAdminPanel.ViewModel
{
    public partial class LoginViewModel
    { 
        public string Mail { get; set; }
        public SecureString Password { get; set; }
        public bool IsLoginEnabled { get; set; } = false;

        public LoginViewModel()
        {
            LoginCom = new LoginCommand(this);
        }

        public void NotifyLoginChange()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
