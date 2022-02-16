using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PanelAdmin.Entities;
using Refit;

namespace CrySecAdminPanel.Repositories
{
    public interface IUsersApi
    {
        [Get("/company/{id}/user")]
        Task<List<CryUser>> GetUsersByCompanyId([AliasAs("id")] int idCompany);

        [Post("/user/hello")]
        Task<string> hello();
        
        [Delete("/user/{id}/company")]
        Task DeleteUserById([AliasAs("id")] int id);
    }
}
