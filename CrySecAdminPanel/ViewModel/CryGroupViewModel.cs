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
    public partial class CryGroupViewModel
    {
        private GroupService groupService = new GroupService();
        private UserService userService = new UserService();
        private BindingList<CryGroup> _cryGroups = new BindingList<CryGroup>();

        private List<CryUser> notIncludedMembers { get; set; }

        public BindingList<CryGroup> CryGroups { get { return _cryGroups; } }

        public CryGroupViewModel()
        {
            SetGroups();
        }

        public void SetGroups()
        {
            CryGroups.Clear();
            List<CryGroup> groups = groupService.GetGroups();
            Trace.WriteLine("Grupos");
            groups.ForEach(u => Trace.WriteLine(u.ToString()));
            Trace.WriteLine("Administradores");
            groups.ForEach(g => g.adminUsers.ForEach(admin => Trace.WriteLine(admin.ToString())));
            Trace.WriteLine("Usuarios");
            groups.ForEach(g => g.regularUsers.ForEach(regular => Trace.WriteLine(regular.ToString())));
            groups.ForEach(CryGroups.Add);  
        }
        public void UpdateGroup(CryGroup group)
        {
            groupService.UpdateGroup(group);
            SetGroups();
        }
        public List<CryUser> NotMembersGroup(CryGroup group)
        {
            return userService.usersNotIncluded(group.id);
        }

    }
}
