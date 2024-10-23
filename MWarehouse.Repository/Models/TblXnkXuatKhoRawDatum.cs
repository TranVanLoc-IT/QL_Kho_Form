using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblXnkXuatKhoRawDatum
{
    public int AutoId { get; set; }

    public int? XuatKhoId { get; set; }

    public int? SanPhamId { get; set; }

    public decimal? SlXuat { get; set; }

    public decimal? DonGiaXuat { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmSanPham SanPham { get; set; }

    public virtual TblXnkXuatKho XuatKho { get; set; }
}
