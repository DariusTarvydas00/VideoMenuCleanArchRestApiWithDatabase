using System;
using System.Collections.Generic;

namespace VideoMenuConsoleApp.Core.Entity
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        public Genre Genre { get; set; }
        public Customer Customer { get; set; }
    }
}