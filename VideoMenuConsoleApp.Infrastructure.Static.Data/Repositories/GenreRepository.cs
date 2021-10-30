using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private int _genreId = 1;
        private List<Genre> _genres = new List<Genre>();
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
            var genreFound = this.ReadById(id);
            if (genreFound != null)
            {
                _genres.Remove(genreFound);
                return genreFound;
            }

            return null;
        }
    }
}