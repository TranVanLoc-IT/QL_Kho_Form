using AutoMapper;
using MWarehouse.ModelViews.ProductTypeModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class ProductTypeProfileMapper: Profile
    {
        public ProductTypeProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateProductTypeModel, TblDmLoaiSanPham>().ReverseMap();
            CreateMap<ResponseProductTypeModel, TblDmLoaiSanPham>().ReverseMap();
        }
    }
}
