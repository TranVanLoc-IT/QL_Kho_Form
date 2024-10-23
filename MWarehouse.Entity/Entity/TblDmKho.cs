using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblDmKho:BaseEntity
{
    public int AutoId { get; set; }

    public string TenKho { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblDmKhoUser> TblDmKhoUsers { get; set; } = new List<TblDmKhoUser>();

    public virtual ICollection<TblXnkNhapKho> TblXnkNhapKhos { get; set; } = new List<TblXnkNhapKho>();

    public virtual ICollection<TblXnkXuatKho> TblXnkXuatKhos { get; set; } = new List<TblXnkXuatKho>();
}
