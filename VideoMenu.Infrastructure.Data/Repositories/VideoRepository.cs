using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _ctx.Attach(video).State = EntityState.Added;
            _ctx.SaveChanges();
            return video;
        }

        public Video ReadById(int id)
        {
            return _ctx.Videos.FirstOrDefault(video => video.Id == id);
        }

        public IEnumerable<Video> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Videos;
            }

            return _ctx.Videos.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).Where(video => video.ReleaseDate < DateTime.Now);
        }

        public Video Update(Video videoUpdate)
        {
            // if (videoUpdate.Customer != null && _ctx.ChangeTracker.Entries<Customer>()
            //     .FirstOrDefault(entry => entry.Entity.Id == videoUpdate.Customer.Id) == null)
            // {
            //     _ctx.Attach(videoUpdate.Customer);
            // }
            // else
            // {
            //     _ctx.Entry(videoUpdate).Reference(o => o.Customer).IsModified = true;
            // }
            //
            // var updated = _ctx.Update(videoUpdate).Entity;
            //     _ctx.SaveChanges();
            //     return updated;
            _ctx.Attach(videoUpdate).State = EntityState.Modified;
            _ctx.Entry(videoUpdate).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return videoUpdate;

        }

        public Video Delete(int id)
        {
            var vid = _ctx.Remove(new Video {Id = id}).Entity;
            return vid;
        }

        public int Count()
        {
            return _ctx.Videos.Count();
        }
    }
}