using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenu.Infrastructure.Data.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private readonly VideoMenuAppContext _ctx;

        public GenreRepository(VideoMenuAppContext ctx)
        {
            _ctx = ctx;
        }

        public Genre Create(Genre genre)
        {
            var gen = _ctx.Genres.Add(genre).Entity;
            _ctx.SaveChanges();
            return gen;
        }

        public Genre ReadById(int id)
        {
            return _ctx.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public IEnumerable<Genre> ReadAll()
        {
            return _ctx.Genres;
        }

        public Genre Update(Genre genre)
        {
            throw new System.NotImplementedException();
        }

        public Genre Delete(int id)
        {
            var gen = _ctx.Remove<Genre>( new Genre {Id = id}).Entity;
            return gen;
        }
    }
}