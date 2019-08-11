using System.Collections.Generic;
using MangaStore.Shared.Models;

namespace MangaStore.Database.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Money CoverPrice { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
