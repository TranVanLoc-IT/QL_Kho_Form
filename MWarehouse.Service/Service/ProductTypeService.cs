using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ProductTypeModelViews;
using MWarehouse.Repository.Models;

namespace MWarehouse.Service.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ProductTypeService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        /// <summary>
        ///     Tạo mới LSP
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task CreateAsync(CreateProductTypeModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblDmLoaiSanPham newProductType = _iuow.GetRepository<TblDmLoaiSanPham>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newProductType is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newProductType = _mapper.Map<TblDmLoaiSanPham>(obj);

            newProductType.MaLsp = IDGenerator.Generate("LSP", 3);
            await _iuow.GetRepository<TblDmLoaiSanPham>().InsertAsync(newProductType);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Xóa LSP đã có
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task DeleteAsync(int id)
        {
            TblDmLoaiSanPham delProductType = _iuow.GetRepository<TblDmLoaiSanPham>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            delProductType.IsDeleted = true;
            await _iuow.GetRepository<TblDmLoaiSanPham>().UpdateAsync(delProductType);
            await _iuow.SaveAsync();
        }
        /// <summary>
        ///     Lấy toàn bộ LSP chưa xóa
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseProductTypeModel>> GetAllAsync()
        {
            IEnumerable<ResponseProductTypeModel> result = _mapper.Map<IEnumerable<ResponseProductTypeModel>>(await _iuow.GetRepository<TblDmLoaiSanPham>().Entities.Where(r => r.IsDeleted == false).ToListAsync());
            return result;
        }

    }
}
