using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblDmNcc:BaseEntity
{
    public int AutoId { get; set; }

    public string TenNcc { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblXnkNhapKho> TblXnkNhapKhos { get; set; } = new List<TblXnkNhapKho>();
}
