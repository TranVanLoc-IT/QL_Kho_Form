using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.GoodsReceiptModelDetailViews
{
    public class CreateGoodsReceiptDetailModel
    {
        /// <summary>
        ///     Mã phiếu
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Kho Nhập
        /// </summary>
        public int? NhapKhoId { get; set; }

        /// <summary>
        ///     Sản phẩm nhập
        /// </summary>
        public int? SanPhamId { get; set; }

        /// <summary>
        ///     Số lượng nhập
        /// </summary>
        public decimal? SlNhap { get; set; }

        /// <summary>
        ///     Gía nhập
        /// </summary>
        public decimal? DonGiaNhap { get; set; }
    }
}
