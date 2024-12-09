using MWarehouse.ModelViews.GoodsReceiptModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWarehouse.Core.Base;
using MWarehouse.ModelViews.UnitModelViews;
namespace MWarehouse.Contract.Service.Interface
{
    public interface IGoodsReceiptService
    {
        // async
        Task CreateAsync(CreateGoodsReceiptModel obj);
        Task UpdateAsync(UpdateGoodsReceiptModel obj);
        Task DeleteAsync(int id); 
        Task<IEnumerable<ReceiptResultModel>> GetAllByBrandAsync(int code);
        Task<IEnumerable<ResponseGoodsReceiptModel>> GetAllAsync();
        Task<ResponseGoodsReceiptModel> GetByIdAsync(int id);
    }
}
