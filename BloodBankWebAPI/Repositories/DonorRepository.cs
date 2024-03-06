using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> AddDonor(Donor addDonor)
        {
            //var map=_mapper.Map<Donor>(addDonor);

          /*  if (addDonor.adharUpload is not null)
            {
                var directoryPath = Directory.GetCurrentDirectory() + "\\uploads";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var filePath = Path.Combine(directoryPath, addDonor.adharUpload.FileName);

                using (var stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    addDonor.adharUpload.CopyToAsync(stream);
                }
                map.FilePath = filePath;
            }


            var age = DateTime.Now.Year - addDonor.Dob.Year;
            if ((int)age <= 18)
            {
                throw new BadRequestException("Age must be greater than 18");
            }*/
            await _context.Donor.AddAsync(addDonor);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donor>> GetAllDonors()
        {

            var allDonors = await _context.Donor.ToListAsync();

            //if (!allDonors.Any() || allDonors == null) 
            //{
            //    throw new NotFoundException("Donor not found.");
            //}

            //foreach (var item in allDonors)
            //{
            //    var provider = new FileExtensionContentTypeProvider();
            //    if (!provider.TryGetContentType(item.FilePath, out var contentType))
            //    {
            //        contentType = "application/octet-stream";
            //    }
            //    var bytes = System.IO.File.ReadAllBytesAsync(item.FilePath);
            //    map. File(bytes, contentType, Path.GetFileName(item.FilePath));
            //}
            

            return allDonors;
        }

        public async Task<int> UpdateDonor([FromForm]Donor updateDonor)
        {
            //  var donor= _context.Donor.FirstOrDefault(i=>i.Id == updateDonor.Id);
            //    var map= _mapper.Map<Donor>(updateDonor);
            _context.Donor.Update(updateDonor);
          //  new CustomLog().CreateLog(_context);
            return await _context.SaveChangesAsync();
        }

    }
}
