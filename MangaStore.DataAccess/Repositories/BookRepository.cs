using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Database.DbContexts;
using MangaStore.Database.Models;

namespace MangaStore.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MangaStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
