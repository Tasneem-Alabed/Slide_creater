using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;

namespace Slid_App.Models.Servicse
{
    public class UFileServices : IUFile
    {
        private readonly SlideAppDbContext _context;

        public UFileServices(SlideAppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create a new UFile.
        /// </summary>
        /// <param name="FileU">Data for the new UFile.</param>
        public async Task<UFileDTO> CreateUFile(UFileDTO FileU)
        {
            //var Ufile = await _context.Users.FindAsync(FileU.UserId);
            
            UFile Fileu = new UFile()
            {
               UserId = FileU.UserId,
               Name = FileU.Name,
               ImageUrl = FileU.ImageUrl,
               VideoUrl = FileU.VideoUrl
            };

            _context.Entry(Fileu).State = EntityState.Added;
            await _context.SaveChangesAsync();

            UFileDTO createdUFileDTO = new UFileDTO
            {
                UserId = Fileu.UserId,
                Name = Fileu.Name,
                ImageUrl = Fileu.ImageUrl,
                VideoUrl = Fileu.VideoUrl
            };

            return createdUFileDTO;
        }

        /// <summary>
        /// Delete a UFile by its ID.
        /// </summary>
        /// <param name="id">ID of the UFile.</param>
        public async Task<UFileDTO> DeleteFile(int id)
        {
            var Ufile = await _context.UFiles.FindAsync(id);

            if (Ufile != null)
            {
                UFile returnFile = new UFile()
                {
                    UserId = Ufile.UserId,
                    Name = Ufile.Name,
                    ImageUrl = Ufile.ImageUrl,
                    VideoUrl = Ufile.VideoUrl
                };

                _context.Entry(Ufile).State = EntityState.Deleted;

                await _context.SaveChangesAsync();

               
                UFileDTO returnFileDTO = new UFileDTO
                {
                    UserId = returnFile.UserId,
                    Name = returnFile.Name,
                    ImageUrl = returnFile.ImageUrl,
                    VideoUrl = returnFile.VideoUrl
                };

                return returnFileDTO;
            }

            return null;
        
    }

        /// <summary>
        /// Git List Of UFile by User ID.
        /// </summary>
        /// <param name="id">ID of the User.</param>
        public async Task<List<UFileDTO>> GetUFile(int id)
        {
          
                var uFiles = await _context.UFiles
                    .Where(file => file.UserId == id)
                    .ToListAsync();

               
                List<UFileDTO> uFileDTOs = uFiles.Select(file => new UFileDTO
                {
                    UserId = file.UserId,
                    Name = file.Name,
                   ImageUrl = file.ImageUrl,
                   VideoUrl = file.VideoUrl
                }).ToList();

                return uFileDTOs;
            }


        /// <summary>
        /// Get a UFile by its Name.
        /// </summary>
        /// <param name="name">name of the UFile.</param>
        public async Task<UFileDTO> GitFileByName(string name)
        {
            var FileU = await _context.UFiles
            .Where(u => u.Name == name)
               .FirstOrDefaultAsync();

            if (FileU == null)
            {

                return null;
            }
            var fileDto = new UFileDTO
            {
               
                Name = FileU.Name,
                UserId = FileU.UserId,
                ImageUrl = FileU.ImageUrl,
                VideoUrl = FileU.VideoUrl



            };

            return fileDto;
        }
    }
}
