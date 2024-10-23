using MWarehouse.Core.Base;
using MWarehouse.ModelViews.UnitModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IUnitService
    {
        // async
        Task<BasePaginatedList<ResponseUnitModel>> GetAsync(string? id, string? name, string? code, int index, int pageSize);
        Task CreateAsync(ResponseUnitModel obj);
        Task UpdateAsync(string id, ResponseUnitModel obj);
        Task DeleteAsync(string id);
    }
}
