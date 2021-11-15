using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.ApplicationService
{
    public interface IGenreService
    {
        Genre NewGenre(string title);
        Genre CreateNewGenre(Genre genre);
        Genre UpdateGenre(Genre genreUpdate);
        Genre DeleteGenre(int id);
        Genre FindGenreById(int id);
        List<Genre> GetAllGenre();
        List<Genre> GetAllGenreByTitle(string name);
    }
}