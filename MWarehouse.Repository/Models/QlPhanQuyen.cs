using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class QlPhanQuyen
{
    public string MaNhomNguoiDung { get; set; }

    public string MaManHinh { get; set; }

    public int? CoQuyen { get; set; }
}
