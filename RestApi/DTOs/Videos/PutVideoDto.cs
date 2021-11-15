using System;

namespace RestApi.DTOs.Videos
{
    public class PutVideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StoryLine { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}