using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;

namespace Slid_App.Models.Servicse
{
    public class SlidServices : ISlid
    {
        private readonly SlideAppDbContext _context;

        public SlidServices(SlideAppDbContext context)
        {
            _context = context;
        }

        public Task<SlidDTO> CreateSlid(SlidDTO Slids)
        {
            throw new NotImplementedException();
        }

        public Task<SlidDTO> DeleteSlidById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SlidDTO> GetSlid(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SlidDTO>> GetSlids()
        {
            throw new NotImplementedException();
        }

        public Task<SlidDTO> UpdateSlid(int id, SlidDTO slid)
        {
            throw new NotImplementedException();
        }
    }
}
