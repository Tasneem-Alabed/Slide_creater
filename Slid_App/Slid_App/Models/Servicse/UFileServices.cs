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

        public Task<UFileDTO> DeleteFile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UFileDTO> GetUFile()
        {
            throw new NotImplementedException();
        }

        public Task<UFileDTO> GitFileByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
