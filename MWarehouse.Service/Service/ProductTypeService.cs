using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ProductTypeModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            newProductType.AutoId = IDGenerator.GenerateID(3, await GetAllAsync(), r => r.AutoId);
            newProductType.MaLsp = IDGenerator.Generate("LSP", 3);
            await _iuow.GetRepository<TblDmLoaiSanPham>().InsertAsync(newProductType);
            await _iuow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TblDmLoaiSanPham delProductType = _iuow.GetRepository<TblDmLoaiSanPham>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            await _iuow.GetRepository<TblDmLoaiSanPham>().DeleteAsync(delProductType);
            await _iuow.SaveAsync();
        }

        public async Task<IEnumerable<ResponseProductTypeModel>> GetAllAsync()
        {
            IEnumerable<ResponseProductTypeModel> result = _mapper.Map<IEnumerable<ResponseProductTypeModel>>(await _iuow.GetRepository<TblXnkNhapKho>().GetAllAsync());
            return result;
        }

    }
}
