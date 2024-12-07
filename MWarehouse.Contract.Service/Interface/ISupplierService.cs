using MWarehouse.Core.Base;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.SupplierModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface ISupplierService
    {
        // async
        Task CreateAsync(CreateSupplierModel obj);
        Task UpdateAsync(string id, UpdateSupplierModel obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<ResponseSupplierModel>> GetAllAsync();
        Task<ResponseSupplierModel> GetByIdAsync(int id);
    }
}
