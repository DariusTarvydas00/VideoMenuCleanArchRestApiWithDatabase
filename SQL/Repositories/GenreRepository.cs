using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private readonly VideoMenuDbContext _ctx;

        public GenreRepository(VideoMenuDbContext ctx)
        {
            _ctx = ctx;
        }
        public Genre Create(Genre genre)
        {
            throw new System.NotImplementedException();
        }

        public Genre ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Genre> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Genre Update(Genre genre)
        {
            throw new System.NotImplementedException();
        }

        public Genre Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}