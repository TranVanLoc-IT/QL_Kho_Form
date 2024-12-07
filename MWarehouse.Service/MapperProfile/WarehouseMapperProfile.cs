using AutoMapper;
using MWarehouse.ModelViews.WarehouseModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class WarehouseMapperProfile: Profile
    {
        public WarehouseMapperProfile() {
            CreateMap<CreateWarehouseModel, TblDmKho>().ReverseMap();
            CreateMap<ResponseWarehouseModel, TblDmKho>().ReverseMap();
        }
    }
}
