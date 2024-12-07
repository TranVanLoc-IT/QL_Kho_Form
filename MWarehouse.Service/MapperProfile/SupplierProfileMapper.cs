using AutoMapper;
using MWarehouse.ModelViews.SupplierModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class SupplierProfileMapper: Profile
    {
        public SupplierProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateSupplierModel, TblDmNcc>().ReverseMap();
            CreateMap<ResponseSupplierModel, TblDmNcc>().ReverseMap();
            CreateMap<UpdateSupplierModel, TblDmNcc>().ReverseMap();
        }
    }
}
