using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.LoginModelView
{
    public class LoginModel
    {
        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        public LoginModel(string tdn, string mk)
        {
            this.TenDangNhap = tdn;
            this.MatKhau = mk;
        }
    }
}
