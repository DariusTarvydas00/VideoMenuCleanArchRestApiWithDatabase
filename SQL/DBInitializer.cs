using System;
using System.Collections.Generic;
using SQL.Entities;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL
{
    public static class DbInitializer
    {
        public static void SeedDb(VideoMenuDbContext ctx)
        {
                 ctx.Database.EnsureDeleted();
                                    ctx.Database.EnsureCreated();
                                    var cust1 = ctx.Customers.Add(new CustomerEntity()
                                    {
                                        FirstName = "Darius",
                                        LastName = "Tarvydas",
                                        Address = "Sll",
                                        Email = "asd@asd.lt",
                                        Birthday = DateTime.Now.AddYears(-25),
                                        PhoneNumber = 123456789
                                    }).Entity;
                                    
                                    var cust2 = ctx.Customers.Add(new CustomerEntity()
                                    {
                                        FirstName = "sadfasdf",
                                        LastName = "asdfasdf",
                                        Address = "Sll",
                                        Email = "asd@asd.lt",
                                        Birthday = DateTime.Now.AddYears(-25),
                                        PhoneNumber = 123456789
                                    }).Entity;
                
                                    var gen1 = ctx.Genres.Add(new GenreEntity()
                                    {
                                        Type = "Fantasy"
                                    }).Entity;
                                    
                                    var gen2 = ctx.Genres.Add(new GenreEntity()
                                    {
                                        Type = "Comedy"
                                    }).Entity;
                
                                    var vid1 = ctx.Videos.Add(new VideoEntity()
                                    {
                                        Title = "Star",
                                        ReleaseDate = DateTime.Now.AddYears(-10),
                                        StoryLine = "adsadfasdfasdfasdfasdf",
                                        GenreEntityId = 1
                                    }).Entity;
                                    
                                    var vid2 = ctx.Videos.Add(new VideoEntity()
                                    {
                                        Title = "Wars",
                                        ReleaseDate = DateTime.Now.AddYears(-10),
                                        StoryLine = "adsadfasdfasdfasdfasdf",
                                        GenreEntityId = 2
                                    }).Entity;
                
                                    ctx.SaveChanges();
            
        }
    }
}