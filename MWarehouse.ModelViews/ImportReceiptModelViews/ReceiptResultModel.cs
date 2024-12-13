using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.GoodsReceiptModelViews
{
    public class ReceiptResultModel
    {
        /// <summary>
        ///     Mã SP
        /// </summary>
        [DisplayName("Mã sản phầm")]
        public int? SpId { get; set; }

        /// <summary>
        ///     Tên SP
        /// </summary>
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }

        /// <summary>
        ///     SLCC
        /// </summary>
        [DisplayName("Số lượng")]
        public decimal? Quantity { get; set; }
    }
}
