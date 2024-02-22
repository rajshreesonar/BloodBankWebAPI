using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class TransfusionMapper : Profile
    {
        public TransfusionMapper()
        {
            CreateMap<AddTransfusionDto, Transfusion>().ReverseMap();
        }
    }
}
