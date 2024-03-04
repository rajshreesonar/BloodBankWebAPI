using System.Runtime.CompilerServices;
using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> AddHospital(AddHospitalDto addHospital)
        {
            var map = _mapper.Map<Hospital>(addHospital);
            await _context.Hospital.AddAsync(map);  
            return await _context.SaveChangesAsync(); 
        }

        public async Task<int> UpdateHospital(UpdateHospitalDto updateHospital)
        {
            var map = _mapper.Map<Hospital>(updateHospital);
            _context.Hospital.Update(map);
            new CustomLog().CreateLog(_context);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetHospitalDto>> GetHospitals()
        {
            var hospitals = await _context.Hospital.ToListAsync();
            var map = _mapper.Map<IEnumerable<GetHospitalDto>>(hospitals);
            return map;
        }

    }
}
