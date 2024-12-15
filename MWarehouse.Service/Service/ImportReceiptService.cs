using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;

namespace MWarehouse.Service.Service
{
    public class ImportReceiptService : IImportReceiptService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ImportReceiptService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }

        /// <summary>
        ///  Tạo mới
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task CreateAsync(CreateGoodsReceiptModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            
            TblXnkNhapKho newReceipt = _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newReceipt is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newReceipt = _mapper.Map<TblXnkNhapKho>(obj);
            await _iuow.GetRepository<TblXnkNhapKho>().InsertAsync(newReceipt);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Xóa mềm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task DeleteAsync(int id)
        {
            TblXnkNhapKho delReceipt = _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            IEnumerable<TblXnkNhapKhoRawDatum> details = await _iuow.GetRepository<TblXnkNhapKhoRawDatum>().Entities.Where(u => u.NhapKhoId == delReceipt.AutoId).ToListAsync();
            foreach(TblXnkNhapKhoRawDatum detail in details)
            {
                detail.IsDeleted = true;
                await _iuow.GetRepository<TblXnkNhapKhoRawDatum>().DeleteAsync(detail);
            }
            await _iuow.GetRepository<TblXnkNhapKho>().DeleteAsync(delReceipt);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Cập nhật phiếu
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task UpdateAsync(UpdateGoodsReceiptModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblXnkNhapKho newReceipt = _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newReceipt is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newReceipt = _mapper.Map<TblXnkNhapKho>(obj);

            newReceipt.SoPhieuNhap = IDGenerator.Generate("PN", 8);
            await _iuow.GetRepository<TblXnkNhapKho>().UpdateAsync(newReceipt);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Lấy toàn bộ chi tiết
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReceiptResultModel>> GetAllByBrandAsync(int code)
        {
            IEnumerable<ReceiptResultModel> result = from i in _iuow.GetRepository<TblXnkNhapKho>().Entities
                                                     where i.AutoId == code
                                                     join ct in _iuow.GetRepository<TblXnkNhapKhoRawDatum>().Entities
                                                     on i.AutoId equals ct.NhapKhoId
                                                     group ct by ct.SanPhamId into grouped
                                                     select new ReceiptResultModel()
                                                     {
                                                         SpId = grouped.Key,
                                                         TenSP = _iuow.GetRepository<TblDmSanPham>().Entities
                                                                     .Where(r => r.AutoId == grouped.Key)
                                                                     .Select(r => r.TenSanPham)
                                                                     .FirstOrDefault() ?? "None",
                                                         Quantity = grouped.Sum(g => g.SlNhap)
                                                     };
            return result;

        }

        /// <summary>
        ///     Lấy toàn bộ phiếu
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseGoodsReceiptModel>> GetAllAsync()
        {
            IEnumerable<ResponseGoodsReceiptModel> result = await _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(r => r.IsDeleted == false).Select(r => new ResponseGoodsReceiptModel()
            {
                Id = r.SoPhieuNhap,
                KhoId = r.KhoId,
                NgayNhapKho = r.NgayNhapKho,
                NccId = r.NccId,
                GhiChu = r.GhiChu,
                TrangThai = r.TrangThai
            }).ToListAsync();
            return result;

        }
        /// <summary>
        ///     Duyệt phiếu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task ConfirmAsync(string id)
        {
            TblXnkNhapKho found = await _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(r => r.SoPhieuNhap == id).FirstOrDefaultAsync() ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, "Not found", "Không thấy");
            found.TrangThai = 1;
            await _iuow.GetRepository<TblXnkNhapKho>().UpdateAsync(found);
            await _iuow.GetRepository<TblXnkNhapKho>().SaveAsync();
        }

        /// <summary>
        ///     Lấy phiếu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseGoodsReceiptModel> GetByIdAsync(int id)
        {
            ResponseGoodsReceiptModel result = _mapper.Map<ResponseGoodsReceiptModel>(await _iuow.GetRepository<TblXnkNhapKho>().GetByIdAsync(id));
            return result;
        }

        /// <summary>
        ///     Lấy autoid dùng lấy chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> GetAutoId(string id)
        {
            return await _iuow.GetRepository<TblXnkNhapKho>().Entities.Where(r => r.SoPhieuNhap == id).Select(r => r.AutoId).FirstAsync();
        }
    }
}
