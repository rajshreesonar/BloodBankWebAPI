using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Mappers
{
    public class RecipientMapper: Profile
    {
        public RecipientMapper()
        {
            CreateMap<AddRecipientDto, Recipient>().ReverseMap();
            CreateMap<UpdateRecipientDto, Recipient>().ReverseMap();
            CreateMap<GetRecipientDto, Recipient>().ReverseMap();
        }
    }
}
