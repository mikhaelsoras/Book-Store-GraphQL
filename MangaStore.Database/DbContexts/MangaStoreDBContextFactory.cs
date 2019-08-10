using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MangaStore.Database.DbContexts
{
    public class MangaStoreDbContextFactory : IDesignTimeDbContextFactory<MangaStoreDbContext>
    {
        public MangaStoreDbContext CreateDbContext(string[] args)
        {
            return new MangaStoreDbContext();
        }
    }
}
