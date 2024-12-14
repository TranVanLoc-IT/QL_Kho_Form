using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.RoleModelView
{
    public class UserRoleModelView
    {
        [DisplayName("Tên người dùng")]
        public string User { get; set; }

        [DisplayName("Quyền hạn")]
        public string GroupUser { get; set; }

        [DisplayName("Mô tả")]
        public string? Decsription { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }
    }
}
