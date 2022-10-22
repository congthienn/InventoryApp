using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.DTO.Users;
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
            CreateMap<Districts, DistrictDTO>().ForMember(dest => dest.Division_Type, opt => opt.MapFrom(src => src.DivisionType)).ReverseMap();
            CreateMap<Wards, WardDTO>().ForMember(dest => dest.Division_Type, opt => opt.MapFrom(src => src.DivisionType)).ReverseMap();
            CreateMap<EmailTemplate, EmailTemplateCreateModel>().ReverseMap();
            CreateMap<Roles, RoleModelRq>().ReverseMap();
            CreateMap<Users, UserUpdateRq>().ReverseMap();
            CreateMap<Users, UserModelRq>().ReverseMap();
            CreateMap<Companies, CompanyModelRq>().ReverseMap();
            CreateMap<Companies, CompanyUpdateModelRq>().ReverseMap();
        }
    }
    public static class AutoMapperHelper
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<AutoMapper>());
        }
        public static class Map<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class
        {
            public static TEntity Run(IMapper mapper,TEntityDTO entityDTO)
            {
                TEntity entity = Activator.CreateInstance(typeof(TEntity)) as TEntity;
                mapper.Map(entityDTO,entity);
                return entity;
            }
        }
    }
    
}