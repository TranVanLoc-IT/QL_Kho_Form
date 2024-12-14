using MWarehouse.ModelViews.TheoDoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface ITheoDoiService
    {
        Task<List<TheoDoiModelView>> GetAllAsync();
        Task ResetAsync();

    }
}
