using System;
using Microsoft.EntityFrameworkCore;
using SQL.Entities;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL
{
    public class VideoMenuDbContext : DbContext
    {
        public VideoMenuDbContext(DbContextOptions<VideoMenuDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoEntity>().HasOne(video => video.Genre).WithMany()
                .HasForeignKey(v => new {v.GenreId}).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<CustomerEntity>().HasMany<Video>(entity => entity.Video).WithMany(c => Customers);
            modelBuilder.Entity<CustomerEntity>().HasData(new CustomerEntity()
            {
                Id = 1,
                FirstName = "1",
                LastName = "2",
                Address = "Sll",
                Email = "asd@asd.lt",
                Birthday = DateTime.Now.AddYears(-25),
                PhoneNumber = 123456789,
                VideoId = 1
            });
            modelBuilder.Entity<CustomerEntity>().HasData(new CustomerEntity()
            {
                Id = 2,
                FirstName = "3",
                LastName = "4",
                Address = "Sll",
                Email = "asd@asd.lt",
                Birthday = DateTime.Now.AddYears(-25),
                PhoneNumber = 123456789,
                VideoId = 2
            });
            modelBuilder.Entity<CustomerEntity>().HasData(new CustomerEntity()
            {
                Id = 3,
                FirstName = "3",
                LastName = "4",
                Address = "Sll",
                Email = "asd@asd.lt",
                Birthday = DateTime.Now.AddYears(-25),
                PhoneNumber = 123456789,
                VideoId = 3
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 1, 
                Title = "Star",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Pow Pow",
                GenreId = 1
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 2, 
                Title = "Wars",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Bum Bum",
                GenreId = 2
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 3, 
                Title = "Star Wars",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Bum Bum POW POW",
                GenreId = 1
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 4, 
                Title = "Something",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Nothing",
                GenreId = 1
                
            });
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity() {Id = 1, Type = "Fantasy"});
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity() {Id = 2, Type = "Comedy"});
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity() {Id = 3, Type = "Horror"});
        }

        public DbSet<CustomerEntity> Customers { get; set; } //Customer should be used as CustomerEntity in EF core project not Core blueprint
        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
    }
}