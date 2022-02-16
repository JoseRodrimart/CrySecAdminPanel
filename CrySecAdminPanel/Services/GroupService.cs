﻿using CrySecAdminPanel.Repositories;
using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}