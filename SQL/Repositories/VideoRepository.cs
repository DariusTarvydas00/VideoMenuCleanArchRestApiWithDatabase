using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public Video ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Video> ReadAll(Filter filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Video Update(Video videoUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Video Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }
    }
}