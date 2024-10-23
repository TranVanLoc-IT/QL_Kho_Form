using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.SupplierModelViews
{
    public class ResponseSupplierModel
    {
        /// <summary>
        ///     Mã định danh
        /// </summary>
        public string MaNcc { get; set; }

        /// <summary>
        ///     Tên NCC
        /// </summary>
        public string TenNcc { get; set; }

        /// <summary>
        ///     Ghi chú thông tin liên quan: SDT, DC, LH
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        ///     Xóa mềm
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
