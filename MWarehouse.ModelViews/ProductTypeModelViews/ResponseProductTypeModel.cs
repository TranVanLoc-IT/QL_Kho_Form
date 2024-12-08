﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.ProductTypeModelViews
{
    public class ResponseProductTypeModel
    {
        /// <summary>
        ///     Mã định danh
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên loại
        /// </summary>
        public string TenLsp { get; set; }

        /// <summary>
        ///     Ghi chú mô tả
        /// </summary>
        public string? GhiChu { get; set; }

    }
}
