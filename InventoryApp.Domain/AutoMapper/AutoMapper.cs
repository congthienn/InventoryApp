using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Provinces, ProvinceDTO>().ForMember(dest => dest.Division_Type, opt => opt.MapFrom(src => src.DivisionType)).
                                                ForMember(dest => dest.Phone_Code, opt => opt.MapFrom(src => src.PhoneCode)).ReverseMap();
        }
    }
    public static class GetMapperConfiguration
    {
        public static MapperConfiguration Run()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<AutoMapper>());
        }
    }
}