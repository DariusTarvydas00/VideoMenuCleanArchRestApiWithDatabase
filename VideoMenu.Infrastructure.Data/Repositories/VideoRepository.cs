﻿using System.Collections.Generic;
using System.Linq;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data.Repositories
{
    public class VideoRepository: IVideoRepository
    {
        private readonly VideoMenuAppContext _ctx;

        public VideoRepository(VideoMenuAppContext ctx)
        {
            _ctx = ctx;
        }

        public Video Create(Video video)
        {
            var vid = _ctx.Videos.Add(video).Entity;
            _ctx.SaveChanges();
            return vid;
        }

        public Video ReadById(int id)
        {
            return _ctx.Videos.FirstOrDefault(video => video.Id == id);
        }

        public IEnumerable<Video> ReadAll()
        {
            return _ctx.Videos;
        }

        public Video Update(Video videoUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Video Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}