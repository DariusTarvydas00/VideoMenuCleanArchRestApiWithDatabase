using Microsoft.EntityFrameworkCore;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data
{
    public class VideoMenuAppContext : DbContext
    {
        public VideoMenuAppContext(DbContextOptions<VideoMenuAppContext>opt): base(opt)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        
    }
}