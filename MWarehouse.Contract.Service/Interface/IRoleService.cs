using MWarehouse.ModelViews.RoleModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IRoleService
    {
        Task<List<ManHinhView>> DsManHinh();
        Task<List<RoleView>> Roles();
        Task<List<GroupRoleModelView>> DsRole();
        Task<List<UserRoleModelView>> GetUsers();
        Task<List<ManHinhView>> GetMhActivating(string maNhom);
        Task AddMhToGroupRole(string maNhom, string maMh);
        Task DeleteMHFromGroupRole(string maNhom, string maMh);
        Task UpdateUserRole(string user, string role);
        Task DeleteUserRole(string user, string role);
    }
}
