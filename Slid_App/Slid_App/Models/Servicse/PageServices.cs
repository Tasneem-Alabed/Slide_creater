﻿using Slid_App.Models.DTO;
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

        /// <summary>
        /// Create a new Page.
        /// </summary>
        /// <param name="page">Data for the new =page.</param>
        public async Task<PageDTO> Create(PageDTO page)
        {
            Page pag = new Page()
            {
               SlidId=page.SlidId,
               Text=page.Text,
               ImageBase64 = page.ImageBase64,
               VideoUrl = page.VideoUrl
            };

            _context.Entry(pag).State = EntityState.Added;
            await _context.SaveChangesAsync();

            PageDTO createdUSlidDTO = new PageDTO
            {
               SlidId=pag.SlidId,
               Text=pag.Text,
               ImageBase64 = pag.ImageBase64,
               VideoUrl = pag.VideoUrl
             

            };

            return createdUSlidDTO;
        }

        /// <summary>
        /// Delete a page by its ID.
        /// </summary>
        /// <param name="id">ID of the page.</param>
        public async Task<PageDTO> Delete(int id)
        {
            var delete_page = await _context.Pages.FindAsync(id);

            if (delete_page != null)
            {
                PageDTO retyrnpage = new PageDTO()
                {
                    Id= delete_page.Id,
                    SlidId = delete_page.SlidId,
                    Text=delete_page.Text,
                    ImageBase64=delete_page.ImageBase64,
                    VideoUrl = delete_page.VideoUrl
                };

                _context.Entry(delete_page).State = EntityState.Deleted;

                await _context.SaveChangesAsync();


                
                return retyrnpage;
            }

            return null;
        }

        /// <summary>
        /// Get a page by its ID.
        /// </summary>
        /// <param name="id">ID of the page.</param>
        public async Task<PageDTO> Get(int id)
        {
            var page = await _context.Pages
             .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            if (page == null)
            {

                return null;
            }
            var pagedto = new PageDTO
            {

              SlidId= page.SlidId,
              Text= page.Text,
              ImageBase64= page.ImageBase64,
              VideoUrl = page.VideoUrl

            };

            return pagedto;

        }

        public async Task<PageDTO> UpdatePage(int id, PageDTO page)
        {
            var update_page = await _context.Pages.FindAsync(id);

            if (update_page != null)
            {
                update_page.Text = page.Text;
                update_page.VideoUrl = page.VideoUrl;
              
                update_page.ImageBase64 = page.ImageBase64;
                  await _context.SaveChangesAsync();
            }
            page.Id = id;
            var page1 = await Get(page.Id);
            return page1;
        }
    }
}
