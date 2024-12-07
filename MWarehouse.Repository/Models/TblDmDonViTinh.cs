using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblDmDonViTinh
{
    public int AutoId { get; set; }

    public string MaDvt { get; set; }

    public string TenDvt { get; set; }

    public string? GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblDmSanPham> TblDmSanPhams { get; set; } = new List<TblDmSanPham>();
}
