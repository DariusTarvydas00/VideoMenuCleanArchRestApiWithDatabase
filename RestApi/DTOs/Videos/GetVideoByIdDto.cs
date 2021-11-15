﻿using System;

namespace RestApi.DTOs.Videos
{
    public class GetVideoByIdDto
    {
        public string Title { get; set; }
        public string StoryLine { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}