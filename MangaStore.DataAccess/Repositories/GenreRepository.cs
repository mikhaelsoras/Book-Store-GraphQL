using System.Collections.Generic;
using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Database.DbContexts;
using MangaStore.Database.Models;
using System.Linq;

namespace MangaStore.DataAccess.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MangaStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Genre> GetAllForBook(int idBook)
        {
            return DbContext.Where(genre => genre.BookGenres.Any(bookGenre => bookGenre.IdBook == idBook));
        }
    }
}
