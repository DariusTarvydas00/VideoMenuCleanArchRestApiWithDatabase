﻿using System;
using System.Collections.Generic;

namespace VideoMenuConsoleApp.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public List<Video> Videos { get; set; }
        public int VideosId { get; set; }
    }
}