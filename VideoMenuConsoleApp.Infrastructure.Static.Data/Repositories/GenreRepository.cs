using System.Collections.Generic;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Infrastructure.Static.Data.Repositories
{
    public class GenreRepository: IGenreRepository
    {

        public GenreRepository()
        {
            if (FakeDB.Genres.Count >= 1) return;
            Genre gen1 = new Genre()
            {
                Id = FakeDB.genreId++,
                Type = "Horror"
            };
            Genre gen2 = new Genre()
            {
                Id = FakeDB.genreId++,
                Type = "Documentary"
            };
            FakeDB.Genres.Add(gen1);
            FakeDB.Genres.Add(gen2);
        }

        public Genre Create(Genre genre)
        {
            genre.Id = FakeDB.genreId++;
            FakeDB.Genres.Add(genre);
            return genre;
        }

        public Genre ReadById(int id)
        {
            foreach (var genre in FakeDB.Genres)
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
            return FakeDB.Genres;
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
                FakeDB.Genres.Remove(genreFound);
                return genreFound;
            }

            return null;
        }
    }
}