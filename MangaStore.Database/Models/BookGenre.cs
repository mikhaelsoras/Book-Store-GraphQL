using System;

namespace MangaStore.Database.Models
{
    public class BookGenre
    {
        public BookGenre() { }
        public BookGenre(Book book, Genre genre)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        }

        public int IdBook { get; set; }
        public int IdGenre { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}