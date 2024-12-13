using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.RoleModelView
{
    public class GroupRoleModelView
    {
        [DisplayName("Nhóm người dùng")]
        public string GroupUser { get; set; }

        [DisplayName("Mô tả")]
        public string? Decsription { get; set; }

    }
}
