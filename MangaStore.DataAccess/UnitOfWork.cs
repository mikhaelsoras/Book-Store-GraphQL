using System.Runtime.InteropServices;
using MangaStore.DataAccess.Repositories;
using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Database.DbContexts;

namespace MangaStore.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private MangaStoreDbContext Context { get; set; }

        public UnitOfWork(MangaStoreDbContext context)
        {
            Context = context;
            Books = new BookRepository(context);
            Categories = new CategoryRepository(context);
        }


        public void Commit()
        {
            Context.SaveChanges();
        }

        public IBookRepository Books { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
