using System;

namespace VideoMenuConsoleApp
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        public Genre Genre { get; set; }
    }
}