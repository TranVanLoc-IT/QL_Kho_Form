using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.TheoDoi
{
    public class TheoDoiModelView
    {
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [DisplayName("Trạng thái")]
        public int? TrangThai { get; set; }

        [DisplayName("Lệnh thực hiện")]
        public string Lenh { get; set; }

        [DisplayName("Ngày thực hiện")]
        public DateTime? NgayThucHien { get; set; }

        [DisplayName("Thông tin")]
        public string ThongTin { get; set; }

    }
}
