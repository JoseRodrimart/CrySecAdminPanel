﻿using System;
using System.Collections.Generic;
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
            usersApi = RestService.For<IUsersApi>("http://localhost:8080");
        }

        public List<CryUser> GetUsersByCompanyId()
        {
            return usersApi.GetUsersByCompanyId((int)App.Current.Properties["CompanyId"]).Result;
        }

        //async public Task<HttpContent?> GetUsers()
        //{
        //     HttpContent httpContent = usersApi.GetAllUsers().Result;

        //     using var utf8Json = await httpContent.ReadAsStreamAsync().ConfigureAwait(false);

        //     return await System.Text.Json.JsonSerializer.DeserializeAsync<HttpContent>(utf8Json, options).ConfigureAwait(false);

        //}
        public void Hello()
        {
            Trace.WriteLine(usersApi.hello().Result);
        }
    }
}
