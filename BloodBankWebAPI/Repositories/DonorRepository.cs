using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;

namespace BloodBankWebAPI.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;

        public DonorRepository(BloodBankContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void AddDonor(AddDonorDto addDonor)
        {
            var map=_mapper.Map<Donor>(addDonor);
            _context.Donor.Add(map);
            _context.SaveChanges();
        }

        public IEnumerable<GetDonorDto> GetAllDonors()
        {
            var allDonors = _context.Donor.ToList();
            var map = _mapper.Map<IEnumerable<GetDonorDto>>(allDonors);
            return map;
        }

        public void UpdateDonor(UpdateDonorDto updateDonor)
        {
          //  var donor= _context.Donor.FirstOrDefault(i=>i.Id == updateDonor.Id);
            var map= _mapper.Map<Donor>(updateDonor);
            _context.Donor.Update(map);
            _context.SaveChanges();
        }

    }
}
