using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CryUserViewModel
    {
        private ICommand _deleteUser;
        public ICommand DeleteUserC { get
            {
                if(_deleteUser == null)
                {
                    _deleteUser = new DeleteUserCommand(this);
                }
                return _deleteUser;
            }
                
         }

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
        internal class DeleteUserCommand : CryUserViewModelCommands
        {
            public DeleteUserCommand(CryUserViewModel cryUserViewModel) : base(cryUserViewModel)
            {
            }

            public override bool CanExecute(object parameter)
            {
                return true;
            }

            public override void Execute(object parameter)
            {
                Trace.WriteLine("Eliminado el usuario");
            }
        }

    }
}
