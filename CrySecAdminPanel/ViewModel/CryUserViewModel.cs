using CrySecAdminPanel.Services;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CryUserViewModel
    {
        private BindingList<CryUser> _cryUsers = new BindingList<CryUser>();
        public BindingList<CryUser> CryUsers { get { return _cryUsers; } }
        //{
        //    get
        //    {
        //        if (_cryUsers == null)
        //        {
        //            _cryUsers = new BindingList<CryUser>();
        //        }
        //        return _cryUsers;
        //    }
        //}
        public UserService cryUserService = new UserService();

        public float FlipperWidth { get; set; }

        public CryUserViewModel()
        {
            // _cryUsers = new BindingList<CryUser>();
            FlipperWidth = 30000;
            SetUsers();
        }

        public void SetUsers()
        {
            CryUsers.Clear();
            cryUserService.GetUsersByCompanyId().ForEach(CryUsers.Add);
            //CryUsers.ResetBindings();
        }
        public void DeleteUser(int id)
        {
            cryUserService.DeleteUserById(id);
            SetUsers();
        }
    }
}
