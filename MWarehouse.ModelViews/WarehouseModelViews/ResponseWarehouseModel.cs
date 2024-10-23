using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.WarehouseModelViews
{
    public class ResponseWarehouseModel
    {
        /// <summary>
        ///     Mã tìm kiếm
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Tên kho
        /// </summary>
        public string TenKho { get; set; }

        /// <summary>
        ///     Ghi chú cho kho: Vị trí, vai trò
        /// </summary>

        public string GhiChu { get; set; }

        /// <summary>
        ///     Xóa mềm
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
