using System;
using System.Collections.Generic;
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
        public int MaDvt { get; set; }

        /// <summary>
        ///     Tên DVT
        /// </summary>
        public string TenDvt { get; set; }

        /// <summary>
        ///     Ghi chú bổ sung
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        ///      Trạng thái xóa mềm
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
