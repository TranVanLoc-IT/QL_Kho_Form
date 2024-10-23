using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblXnkNhapKhoRawDatum
{
    public int AutoId { get; set; }

    public int? NhapKhoId { get; set; }

    public int? SanPhamId { get; set; }

    public decimal? SlNhap { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblXnkNhapKho NhapKho { get; set; }

    public virtual TblDmSanPham SanPham { get; set; }
}
