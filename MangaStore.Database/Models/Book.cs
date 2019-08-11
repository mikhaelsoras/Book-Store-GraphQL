using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangaStore.Database.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public decimal? CoverValue { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
