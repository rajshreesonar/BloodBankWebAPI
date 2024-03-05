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
    public class BloodInventoryRepository: IBloodInventoryRepository
    {
        private readonly BloodBankContext _context
            ;
        private readonly IMapper _mapper;

        

        public BloodInventoryRepository(BloodBankContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddBloodInventory(AddBloodInventoryDto addBloodInventory)
        {
            var map= _mapper.Map<BloodInventory>(addBloodInventory);
            await _context.BloodInventorie.AddAsync(map);
            return await _context.SaveChangesAsync();
        }

        public void UpdateBloodInventory(UpdateBloodInventoryDto updateBloodInventory)
        {
            var map = _mapper.Map<BloodInventory>(updateBloodInventory);
            _context.BloodInventorie.Update(map);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<BloodInventory>> GetBloodInventories()
        {
            var bloodInventories= _context.BloodInventorie.Include(i => i.Donation).ThenInclude(i=>i.Donor).ToList();
            
            return bloodInventories;
        }


    }
}
