using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblDmKho
{
    public int AutoId { get; set; }

    public string MaKho { get; set; }

    public string TenKho { get; set; }

    public string? GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<TblXnkNhapKho> TblXnkNhapKhos { get; set; } = new List<TblXnkNhapKho>();

    public virtual ICollection<TblXnkXuatKho> TblXnkXuatKhos { get; set; } = new List<TblXnkXuatKho>();
}
