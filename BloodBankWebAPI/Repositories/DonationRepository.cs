using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWebAPI.Repositories
{
    public class DonationRepository :IDonationRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;
        private readonly IBloodInventoryRepository _inventoryRepository;
        public DonationRepository(BloodBankContext context,IMapper mapper, IBloodInventoryRepository bloodInventory) 
        { 
            _context = context;
            _mapper = mapper;
            _inventoryRepository = bloodInventory;
        }

        public void AddDonation(AddDonationDto addDonation)
        {
            var map= _mapper.Map<Donation>(addDonation);
            _context.Donation.Add(map);
            _context.SaveChanges();
            
            var donation = _context.Donation.OrderBy(item => item.ID).LastOrDefault();
           
            AddBloodInventoryDto addBloodInventory = new AddBloodInventoryDto();

            addBloodInventory.DonationId = donation.ID;
            addBloodInventory.Quantity = donation.Quantity_ML;
            addBloodInventory.BloodType = donation.BloodType;
            addBloodInventory.ExpiryDate = donation.DonationDate.AddDays(5);

            _inventoryRepository.AddBloodInventory(addBloodInventory);
        }
        public void UpdateDonation(UpdateDonationDto updateDonation)
        {
             var map = _mapper.Map<Donation>(updateDonation);
            _context.Donation.Update(map);
            _context.SaveChanges();
        }
        public IEnumerable<GetDonationDto> GetDonations()
        {
            var donations= _context.Donation.Include(i=>i.Donor).ToList();
            var map = _mapper.Map<IEnumerable<GetDonationDto>>(donations);
            return map;
        }

        
    }
}
