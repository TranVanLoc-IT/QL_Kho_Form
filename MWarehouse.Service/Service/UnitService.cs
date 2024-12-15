using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;
using System.Collections.Generic;

namespace MWarehouse.Service.Service
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public UnitService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        /// <summary>
        ///     Tạo mới DVT
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task CreateAsync(CreateUnitModel obj)
        {
            if(obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            TblDmDonViTinh newUnit = _iuow.GetRepository<TblDmDonViTinh>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if(newUnit != null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newUnit = _mapper.Map<TblDmDonViTinh>(obj);
            newUnit.MaDvt = newUnit.TenDvt.ToUpper();
            await _iuow.GetRepository<TblDmDonViTinh>().InsertAsync(newUnit);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Xóa DVT
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task DeleteAsync(int id)
        {
            TblDmDonViTinh delUnit = _iuow.GetRepository<TblDmDonViTinh>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            delUnit.IsDeleted = true;
            await _iuow.GetRepository<TblDmDonViTinh>().UpdateAsync(delUnit);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Lấy toàn bộ DVT
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseUnitModel>> GetAllAsync()
        {
            IEnumerable<ResponseUnitModel> result = _mapper.Map<IEnumerable<ResponseUnitModel>>(await _iuow.GetRepository<TblDmDonViTinh>().GetAllAsync());
            return result;
        }

        /// <summary>
        ///     Lấy toàn bộ sp áp dụng
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseProductModel>> GetAllProductAsync(int code)
        {
            IEnumerable<ResponseProductModel> result = _mapper.Map<IEnumerable<ResponseProductModel>>((await _iuow.GetRepository<TblDmSanPham>().GetAllAsync()).Where(r => r.DonViTinhId == code));
            return result;
        }
    }
}
