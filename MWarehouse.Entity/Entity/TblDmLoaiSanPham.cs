using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblDmLoaiSanPham:BaseEntity
{
    public int AutoId { get; set; }

    public string TenLsp { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblDmSanPham> TblDmSanPhams { get; set; } = new List<TblDmSanPham>();
}
