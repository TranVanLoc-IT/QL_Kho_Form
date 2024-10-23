using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblDmKhoUser
{
    public int AutoId { get; set; }

    public string MaDangNhap { get; set; }

    public int? KhoId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmKho Kho { get; set; }
}
