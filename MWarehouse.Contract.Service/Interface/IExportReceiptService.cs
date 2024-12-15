using MWarehouse.ModelViews.ExportReceiptModelView;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IExportReceiptService
    {
        Task<IEnumerable<ResponseExportReceiptModel>> GetAllAsync();
        Task ConfirmAsync(int id);
        Task<int> GetAutoId(string id);
    }
}
