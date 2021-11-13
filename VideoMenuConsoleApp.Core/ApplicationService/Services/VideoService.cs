using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService.Services
{
    public class VideoService: IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ICustomerRepository _customerRepository;

        public VideoService(IVideoRepository videoRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _videoRepository = videoRepository;
        }

        public Video NewVideo(string title, DateTime releaseDate, Genre genre, string storyLine)
        {
            var video = new Video()
            {
                Title = title,
                ReleaseDate = releaseDate,
                Genre = genre,
                StoryLine = storyLine
            };
            return video;
        }

        public Video CreateNewVideo(Video video)
        {
            if (video.Customer == null || video.Customer.Id <= 0)
            {
                throw new InvalidDataException("Error");
            }

            // if (_customerRepository.ReadById(video.Customer.Id) == null)
            // {
            //     throw new InvalidDataException("Another Error");
            // }

            return _videoRepository.Create(video);
        }

        public Video UpdateVideo(Video videoUpdate)
        {
            var video = FindVideoById(videoUpdate.Id);
            video.Title = videoUpdate.Title;
            video.Genre = videoUpdate.Genre;
            video.ReleaseDate = videoUpdate.ReleaseDate;
            video.StoryLine = videoUpdate.StoryLine;
            return video;
        }

        public Video DeleteVideo(int id)
        {
            return _videoRepository.Delete(id);
        }

        public Video FindVideoById(int id)
        {
            return _videoRepository.ReadById(id);
        }

        public List<Video> GetAllVideos()
        {
            return _videoRepository.ReadAll().ToList();
        }

        public List<Video> GetAllVideosByTitle(string name)
        {
            var list = _videoRepository.ReadAll();
            var queryContinued = list.Where(customer => customer.Title.Equals(name));
            queryContinued.OrderBy(video => video.Title);
            return queryContinued.ToList();
        }

        public List<Video> GetFilteredOrders(Filter filter)
        {
            return _videoRepository.ReadAll(filter).ToList();
        }
    }
}