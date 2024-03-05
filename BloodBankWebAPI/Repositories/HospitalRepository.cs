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
        private readonly ILogger<IHospitalRepository> _logger;

        public HospitalRepository(BloodBankContext context, ILogger<IHospitalRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddHospital(Hospital addHospital)
        {
            await _context.Hospital.AddAsync(addHospital);
            CustomLog.CreateLog(_context, _logger);
            return await _context.SaveChangesAsync(); 
        }
        public async Task<int> UpdateHospital(Hospital updateHospital)
        {           
            _context.Hospital.Update(updateHospital);
            CustomLog.CreateLog(_context,_logger);
            return await _context.SaveChangesAsync();   
        }
        public async Task<IEnumerable<Hospital>> GetHospitals()
        {
            var hospitals = await _context.Hospital.ToListAsync();     
            return hospitals;
        }

        public async Task<Hospital> GetHospitalById(int id)
        {
            var hospital =await _context.Hospital.Where(i=>i.Id==id).FirstOrDefaultAsync();
            return hospital;
        }

    }
}
