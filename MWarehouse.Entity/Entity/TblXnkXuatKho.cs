using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;

public partial class TblXnkXuatKho:BaseEntity
{
    public int AutoId { get; set; }

    public int? KhoId { get; set; }

    public DateOnly? NgayXuatKho { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmKho Kho { get; set; }

    public virtual ICollection<TblXnkXuatKhoRawDatum> TblXnkXuatKhoRawData { get; set; } = new List<TblXnkXuatKhoRawDatum>();
}
