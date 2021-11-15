using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Entities
{
    public class VideoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        public int? GenreId { get; set; } // for writting
        public GenreEntity Genre { get; set; } // for reading

    }
}