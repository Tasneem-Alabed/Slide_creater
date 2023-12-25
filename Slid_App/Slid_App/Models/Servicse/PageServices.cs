using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;

namespace Slid_App.Models.Servicse
{
    public class PageServices : IPage
    {
        private readonly SlideAppDbContext _context;

        public PageServices(SlideAppDbContext context)
        {
            _context = context;
        }

        public Task<PageDTO> UpdatePage(int id, PageDTO page)
        {
            throw new NotImplementedException();
        }
    }
}
