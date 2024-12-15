using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ExportReceiptModelView;
using MWarehouse.Repository.Models;

namespace MWarehouse.Service.Service
{
    public class ExportReceiptService : IExportReceiptService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ExportReceiptService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }

        public async Task ConfirmAsync(int id)
        {   TblXnkXuatKho found = await _iuow.GetRepository<TblXnkXuatKho>().Entities.Where(r => r.AutoId == id).FirstOrDefaultAsync() ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, "Not found", "Không thấy");
            found.TrangThai = 1;
            await _iuow.GetRepository<TblXnkXuatKho>().UpdateAsync(found);
            await _iuow.GetRepository<TblXnkXuatKho>().SaveAsync();
        }

        public async Task<IEnumerable<ResponseExportReceiptModel>> GetAllAsync()
        {
            IEnumerable<TblXnkXuatKho> data = await _iuow.GetRepository<TblXnkXuatKho>().Entities.Where(r => r.IsDeleted == false).ToListAsync();
            var result = _mapper.Map<IEnumerable<ResponseExportReceiptModel>>(data);
            return result;
        }

        public async Task<int> GetAutoId(string id)
        {
            return await _iuow.GetRepository<TblXnkXuatKho>().Entities.Where(r => r.SoPhieuXuat == id).Select(r => r.AutoId).FirstAsync();

        }
    }
}
