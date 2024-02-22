using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;

namespace BloodBankWebAPI.Repositories
{
    public class TransfusionRepository : ITransfusionRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;

        public TransfusionRepository(BloodBankContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddTransfusion(AddTransfusionDto transfusion)
        {
            var map = _mapper.Map<Transfusion>(transfusion);    
            await _context.Transfusion.AddAsync(map);
            await _context.SaveChangesAsync();

            var lastAdded= _context.Transfusion.OrderBy(i=>i.Id).LastOrDefault();

            var bloodInventoryRecord = _context.BloodInventorie.Where(i => i.Id == lastAdded.BloodInventoryId).FirstOrDefault();

            bloodInventoryRecord.Quantity = bloodInventoryRecord.Quantity-transfusion.Quantity;

            if (bloodInventoryRecord.Quantity == 0)
            {
               // _context.BloodInventorie.Remove(bloodInventoryRecord);
            }
            _context.SaveChanges();
        }
    }
}
