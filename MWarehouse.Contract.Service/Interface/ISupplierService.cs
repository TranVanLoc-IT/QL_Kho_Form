using MWarehouse.Core.Base;
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
        Task<BasePaginatedList<ResponseSupplierModel>> GetAsync(string? id, string? name, string? code, int index, int pageSize);
        Task CreateAsync(ResponseSupplierModel obj);
        Task UpdateAsync(string id, ResponseSupplierModel obj);
        Task DeleteAsync(string id);
    }
}
