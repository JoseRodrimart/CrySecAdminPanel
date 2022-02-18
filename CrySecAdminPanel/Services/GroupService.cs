using CrySecAdminPanel.Repositories;
using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;

namespace CrySecAdminPanel.Services
{
    internal class GroupService
    {
        IGroupApi groupApi;
        public GroupService()
        {
            groupApi = RestService.For<IGroupApi>("http://localhost:8080");
        }

        public List<CryGroup> GetGroups()
        {
            return groupApi.GetGroups((int)App.Current.Properties["CompanyId"]).Result;
        }

        public void UpdateGroup(CryGroup group)
        {
            groupApi.UpdateGroup(group);
        }
        public void DeleteMemberGroup(int groupId, int userId)
        {
            groupApi.DeleteUserFromGroup(groupId, userId);
        }

        public void AddMemberToGroup(int id, int idUser)
        {
            groupApi.AddMemberToGroup(id, idUser);
        }

        public void CreateNewGroup(string name, string type)
        {

            groupApi.CreateNewGroup((int)App.Current.Properties["CompanyId"], name, type);
        }
        public void DeleteGroupById(int id)
        {
            groupApi.DeleteGroupByID(id);
        }
    }
}
