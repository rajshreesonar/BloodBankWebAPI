using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class AdminMapper : Profile
    {
        public AdminMapper() { 
            CreateMap<AddAdminDto, Admin>().ReverseMap();
            CreateMap<GetAdminDto, Admin>().ReverseMap();
        }
    }
}
