using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class VideoRepository: IVideoRepository
    {

        public VideoRepository()
        {
            if (FakeDB.Videos.Count >= 1) return;
            Video video1 = new Video()
            {
                Id = FakeDB.videoId++,
                Title = "Star Wars",
                ReleaseDate = new DateTime(1991, 08, 02),
                Genre = new Genre() {Id = 1, Type = "Fantasy"},
                StoryLine = "Bing Pow Bum Bum",
                Customer = new Customer(){Id = 1}
            };
            Video video2 = new Video()
            {
                Id = FakeDB.videoId++,
                Title = "Liar Liar",
                ReleaseDate = new DateTime(1988, 02, 24),
                Genre = new Genre() {Id = 1, Type = "Comedy"},
                StoryLine = "Ha Ha Ha Ha",
                Customer = new Customer(){Id = 2}
            };
            FakeDB.Videos.Add(video1);
            FakeDB.Videos.Add(video2);
        }

        public Video Create(Video video)
        {
            video.Id = FakeDB.videoId++;
            FakeDB.Videos.Add(video);
            return video;
        }

        public Video ReadById(int id)
        {
            foreach (var video in FakeDB.Videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }

            return null;
        }

        public IEnumerable<Video> ReadAll()
        {
            return FakeDB.Videos;
        }

        public Video Update(Video videoUpdate)
        {
            var videoFromDb = this.ReadById(videoUpdate.Id);
            if (videoFromDb != null)
            {
                videoFromDb.Title = videoUpdate.Title;
                videoFromDb.ReleaseDate = videoUpdate.ReleaseDate;
                videoFromDb.Genre = videoUpdate.Genre;
                videoFromDb.StoryLine = videoUpdate.StoryLine;
                return videoFromDb;
            }

            return null;
        }

        public Video Delete(int id)
        {
            var videoFound = this.ReadById(id);
            if (videoFound != null)
            {
                FakeDB.Videos.Remove(videoFound);
                return videoFound;
            }

            return null;
        }
    }
}