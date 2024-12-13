using MWarehouse.ModelViews.ExportReceiptDetailModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IExportReceiptDetailService
    {
        Task<IEnumerable<ResponseExportReceiptDetailModel>> GetDetailAsync(int id);

    }
}
