using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.RoleModelView
{
    public class UserModelView
    {
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }


        [DisplayName("Email")]
        public string Email { get; set; }


        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; }
    }
}
