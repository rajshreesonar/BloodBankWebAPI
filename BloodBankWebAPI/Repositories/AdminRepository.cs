using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;

namespace BloodBankWebAPI.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;
             
        public AdminRepository(BloodBankContext context,IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public void AddAdmin(Admin addAdmin)
        {
           // var map = _mapper.Map<Admin>(addAdmin);
            _context.Admin.Add(addAdmin);
            _context.SaveChanges();
        }

        public IEnumerable<GetAdminDto> GetAdmin()
        {
            var admins = _context.Admin.ToList();
            var map = _mapper.Map<IEnumerable<GetAdminDto>>(admins);
            return map;
        }
        public IEnumerable<Admin> Login(string username)
        {
            IEnumerable<Admin> admins = _context.Admin
                .Where(i => i.userName.ToLower() == username.ToLower())
                .ToList();
            return admins;
        }

        public bool AleadyRegister(string userName)
        {
            return _context.Admin.Any(i => i.userName == userName);
        }
    }
}
