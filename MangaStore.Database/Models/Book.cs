using System.Collections.Generic;

namespace MangaStore.Database.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? CoverValue { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
