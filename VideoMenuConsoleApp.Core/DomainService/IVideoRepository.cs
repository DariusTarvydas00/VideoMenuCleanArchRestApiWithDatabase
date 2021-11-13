using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.DomainService
{
    public interface IVideoRepository
    {
        Video Create(Video video);
        Video ReadById(int id);
        IEnumerable<Video> ReadAll(Filter filter = null);
        Video Update(Video videoUpdate);
        Video Delete(int id);
    }
}