using MWarehouse.ModelViews.GoodsReceiptDetailModelViews;
using MWarehouse.ModelViews.GoodsReceiptModelDetailViews;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IImportReceiptDetailService
    {
        Task CreateAsync(IEnumerable<CreateGoodsReceiptDetailModel> obj);
        Task<IEnumerable<ResponseGoodsReceiptDetailModel>> GetAllAsync(int code);
    }
}
