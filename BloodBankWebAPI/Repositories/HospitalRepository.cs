using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Repositories
{
    public class HospitalRepository: IHospitalRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;

        public HospitalRepository(BloodBankContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddHospital(AddHospitalDto addHospital)
        {
            var map = _mapper.Map<Hospital>(addHospital);
            _context.Hospital.Add(map);
            _context.SaveChanges(); 
        }

        public void UpdateHospital(UpdateHospitalDto updateHospital)
        {
            var map = _mapper.Map<Hospital>(updateHospital);
            _context.Hospital.Update(map);
            new CustomLog().CreateLog(_context);
            _context.SaveChanges();
        }

        public IEnumerable<GetHospitalDto> GetHospitals()
        {
            var hospitals = _context.Hospital.ToList();
            var map = _mapper.Map<IEnumerable<GetHospitalDto>>(hospitals);
            return map;
        }

    }
}
