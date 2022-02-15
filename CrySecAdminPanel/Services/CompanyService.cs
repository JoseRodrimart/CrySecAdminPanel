using CrySecAdminPanel.Repositories;
using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.Services
{
    internal class CompanyService
    {
        ICompanyApi CompanyApi;
        public CompanyService()
        {
            CompanyApi = RestService.For<ICompanyApi>("http://localhost:8080");
        }
        public Company GetCompanyById()
        {
           return CompanyApi.GetCompanyById((int)App.Current.Properties["CompanyId"]).Result;    
        }
    }
}
