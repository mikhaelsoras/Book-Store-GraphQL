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
                dbContext.AddRange(SeedBooks());
                dbContext.SaveChanges();
            }
        }

        private static IEnumerable<Book> SeedBooks()
        {
            var shounen = new Category("Shounen");
            var mistery = new Category("Mistery");
            var scienceFiction = new Category("Science Fiction");
            var drama = new Category("Drama");

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Pandora Hearts",
                    CoverValue = 14.99m,
                    IsUsed = false,
                    Categories = new List<Category> {shounen, mistery}
                },
                new Book
                {
                    Title = "Steins;Gate",
                    CoverValue = 17.49m,
                    IsUsed = false,
                    Categories = new List<Category> {scienceFiction, drama}
                },
                new Book
                {
                    Title = "Death Note",
                    CoverValue = 24.00m,
                    IsUsed = false,
                    Categories = new List<Category> {shounen, drama, mistery}
                }
            };

            return books;
        }
    }
}
