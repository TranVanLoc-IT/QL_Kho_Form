using MWarehouse.Core.Base;
using MWarehouse.ModelViews.WarehouseModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IWarehouseService
    {
        // async
        Task CreateAsync(CreateWarehouseModel obj);
        Task UpdateAsync(int id, ResponseWarehouseModel obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<ResponseWarehouseModel>> GetAllAsync();
    }
}
