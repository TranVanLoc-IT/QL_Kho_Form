﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ExportReceiptModelView
{
    public class ResponseExportReceiptModel
    {
        [DisplayName("Mã code")]
        public int AutoId { get; set; }

        [DisplayName("Tên kho")]
        public string? Kho { get; set; }

        [DisplayName("Ngày xuất kho")]
        public DateOnly? NgayXuatKho { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Trạng thái")]
        public int? TrangThai { get; set; }

    }
}
