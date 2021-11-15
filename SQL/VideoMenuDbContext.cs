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
            modelBuilder.Entity<Video>().HasOne(video => video.Customer).WithMany(customers => customers.Videos)
                .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Customer>().HasOne(video => video.Videos).WithMany();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerEntity>().HasData(new CustomerEntity()
            {
                Id = 1,
                FirstName = "1",
                LastName = "2",
                Address = "Sll",
                Email = "asd@asd.lt",
                Birthday = DateTime.Now.AddYears(-25),
                PhoneNumber = 123456789,
                VideoEntityId = 1
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
                VideoEntityId = 2
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
                VideoEntityId = 3
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 1, 
                Title = "Star",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Pow Pow",
                GenreEntityId = 1
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 2, 
                Title = "Wars",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Bum Bum",
                GenreEntityId = 2
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 3, 
                Title = "Star Wars",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Bum Bum POW POW",
                GenreEntityId = 1
                
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity() 
            {
                Id = 4, 
                Title = "Something",
                ReleaseDate = DateTime.Now.AddYears(-10),
                StoryLine = "Nothing",
                GenreEntityId = 1
                
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