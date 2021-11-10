using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data
{
    public class FakeDB
    {
        public static int customerId = 1;
        public static int genreId = 1;
        public static int videoId = 1;
        public static readonly List<Customer> Customers = new List<Customer>();
        public static readonly List<Genre> Genres = new List<Genre>();
        public static readonly List<Video> Videos = new List<Video>();
    }
}