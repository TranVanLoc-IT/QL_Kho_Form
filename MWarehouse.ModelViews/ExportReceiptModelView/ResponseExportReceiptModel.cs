using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ExportReceiptModelView
{
    public class ResponseExportReceiptModel
    {
        [DisplayName("Số phiếu xuất")]
        public string SoPhieuXuat { get; set; }

        [DisplayName("Mã kho")]
        public int? KhoId { get; set; }

        [DisplayName("Ngày xuất kho")]
        public DateOnly? NgayXuatKho { get; set; }

        [DisplayName("Ghi chú")]
        public string? GhiChu { get; set; }

        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; }

    }
}
