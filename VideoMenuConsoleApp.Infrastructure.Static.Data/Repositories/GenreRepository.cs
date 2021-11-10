using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private int _genreId = 1;
        private readonly List<Genre> _genres = new List<Genre>();
        public Genre Create(Genre genre)
        {
            genre.Id = _genreId++;
            _genres.Add(genre);
            return genre;
        }

        public Genre ReadById(int id)
        {
            foreach (var genre in _genres)
            {
                if (genre.Id == id)
                {
                    return genre;
                }
            }

            return null;
        }

        public IEnumerable<Genre> ReadAll()
        {
            return _genres;
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