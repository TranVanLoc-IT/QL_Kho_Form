using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblDmDonViTinh:BaseEntity
{
    public string AutoId { get; set; }

    public string TenDvt { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblDmSanPham> TblDmSanPhams { get; set; } = new List<TblDmSanPham>();
}
