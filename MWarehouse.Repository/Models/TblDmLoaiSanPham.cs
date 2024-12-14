using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblDmLoaiSanPham
{
    public int AutoId { get; set; }

    public string MaLsp { get; set; }

    public string TenLsp { get; set; }

    public string? GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblDmSanPham> TblDmSanPhams { get; set; } = new List<TblDmSanPham>();
}
