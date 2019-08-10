using System.IO;
using MangaStore.Database.Models;
using MangaStore.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MangaStore.Database.DbContexts
{
    public class MangaStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MangaStoreDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
