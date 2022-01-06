using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.ViewModel
{
    public class TestViewModel
    {
        public Company Company { get; set; }

        public TestViewModel()
        {
            Company = new Company("OtraEmpresa");
        }
    }
}
