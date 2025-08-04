using AssetManagement.Models;
using AssetManagement.Models.DTOs;
using AutoMapper;

namespace AssetManagement.Mappers
{
    public class AssetManagementMapperProfile : Profile
    {
        public AssetManagementMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Asset, AssetDTO>().ReverseMap();

        }
    }
}
