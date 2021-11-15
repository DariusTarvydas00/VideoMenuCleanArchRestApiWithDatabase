using System;
using System.Collections.Generic;
using System.Linq;
using SQL.Entities;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Repositories
{
    public class VideoRepository: IVideoRepository
    {
        private readonly VideoMenuDbContext _ctx;
        public VideoRepository(VideoMenuDbContext ctx)
        {
            _ctx = ctx;
        }


        public Video Create(Video video)
        {
            var entity = _ctx.Videos.Add(new VideoEntity()
            {
                Title = video.Title,
                StoryLine = video.StoryLine,
                ReleaseDate = video.ReleaseDate
            });
            _ctx.SaveChanges();
            return new Video()
            {
                Title = video.Title,
                StoryLine = video.StoryLine,
                ReleaseDate = video.ReleaseDate
            };
        }

        public Video ReadById(int id)
        {
            return _ctx.Videos.Select(entity => new Video()
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine
            }).FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Video> ReadAll(Filter filter = null)
        {
            return _ctx.Videos.Select(entity => new Video()
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine
            }).ToList();
        }

        public Video Update(Video videoUpdate)
        {
            var entity = _ctx.Videos.Update(new VideoEntity()
            {
                Id = videoUpdate.Id,
                Title = videoUpdate.Title,
                ReleaseDate = videoUpdate.ReleaseDate,
                StoryLine = videoUpdate.StoryLine
            }).Entity;
            _ctx.SaveChanges();
            return new Video()
            {
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine
            };
        }

        public Video Delete(int id)
        {
            var entity = _ctx.Videos.Remove(new VideoEntity() {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Video() {Id = entity.Id};
        }

        public int Count()
        {
            return 1;
        }
    }
}