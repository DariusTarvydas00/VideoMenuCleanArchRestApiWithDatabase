using Microsoft.EntityFrameworkCore;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data
{
    public class VideoMenuAppContext : DbContext
    {
        public VideoMenuAppContext(DbContextOptions<VideoMenuAppContext>opt): base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasOne(video => video.Customer).WithMany(customers => customers.Videos)
                .OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Customer>().HasData(new CustomerEntity() {Id = 1});
        }

        public DbSet<Customer> Customers { get; set; } //Customer should be used as CustomerEntity in EF core project not Core blueprint
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        
    }
}