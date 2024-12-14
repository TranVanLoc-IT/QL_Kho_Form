using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class TblDmSanPham
{
    public int AutoId { get; set; }

    public string MaSanPham { get; set; }

    public string TenSanPham { get; set; }

    public int? LoaiSanPhamId { get; set; }

    public int? DonViTinhId { get; set; }

    public string? GhiChu { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual TblDmDonViTinh DonViTinh { get; set; }

    public virtual TblDmLoaiSanPham LoaiSanPham { get; set; }

    public virtual ICollection<TblXnkNhapKhoRawDatum> TblXnkNhapKhoRawData { get; set; } = new List<TblXnkNhapKhoRawDatum>();

    public virtual ICollection<TblXnkXuatKhoRawDatum> TblXnkXuatKhoRawData { get; set; } = new List<TblXnkXuatKhoRawDatum>();
}
