using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

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

            if (addDonor.adharUpload is not null)
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
            }
            _context.Donor.Add(map);
            _context.SaveChanges();
        }

        public IEnumerable<GetDonorDto> GetAllDonors()
        {
            
            var allDonors = _context.Donor.ToList();
            var map = _mapper.Map<IEnumerable<GetDonorDto>>(allDonors);

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
            

            return map;
        }

        public void UpdateDonor([FromForm]UpdateDonorDto updateDonor)
        {
          //  var donor= _context.Donor.FirstOrDefault(i=>i.Id == updateDonor.Id);
            var map= _mapper.Map<Donor>(updateDonor);
            _context.Donor.Update(map);
            new CustomLog().CreateLog(_context);
            _context.SaveChanges();
        }

    }
}
