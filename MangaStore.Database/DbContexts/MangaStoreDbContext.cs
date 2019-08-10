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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MangaStoreDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>().HasKey(bc => new { bc.IdBook, bc.IdGenre});

            modelBuilder.Entity<BookGenre>()
                .HasOne<Book>(sc => sc.Book)
                .WithMany(s => s.BookGenres)
                .HasForeignKey(sc => sc.IdBook);


            modelBuilder.Entity<BookGenre>()
                .HasOne<Genre>(sc => sc.Genre)
                .WithMany(s => s.BookGenres)
                .HasForeignKey(sc => sc.IdGenre);
        }
    }
}
