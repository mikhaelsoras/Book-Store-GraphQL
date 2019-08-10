using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangaStore.Database.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal CoverValue { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
