using MWarehouse.ModelViews.LoginModelView;
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
        Task UpdateUserRole(string user, string oldRole, string newRole);
        Task DeleteUserRole(string user, string role);
        Task<List<UserModelView>> GetUserInfo();
        Task<string> CreateNewUser(EditUserModel user);
        Task<string> UpdateUser(EditUserModel user);
        Task<string> DeleteUser(string name);
        Task<string> CreateNewGroupUser(string manhom, string name, string ghichu);
        Task<string> DeleteGroupUser(string name);
    }
}
