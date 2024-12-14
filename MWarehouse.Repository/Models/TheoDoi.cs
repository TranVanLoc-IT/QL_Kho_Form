using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TheoDoi
{
    public int AutoId { get; set; }

    public string TenDangNhap { get; set; }

    public int? TrangThai { get; set; }

    public string Lenh { get; set; }

    public DateTime? NgayThucHien { get; set; }

    public string ThongTin { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual QlNguoiDung TenDangNhapNavigation { get; set; }
}
