using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ExportReceiptDetailModelView
{
    public class ResponseExportReceiptDetailModel
    {
        [DisplayName("Mã code")]
        public int AutoId { get; set; }

        [DisplayName("Sản phẩm")]
        public string? SanPham { get; set; }

        [DisplayName("Số lượng xuất")]
        public decimal? SlXuat { get; set; }

        [DisplayName("Đơn giá xuất")]
        public decimal? DonGiaXuat { get; set; }

    }
}
