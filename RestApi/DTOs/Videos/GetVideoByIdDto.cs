using System;
using VideoMenuConsoleApp.Core.Entity;

namespace RestApi.DTOs.Videos
{
    public class GetVideoByIdDto
    {
        public string Title { get; set; }
        public string StoryLine { get; set; }
        public DateTime ReleaseTime { get; set; }
        public Genre Genre { get; set; }
    }
}