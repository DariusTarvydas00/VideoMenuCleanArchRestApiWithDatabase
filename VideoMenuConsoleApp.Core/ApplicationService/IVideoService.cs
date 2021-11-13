using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService
{
    public interface IVideoService
    {
        Video NewVideo(string title, DateTime releaseDate, Genre genre, string storyLine);
        Video CreateNewVideo(Video video);
        Video UpdateVideo(Video video);
        Video DeleteVideo(int id);
        Video FindVideoById(int id);
        List<Video> GetAllVideos();
        List<Video> GetAllVideosByTitle(string name);
        List<Video> GetFilteredOrders(Filter filter);
    }
}