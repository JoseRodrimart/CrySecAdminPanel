using CrySecAdminPanel.Services;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CompanyViewModel 
    {
        public Company Company { get; set; }
        private CompanyService companyService = new CompanyService(); 
        public CompanyViewModel()
        {
            Company = new Company("Empresa");
        }

        private void SetCompany()
        {
            Company = companyService.GetCompanyById();
        }
      
    }
}
