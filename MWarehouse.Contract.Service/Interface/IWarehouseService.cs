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
        Task CreateAsync(ResponseWarehouseModel obj);
        Task UpdateAsync(string id, ResponseWarehouseModel obj);
        Task DeleteAsync(string id);
    }
}
