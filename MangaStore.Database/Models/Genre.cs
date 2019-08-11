using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangaStore.Database.Models
{
    public class Genre
    {
        public Genre() { }
        public Genre(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
