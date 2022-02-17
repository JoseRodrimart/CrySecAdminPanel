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
        [Delete("/group/{id}/user/{userId}")]
        Task DeleteUserFromGroup([AliasAs("id")]int groupId, [AliasAs("userId")] int userId);
        [Put("/group/{id}/user/{userId}")]
        Task AddMemberToGroup([AliasAs("id")] int groupId, [AliasAs("userId")] int userId);

        [Post("/group/{idCompany}/{name}/{type}")]
        Task CreateNewGroup([AliasAs("idCompany")] int idCompany, [AliasAs("name")] string name, [AliasAs("type")] string type);
        [Delete("/group/{id}")]
        Task DeleteGroupByID([AliasAs("id")] int id);
    }
}
