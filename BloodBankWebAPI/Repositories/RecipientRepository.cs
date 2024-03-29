﻿using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWebAPI.Repositories
{
    public class RecipientRepository: IRecipientRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;
        private readonly ITransfusionRepository _transfusionRepository;
        public RecipientRepository(BloodBankContext context, IMapper mapper, ITransfusionRepository transfusion)
        {
            _context = context;
            _mapper = mapper;
            _transfusionRepository = transfusion;
        }
        public async Task<int> AddRecipient(AddRecipientDto addRecipient) 
        {
            var map = _mapper.Map<Recipient>(addRecipient);
            
            var age = DateTime.Now.Year - addRecipient.DOB.Year;
            if ((int)age <= 18)
            {
                throw new BadRequestException("Age must be greater than 18");
            }
            await _context.Recipient.AddAsync(map);
            await _context.SaveChangesAsync();     
            return map.Id;
        }
        public void UpdateRecipient(Recipient UpdateRecipient) 
        {
           // var map = _mapper.Map<Recipient>(UpdateRecipient);
            _context.Recipient.Update(UpdateRecipient);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<Recipient>> GetAllRecipients()
        {
            var allRecipient =  await _context.Recipient.ToListAsync();
          //  var map = _mapper.Map<IEnumerable<GetRecipientDto>>(allRecipient);
            return allRecipient;
        }
    }
}
