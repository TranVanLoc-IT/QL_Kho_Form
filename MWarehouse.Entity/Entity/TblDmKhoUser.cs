using MWarehouse.Core;
using System;
using System.Collections.Generic;

namespace MWarehouse.Entity;


public partial class TblDmKhoUser:BaseEntity
{
    public int AutoId { get; set; }

    public int? KhoId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmKho Kho { get; set; }
}
