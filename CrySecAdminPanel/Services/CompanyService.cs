using CrySecAdminPanel.Repositories;
using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.Services
{
    // Clase servicio 
    internal class CompanyService
    {
        ICompanyApi CompanyApi;
        public CompanyService()
        {
            CompanyApi = RestService.For<ICompanyApi>("https://admin-panel-server.herokuapp.com");
        }
        public Boolean Login(string mail, string password)  
        {
            int login = CompanyApi.Login(mail, password).Result;
            if (login == 0)
            {
                Trace.WriteLine("SERVICIO: " + login);
                return false;
            } else
            {
                App.Current.Properties["CompanyId"] = login;
                return true;
            }
        }
        public Company GetCompanyById()
        {
           return CompanyApi.GetCompanyById((int)App.Current.Properties["CompanyId"]).Result;    
        }
    }
}
