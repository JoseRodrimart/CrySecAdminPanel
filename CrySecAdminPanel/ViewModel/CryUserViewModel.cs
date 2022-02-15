using CrySecAdminPanel.Services;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CryUserViewModel
    {
        public List<CryUser> CryUsers { get; set; }
        public UserService cryUserService = new UserService();

        public CryUserViewModel()
        {
            SetUsers();
        }

        public void SetUsers()
        {
            CryUsers = cryUserService.GetUsersByCompanyId();
            CryUsers.ForEach(u => Trace.WriteLine(u));
        }
    }
}
