using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ProductModelViews
{
    public class UpdateProductModel
    {
        /// <summary>
        ///     Mã định danh
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên sản phầm
        /// </summary>
        public string? TenSanPham { get; set; }

        /// <summary>
        ///     Ghi chú cho sản phẩm
        /// </summary>
        public string? GhiChu { get; set; }

        /// <summary>
        ///     Loại sản phẩm
        /// </summary>
        public int LoaiSanPham { get; set; }
        /// <summary>
        ///     Dvt
        /// </summary>
        public int DonViTinhId { get; set; }
    }
}
