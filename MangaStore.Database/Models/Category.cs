using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangaStore.Database.Models
{
    public class Category
    {
        public Category(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public Category()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
