using MWarehouse.Core.Base;
using MWarehouse.ModelViews.ProductModelViews;
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
        Task CreateAsync(CreateUnitModel obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<ResponseUnitModel>> GetAllAsync();
        Task<IEnumerable<ResponseProductModel>> GetAllProductAsync(int code);
    }
}
