using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.Identity.Client;





namespace Slid_App.Models
{
    public class SlideAppDbContext : DbContext
    {

        public SlideAppDbContext(DbContextOptions<SlideAppDbContext> option) : base(option)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
            {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Page>().HasKey(
            Page => new { Page.SlidId }
            );
            modelBuilder.Entity<Slid>().HasKey(
               slid => new { slid.UserId }
               );
            modelBuilder.Entity<UFile>().HasKey(
              UFile => new { UFile.UserId }
              );
            modelBuilder.Entity<Page>()
             .HasKey(page => page.Id);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    DateOfBerth = "1990-01-01", 
                    PhoneNumber = "123-456-7890",
                    ImageBase64 = "base64encodedimage" 
                });

          
            modelBuilder.Entity<Slid>().HasData(
                new Slid
                {
                    SlidId = 1,
                    UserId = 1,
                    SlidName = "Sample Slid",
                     SlidUrl = $"/slides/1/Slid"
                });

            modelBuilder.Entity<Page>().HasData(
                new Page
                {
                    Id = 1,
                    SlidId = 1,
                    Text = "Page Content"
                   
                });

            modelBuilder.Entity<UFile>().HasData(
                new UFile
                {
                    Id = 1,
                    UserId = 1,
                    Name = "Sample File",
                    ImageUrl = "https://example.com/sample.jpg", // Replace with actual URL
                    VideoUrl = "https://example.com/sample.mp4"  // Replace with actual URL
                });

           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Slid> Slids { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<UFile> UFiles { get; set; }
    }
}
