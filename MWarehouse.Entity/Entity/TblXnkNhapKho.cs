﻿using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblXnkNhapKho:BaseEntity
{
    public int AutoId { get; set; }

    public int? KhoId { get; set; }

    public int? NccId { get; set; }

    public DateOnly? NgayNhapKho { get; set; }

    public string GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmKho Kho { get; set; }

    public virtual TblDmNcc Ncc { get; set; }

    public virtual ICollection<TblXnkNhapKhoRawDatum> TblXnkNhapKhoRawData { get; set; } = new List<TblXnkNhapKhoRawDatum>();
}
