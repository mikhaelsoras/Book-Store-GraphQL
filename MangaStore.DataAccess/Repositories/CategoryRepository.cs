using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Database.DbContexts;
using MangaStore.Database.Models;

namespace MangaStore.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MangaStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
