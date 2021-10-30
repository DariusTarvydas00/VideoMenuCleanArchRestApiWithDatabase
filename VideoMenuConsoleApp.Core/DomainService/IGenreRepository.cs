using System.Collections.Generic;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp.Core.DomainService
{
    public interface IGenreRepository
    {
        Genre Create(Genre genre);
        Genre ReadById(int id);
        IEnumerable<Genre> ReadAll();
        Genre Update(Genre genre);
        Genre Delete(int id);
    }
}