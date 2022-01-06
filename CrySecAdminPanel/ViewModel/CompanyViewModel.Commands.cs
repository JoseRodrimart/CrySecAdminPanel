using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CompanyViewModel
    {
        public ICommand AddButton { get; set; }

        internal abstract class CompanyViewModelCommands : ICommand
        {
            protected CompanyViewModel companyViewModel;

            public event EventHandler? CanExecuteChanged;

            protected CompanyViewModelCommands(CompanyViewModel companyViewModel)
            {
                this.companyViewModel = companyViewModel;
            }

            public abstract bool CanExecute(object parameter);
            public abstract void Execute(object parameter);
        }

        internal class AddButtonCommand : CompanyViewModelCommands
        {
            public AddButtonCommand(CompanyViewModel companyViewModel) : base(companyViewModel)
            {
            }

            public override bool CanExecute(object parameter)
            {
                return true;
            }

            public override void Execute(object parameter)
            {
                this.companyViewModel.Company.Name = "clicked";
            }
        }
    }
}
