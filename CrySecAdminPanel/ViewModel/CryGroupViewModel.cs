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
            groups.ForEach(CryGroups.Add);
            CryGroups.ResetBindings();
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

        internal void ShrinkGroups(int id)
        {
            foreach(var group in CryGroups)
            {
                if(group.id != id)
                {
                    group.IsExpanded = false;
                }
            }
            CryGroups.ResetBindings();
        }
        public void DeleteMemberGroup(int id, int idUser)
        {
            groupService.DeleteMemberGroup(id, idUser);
            CryGroups.ResetBindings();
        }
        public void AddMemberToGroup(int id, int idUser)
        {
            groupService.AddMemberToGroup(id, idUser);
        }

        internal void CreateNewGroup(string name, string type)
        {
            groupService.CreateNewGroup(name, type);
            SetGroups();
        }

        internal void DeleteGroupById(int id)
        {
            groupService.DeleteGroupById(id);
            SetGroups();
        }
    }
}
