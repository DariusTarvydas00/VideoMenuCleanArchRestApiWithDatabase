using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class VideoRepository: IVideoRepository
    {
        private int _videoId = 1;
        private readonly List<Video> _videos = new List<Video>();
        
        public Video Create(Video video)
        {
            video.Id = _videoId++;
            _videos.Add(video);
            return video;
        }

        public Video ReadById(int id)
        {
            foreach (var video in _videos)
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
            return _videos;
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
                _videos.Remove(videoFound);
                return videoFound;
            }

            return null;
        }
    }
}