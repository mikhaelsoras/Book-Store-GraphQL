using System;
using System.ComponentModel.DataAnnotations;

namespace MangaStore.Database.Models
{
    public class BookGenre
    {
        public BookGenre()
        {
            
        }

        public BookGenre(Book book, Genre genre)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
        }

        [Key]
        public int IdBook { get; set; }
        [Key]
        public int IdGenre { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}