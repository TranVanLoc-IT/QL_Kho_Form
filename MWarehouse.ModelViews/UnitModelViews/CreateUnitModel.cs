using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.UnitModelViews
{
    public class CreateUnitModel
    {

        /// <summary>
        ///     Mã thay thế /  tìm kiếm cho đơn vị tính
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên DVT
        /// </summary>
        public string TenDvt { get; set; }

        /// <summary>
        ///     Ghi chú bổ sung
        /// </summary>
        public string? GhiChu { get; set; }

    }
}
