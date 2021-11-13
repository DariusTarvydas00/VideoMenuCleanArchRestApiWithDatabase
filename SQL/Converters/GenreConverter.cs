using SQL.Entities;
using VideoMenuConsoleApp.Core.Entity;

namespace SQL.Converters
{
    public class GenreConverter
    {
        public Genre Convert(GenreEntity entity)
        {
            return new Genre
            {
                Id = entity.Id,
                Type = entity.Type
            };
        }
        
        public GenreEntity Convert(Genre genre)
        {
            return new GenreEntity
            {
                Id = genre.Id,
                Type = genre.Type,
            };
        }
    }
}