using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class BloodInventoryMapper : Profile
    {
        public BloodInventoryMapper() {
            CreateMap<AddBloodInventoryDto, BloodInventory>().ReverseMap();
            CreateMap<UpdateBloodInventoryDto, BloodInventory>().ReverseMap();
            CreateMap<GetBloodInventoryDto, BloodInventory>().ReverseMap();
        }
    }
}
