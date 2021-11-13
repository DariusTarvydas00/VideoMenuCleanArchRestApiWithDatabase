using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _ctx.Attach(genre).State = EntityState.Added;
            _ctx.SaveChanges();
            return genre;
        }

        public Genre ReadById(int id)
        {
            return _ctx.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public IEnumerable<Genre> ReadAll()
        {
            //return _ctx.Genres;
            // var list = new List<Genre>();
            // var entityList = _ctx.Genres.ToList();
            // foreach (var entity in entityList)
            // {
            //     list.Add(new Genre()
            //     {
            //         Id = entity.Id
            //     });
            // }
            //
            // return list;
            return _ctx.Genres.Select(genre => new Genre()
            {
                Id = genre.Id,
                Type = genre.Type
            }).ToList();
        }

        public Genre Update(Genre genre)
        {
            _ctx.Attach(genre).State = EntityState.Modified; 
            _ctx.Entry(genre).Reference<Genre>(genre1 => genre1).IsModified = true;
            _ctx.SaveChanges();
            return genre;
        }

        public Genre Delete(int id)
        {
            var gen = _ctx.Remove<Genre>( new Genre {Id = id}).Entity;
            return gen;
        }
    }
}