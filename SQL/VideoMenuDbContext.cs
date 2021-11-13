using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Customer>().HasOne(video => video.Videos).WithMany();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(new Genre() {Id = 1, Type = "asd"});
        }

        public DbSet<Customer> Customers { get; set; } //Customer should be used as CustomerEntity in EF core project not Core blueprint
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}