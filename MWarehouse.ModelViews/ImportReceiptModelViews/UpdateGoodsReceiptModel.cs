using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.GoodsReceiptModelViews
{
    public class UpdateGoodsReceiptModel
    {
        /// <summary>
        ///     Mã phiếu
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Mã kho 
        /// </summary>
        public int? KhoId { get; set; }

        /// <summary>
        ///     Mã nhà cung cấp
        /// </summary>
        public int? NccId { get; set; }

        /// <summary>
        ///     Ngày nhập
        /// </summary>
        public DateOnly? NgayNhapKho { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        public string GhiChu { get; set; }
    }
}
