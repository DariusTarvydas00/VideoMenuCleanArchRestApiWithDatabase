using System;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void SeedDb(VideoMenuAppContext ctx)
        {
                 ctx.Database.EnsureDeleted();
                                    ctx.Database.EnsureCreated();
                                    var cust1 = ctx.Customers.Add(new Customer()
                                    {
                                        FirstName = "Darius",
                                        LastName = "Tarvydas",
                                        Address = "Sll",
                                        Email = "asd@asd.lt",
                                        Birthday = DateTime.Now.AddYears(-25),
                                        PhoneNumber = 123456789
                                    }).Entity;
                                    
                                    var cust2 = ctx.Customers.Add(new Customer()
                                    {
                                        FirstName = "sadfasdf",
                                        LastName = "asdfasdf",
                                        Address = "Sll",
                                        Email = "asd@asd.lt",
                                        Birthday = DateTime.Now.AddYears(-25),
                                        PhoneNumber = 123456789
                                    }).Entity;
                
                                    var gen1 = ctx.Genres.Add(new Genre()
                                    {
                                        Type = "Fantasy"
                                    }).Entity;
                                    
                                    var gen2 = ctx.Genres.Add(new Genre()
                                    {
                                        Type = "Comedy"
                                    }).Entity;
                
                                    var vid1 = ctx.Videos.Add(new Video()
                                    {
                                        Title = "Star",
                                        ReleaseDate = DateTime.Now.AddYears(-10),
                                        StoryLine = "adsadfasdfasdfasdfasdf",
                                        Customer = cust1
                                    }).Entity;
                                    
                                    var vid2 = ctx.Videos.Add(new Video()
                                    {
                                        Title = "Wars",
                                        ReleaseDate = DateTime.Now.AddYears(-10),
                                        StoryLine = "adsadfasdfasdfasdfasdf",
                                        Customer = cust2
                                    }).Entity;
                
                                    ctx.SaveChanges();
            
        }
    }
}