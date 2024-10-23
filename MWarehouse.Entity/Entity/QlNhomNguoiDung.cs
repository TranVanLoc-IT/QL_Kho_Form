using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;

public partial class QlNhomNguoiDung:BaseEntity
{
    public string TenNhom { get; set; }

    public string GhiChu { get; set; }
}
