using System.Collections.Generic;
using System.Linq;
using SQL.Entities;
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
            var entity = _ctx.Genres.Add(new GenreEntity()
            {
                Id = genre.Id,
                Type = genre.Type
            }).Entity;
            _ctx.SaveChanges();
            return new Genre()
            {
                Id = entity.Id,
                Type = entity.Type
            };
        }

        public Genre ReadById(int id)
        {
            return _ctx.Genres.Select(entity => new Genre()
            {
                Id = entity.Id,
                Type = entity.Type
            }).FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> ReadAll()
        {
            return _ctx.Genres.Select(entity => new Genre()
            {
                Id = entity.Id,
                Type = entity.Type
            }).ToList();
        }

        public Genre Update(Genre genre)
        {
            var entity = _ctx.Genres.Update(new GenreEntity()
            {
                Id = genre.Id,
                Type = genre.Type
            }).Entity;
            _ctx.SaveChanges();
            return new Genre()
            {
                Id = entity.Id,
                Type = entity.Type
            };
        }

        public Genre Delete(int id)
        {
            var entity = _ctx.Genres.Remove(new GenreEntity() {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Genre() {Id = entity.Id};
        }
    }
}