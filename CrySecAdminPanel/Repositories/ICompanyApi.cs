using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.Repositories
{
    internal interface ICompanyApi
    {
        [Get("/company/{id}")]
        Task<Company> GetCompanyById([AliasAs("id")] int idCompany);

        [Put("/company")]
        Task<Company> UpdateCompany(Company company);
    }
}
