using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ProductModelViews
{
    public class ResponseProductModel
    {
        /// <summary>
        ///     Mã định danh
        /// </summary>
        [DisplayName("Mã code")]
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên sản phầm
        /// </summary>
        [DisplayName("Tên sản phầm")]
        /// 
        public string TenSanPham { get; set; }

        /// <summary>
        ///     Mã loại sản phẩm
        /// </summary>
        [DisplayName(" Mã loại sản phẩm")]
        /// 
        public int? LoaiSanPhamId { get; set; }

        /// <summary>
        ///     Mã đơn vị tính
        /// </summary>
        [DisplayName("Mã đơn vị tính của sản phẩm")]
        /// 
        public int? DonViTinhId { get; set; }

        /// <summary>
        ///     Ghi chú cho sản phẩm
        /// </summary>
        /// 
        public string? GhiChu { get; set; }
    }
}
