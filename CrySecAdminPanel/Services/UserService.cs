using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CrySecAdminPanel.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PanelAdmin.Entities;
using Refit;

namespace CrySecAdminPanel.Services
{
    public class UserService
    {
        IUsersApi usersApi; 
        public UserService()
        {
            usersApi = RestService.For<IUsersApi>("https://admin-panel-server.herokuapp.com");
        }

        public List<CryUser> GetUsersByCompanyId()
        {
            return usersApi.GetUsersByCompanyId((int)App.Current.Properties["CompanyId"]).Result;
        }

        public void DeleteUserById(int id)
        {
            usersApi.DeleteUserById(id);
        }
        public List<CryUser> usersNotIncluded(int id)
        {
            return usersApi.GetNotMembers(id).Result;
        }
    }
}
