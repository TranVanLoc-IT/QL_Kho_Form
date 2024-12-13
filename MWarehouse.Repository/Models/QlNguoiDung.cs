using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class QlNguoiDung
{
    public string TenDangNhap { get; set; }

    public string MatKhau { get; set; }

    public int? TrangThai { get; set; }

    public string Email { get; set; }

    public bool? IsDeleted { get; set; }
}
