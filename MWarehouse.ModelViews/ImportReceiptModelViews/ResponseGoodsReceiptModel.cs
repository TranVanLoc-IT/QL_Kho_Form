using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.GoodsReceiptModelViews
{
    public class ResponseGoodsReceiptModel
    {
        /// <summary>
        ///     Mã phiếu
        /// </summary>
        [DisplayName("Số phiếu nhập")]
        public string Id { get; set; }

        /// <summary>
        ///     Mã kho 
        /// </summary>
        [DisplayName("Mã kho hàng")]
        public int? KhoId { get; set; }

        /// <summary>
        ///     Mã nhà cung cấp
        /// </summary>
        [DisplayName("Nhà cung cấp")]
        public int? NccId { get; set; }

        /// <summary>
        ///     Ngày nhập
        /// </summary>
        [DisplayName("Ngày nhập kho")]
        public DateOnly? NgayNhapKho { get; set; }

        /// <summary>
        ///     Ghi chú
        /// </summary>
        [DisplayName("Ghi chú")]
        public string? GhiChu { get; set; }

        /// <summary>
        ///     Trạng thái
        /// </summary>
        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; }

    }
}
