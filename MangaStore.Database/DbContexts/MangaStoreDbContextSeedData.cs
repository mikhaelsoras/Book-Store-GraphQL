using System;
using System.Collections.Generic;
using System.Text;
using MangaStore.Database.Models;
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
                CoverValue = 14.99m,
                IsUsed = false
            };

            var steinsGateBook = new Book
            {
                Title = "Steins;Gate",
                CoverValue = 17.49m,
                IsUsed = false
            };

            var deathNoteBook = new Book
            {
                Title = "Death Note",
                CoverValue = 24.00m,
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
