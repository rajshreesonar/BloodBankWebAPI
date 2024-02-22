using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class DonorMapper:Profile
    {
        public DonorMapper() {
            CreateMap<AddDonorDto, Donor>().ReverseMap();
            CreateMap<GetDonorDto, Donor>().ReverseMap();
            CreateMap<UpdateDonorDto, Donor>().ReverseMap();
        }
    }
}
