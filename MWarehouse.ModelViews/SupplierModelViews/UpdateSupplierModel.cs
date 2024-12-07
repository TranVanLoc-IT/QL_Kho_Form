using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.SupplierModelViews
{
    public class UpdateSupplierModel
    {

        /// <summary>
        ///     Mã định danh
        /// </summary>
        public int AutoId { get; set; }

        /// <summary>
        ///     Ghi chú thông tin liên quan: SDT, DC, LH
        /// </summary>
        public string? GhiChu { get; set; }
    }
}
