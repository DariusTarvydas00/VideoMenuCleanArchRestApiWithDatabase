using System;

namespace RestApi.DTOs.Videos
{
    public class PostVideoDto
    {
        public string Title { get; set; }
        public string StoryLine { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int GenreEntityId { get; set; }
    }
}