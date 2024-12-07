using AutoMapper;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class ProductProfileMapper: Profile
    {
        public ProductProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateProductModel, TblDmSanPham>().ReverseMap();
            CreateMap<ResponseProductModel, TblDmSanPham>().ReverseMap();
        }
    }
}
