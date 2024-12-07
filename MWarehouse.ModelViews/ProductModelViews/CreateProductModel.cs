using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ProductModelViews
{
    public class CreateProductModel
    {
        /// <summary>
        ///     Mã thao tác
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên sản phầm
        /// </summary>
        public string TenSanPham { get; set; }

        /// <summary>
        ///     Mã loại sản phẩm
        /// </summary>
        public int? LoaiSanPhamId { get; set; }

        /// <summary>
        ///     Mã đơn vị tính của sản phẩm
        /// </summary>
        public int? DonViTinhId { get; set; }

        /// <summary>
        ///     Ghi chú cho sản phẩm
        /// </summary>
        public string? GhiChu { get; set; }
    }
}
