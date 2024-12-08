using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateProductModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblDmSanPham newProduct = _iuow.GetRepository<TblDmSanPham>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newProduct is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newProduct = _mapper.Map<TblDmSanPham>(obj);
            newProduct.MaSanPham = IDGenerator.Generate("SP", 6);
            await _iuow.GetRepository<TblDmSanPham>().InsertAsync(newProduct);
            await _iuow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TblDmSanPham delProduct = _iuow.GetRepository<TblDmSanPham>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            await _iuow.GetRepository<TblDmSanPham>().DeleteAsync(delProduct);
            await _iuow.SaveAsync();
        }

        public async Task<IEnumerable<ResponseProductModel>> GetAllAsync()
        {
            IEnumerable<ResponseProductModel> result = _mapper.Map<IEnumerable<ResponseProductModel>>(await _iuow.GetRepository<TblDmSanPham>().GetAllAsync());
            return result;
        }

        public async Task<ResponseProductModel> GetByIdAsync(int id)
        {
            ResponseProductModel result = _mapper.Map<ResponseProductModel>(await _iuow.GetRepository<TblDmSanPham>().GetByIdAsync(id));
            return result;
        }

        public async Task UpdateAsync(string id, UpdateProductModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblDmSanPham newProduct = _iuow.GetRepository<TblDmSanPham>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newProduct is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newProduct = _mapper.Map<TblDmSanPham>(obj);
            await _iuow.GetRepository<TblDmSanPham>().UpdateAsync(newProduct);
            await _iuow.SaveAsync();
        }

        public async Task UpdateProductTypeAsync(int id, int type)
        {
            TblDmSanPham product = _iuow.GetRepository<TblDmSanPham>().Entities.Where(u => u.AutoId == id).FirstOrDefault()!;

            product.LoaiSanPhamId = type;
            await _iuow.GetRepository<TblDmSanPham>().UpdateAsync(product);

            await _iuow.SaveAsync();
        }

        public async Task UpdateUnitAsync(int id, int[] obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            foreach(int model in obj)
            {
                TblDmSanPham product = _iuow.GetRepository<TblDmSanPham>().Entities.Where(u => u.AutoId == model).FirstOrDefault()!;

                product.DonViTinhId = id;
                await _iuow.GetRepository<TblDmSanPham>().UpdateAsync(product);
            }
           
            await _iuow.SaveAsync();
        }
    }
}
