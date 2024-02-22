using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class DonationMapper: Profile
    {
        public DonationMapper() 
        {
            CreateMap<AddDonationDto,Donation>().ReverseMap();
            CreateMap<UpdateDonationDto, Donation>().ReverseMap();
            CreateMap<GetDonationDto, Donation>().ReverseMap(); 

        }
    }
}
