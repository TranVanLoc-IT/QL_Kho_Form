using AutoMapper;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class UnitProfileMapper: Profile
    {
        public UnitProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateUnitModel, TblDmDonViTinh>().ReverseMap();   
            CreateMap<ResponseUnitModel, TblDmDonViTinh>().ReverseMap();   
        }
    }
}
