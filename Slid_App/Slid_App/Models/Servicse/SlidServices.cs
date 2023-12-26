using Slid_App.Models.DTO;
using Slid_App.Models.Interfse;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;

namespace Slid_App.Models.Servicse
{
    public class SlidServices : ISlid
    {
        private readonly SlideAppDbContext _context;

        public SlidServices(SlideAppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new SLid
        /// </summary>
        /// <param name="Slids">Slid data.</param>
        public async Task<SlidDTO> CreateSlid(SlidDTO Slids)
        {
            Slid NewSlid = new Slid()
            {
                SlidId = Slids.SlidId,
                UserId = Slids.UserId,
                SlidName = Slids.SlidName,
                SlidUrl= Slids.SlidUrl

            };

            await _context.SaveChangesAsync();

            var retSlid = new SlidDTO() 
            { 
            SlidId = NewSlid.SlidId,
            UserId = NewSlid.UserId,
            SlidName= NewSlid.SlidName,
            SlidUrl = NewSlid.SlidUrl
            };


            return retSlid;
        }

        /// <summary>
        /// Delete a Slid by its ID.
        /// </summary>
        /// <param name="id">ID of the Slid.</param>
        public async Task<SlidDTO> DeleteSlidById(int id)
        {
            var slid = await _context.Slids.FindAsync(id);

            if (slid != null)
            {
                Slid returnSlid = new Slid()
                {
                    SlidId = slid.SlidId,
                    UserId = slid.UserId,
                    SlidName = slid.SlidName,
                    SlidUrl= slid.SlidUrl
                   
                };

                _context.Entry(slid).State = EntityState.Deleted;

                await _context.SaveChangesAsync();


               SlidDTO returnSlidDTO = new SlidDTO
               {
                    SlidId = returnSlid.SlidId,
                   UserId= returnSlid.UserId,
                   SlidName = returnSlid.SlidName,
                   SlidUrl = returnSlid.SlidUrl
                };

                return returnSlidDTO;
            }

            return null;
        }
        /// <summary>
        /// Get a Slid by its Id.
        /// </summary>
        /// <param name="name">name of the UFile.</param>
        public async Task<SlidDTO> GetSlid(int id)
        {
            var slid = await _context.Slids
            .Where(u => u.SlidId == id)
               .FirstOrDefaultAsync();

            if (slid == null)
            {

                return null;
            }
            var sliddto = new SlidDTO
            {
                SlidId= slid.SlidId,
                UserId= slid.UserId,
                SlidName= slid.SlidName,
                SlidUrl=slid.SlidUrl
               

            };

            return sliddto;
        }

        /// <summary>
        /// Git List Of slid by User ID.
        /// </summary>
        /// <param name="id">ID of the User.</param>
        public async Task<List<SlidDTO>> GetSlids(int id)
        {

            var slid = await _context.Slids
                .Where(x => x.UserId == id)
                .ToListAsync();


            List<SlidDTO> sliddto = slid.Select(slids => new SlidDTO
            {
               SlidId=slids.SlidId,
               UserId=slids.UserId,
               SlidName=slids.SlidName,
               SlidUrl=slids.SlidUrl
            }).ToList();

            return sliddto;
        }
        /// <summary>
        /// Update Slid data by ID.
        /// </summary>
        /// <param name="slid">Updated slid data.</param>
        /// <param name="id">ID of the slid to be updated.</param>
        public async Task<SlidDTO> UpdateSlid(int id, SlidDTO slid)
        {
            var update_slid = await _context.Slids.FindAsync(id);

            if (update_slid != null)
            {
                update_slid.SlidId = id;
                update_slid.UserId = slid.UserId;
               update_slid.SlidName=slid.SlidName;
                update_slid.SlidUrl=slid.SlidUrl;
                await _context.SaveChangesAsync();
            }
            slid.UserId = id;
            var slid1 = await GetSlid(slid.SlidId);
            return slid1;
        }
    }
}
