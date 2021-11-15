using System.Collections.Generic;
using System.Linq;
using VideoMenuConsoleApp.Core.DomainService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService.Services
{
    public class GenreService: IGenreService
    {
        readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        
        public Genre NewGenre(string title)
        {
            var genre = new Genre()
            {
                Type = title
            };
            return genre;
        }

        public Genre CreateNewGenre(Genre genre)
        {
            return _genreRepository.Create(genre);
        }

        public Genre UpdateGenre(Genre genreUpdate)
        {
            return _genreRepository.Update(genreUpdate);
        }

        public Genre DeleteGenre(int id)
        {
            return _genreRepository.Delete(id);
        }

        public Genre FindGenreById(int id)
        {
            return _genreRepository.ReadById(id);
        }

        public List<Genre> GetAllGenre()
        {
            return _genreRepository.ReadAll().ToList();
        }

        public List<Genre> GetAllGenreByTitle(string title)
        {
            var list = _genreRepository.ReadAll();
            var queryContinued = list.Where(genre => genre.Type.Equals(title));
            queryContinued.OrderBy(genre => genre.Type);
            return queryContinued.ToList();
        }
    }
}