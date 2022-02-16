using PanelAdmin.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.Repositories
{
    internal interface IGroupApi
    {
        [Get("/company/{id}/group")]
        Task<List<CryGroup>> GetGroups([AliasAs("id")] int idCompany);
        [Put("/group")]
        Task UpdateGroup(CryGroup group);   
    }
}
