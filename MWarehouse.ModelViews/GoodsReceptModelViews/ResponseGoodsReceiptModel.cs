﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.GoodsReceptModelViews
{
    public class ResponseGoodsReceiptModel
    {
        /// <summary>
        ///     Mã phiếu
        /// </summary>
        public string SoPhieuNhap { get; set; }

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

        /// <summary>
        ///     Xóa mềm
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
