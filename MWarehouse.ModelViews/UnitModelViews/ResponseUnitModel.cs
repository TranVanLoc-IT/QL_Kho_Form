using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.UnitModelViews
{
    public class ResponseUnitModel
    {
        /// <summary>
        ///     Mã thay thế /  tìm kiếm cho đơn vị tính
        /// </summary>
        [DisplayName("Mã code")]
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên DVT
        /// </summary>
        [DisplayName("Tên đơn vị tính")]
        public string TenDvt { get; set; }

        /// <summary>
        ///     Ghi chú bổ sung
        /// </summary>
        [DisplayName("Ghi chú")]
        public string? GhiChu { get; set; }
    }
}
