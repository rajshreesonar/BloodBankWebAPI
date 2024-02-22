using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class HospitalMapper:Profile
    {
        public HospitalMapper()
        {
            CreateMap<AddHospitalDto, Hospital>().ReverseMap();
            CreateMap<GetHospitalDto, Hospital>().ReverseMap();
            CreateMap<UpdateHospitalDto, Hospital>().ReverseMap();
        }
    }
}
