using System.Collections.Generic;
using MangaStore.Database.Models;
using MangaStore.Shared.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace MangaStore.Database.DbContexts
{
    public static class MangaStoreDbContextSeedData
    {
        public static void EnsureSeedData(this MangaStoreDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                dbContext.BookGenres.AddRange(SeedData());
                dbContext.SaveChanges();
            }
        }

        private static IEnumerable<BookGenre> SeedData()
        {
            var shounen = new Genre("Shounen");
            var mistery = new Genre("Mistery");
            var scienceFiction = new Genre("Science Fiction");
            var drama = new Genre("Drama");


            var pandoraBook = new Book
            {
                Title = "Pandora Hearts",
                CoverPrice = new Money(14.99m, "BRL"),
                IsUsed = false
            };

            var steinsGateBook = new Book
            {
                Title = "Steins;Gate",
                CoverPrice = new Money(17.49m, "BRL"),
                IsUsed = false
            };

            var deathNoteBook = new Book
            {
                Title = "Death Note",
                CoverPrice = new Money(24.00m, "BRL"),
                IsUsed = false
            };

            var bookGenres = new List<BookGenre>
            {
                new BookGenre(pandoraBook, mistery),

                new BookGenre(steinsGateBook, scienceFiction),

                new BookGenre(deathNoteBook, shounen),
                new BookGenre(deathNoteBook, drama),
                new BookGenre(deathNoteBook, mistery)
            };

            return bookGenres;
        }
    }
}
