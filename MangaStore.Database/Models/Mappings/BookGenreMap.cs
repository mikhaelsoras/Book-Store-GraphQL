using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangaStore.Database.Models.Mappings
{
    public class BookGenreMap : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(bookGenre => new { bookGenre.IdBook, bookGenre.IdGenre });

            builder.HasOne<Book>(sc => sc.Book)
                .WithMany(s => s.BookGenres)
                .HasForeignKey(sc => sc.IdBook);

            builder.HasOne<Genre>(sc => sc.Genre)
                .WithMany(s => s.BookGenres)
                .HasForeignKey(sc => sc.IdGenre);
        }
    }
}
