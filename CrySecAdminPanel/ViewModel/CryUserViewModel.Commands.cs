using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CryUserViewModel
    {
        internal abstract class CryUserViewModelCommands : ICommand
        {
            protected CryUserViewModel cryUserViewModel;

            public event EventHandler? CanExecuteChanged;

            protected CryUserViewModelCommands(CryUserViewModel cryUserViewModel)
            {
                this.cryUserViewModel = cryUserViewModel;
            }

            public abstract bool CanExecute(object parameter);
            public abstract void Execute(object parameter);
        }
       
    }
}
