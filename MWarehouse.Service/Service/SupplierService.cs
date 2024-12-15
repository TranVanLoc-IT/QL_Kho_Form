using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.SupplierModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        /// <summary>
        ///     Tạo mới nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task CreateAsync(CreateSupplierModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            
            TblDmNcc newSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newSupplier is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newSupplier = _mapper.Map<TblDmNcc>(obj);

            newSupplier.MaNcc = IDGenerator.Generate("NCC", 3);
            await _iuow.GetRepository<TblDmNcc>().InsertAsync(newSupplier);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Xóa nhà cung cấp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task DeleteAsync(int id)
        {
            TblDmNcc delSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            delSupplier.IsDeleted = true;
            await _iuow.GetRepository<TblDmNcc>().UpdateAsync(delSupplier);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task UpdateAsync(string id, UpdateSupplierModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblDmNcc newSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newSupplier is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newSupplier = _mapper.Map<TblDmNcc>(obj);
            await _iuow.GetRepository<TblDmNcc>().UpdateAsync(newSupplier);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Lấy hết nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseSupplierModel>> GetAllAsync()
        {
            IEnumerable<ResponseSupplierModel> result = _mapper.Map<IEnumerable<ResponseSupplierModel>>(await _iuow.GetRepository<TblDmNcc>().Entities.Where(r => r.IsDeleted == false).ToListAsync());
            return result;
        }

        /// <summary>
        ///     Lấy nhà cung cấp theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseSupplierModel> GetByIdAsync(int id)
        {
            ResponseSupplierModel result = _mapper.Map<ResponseSupplierModel>(await _iuow.GetRepository<TblDmNcc>().GetByIdAsync(id));
            return result;
        }
    }
}
