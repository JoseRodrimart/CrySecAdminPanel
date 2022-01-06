using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CompanyViewModel 
    {
        public Company Company { get; set; }

        public CompanyViewModel()
        {
            Company = new Company("Empresa");
            AddButton = new AddButtonCommand(this);
        }
    }
}
