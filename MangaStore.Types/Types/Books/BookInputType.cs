using GraphQL.Types;
using MangaStore.Database.Models;

namespace MangaStore.GraphQl.Types.Books
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Field<StringGraphType>(nameof(Book.Title), "Book title.");
            Field<DecimalGraphType>(nameof(Book.CoverValue), "Value in the cover of the book.");
            Field<BooleanGraphType>(nameof(Book.IsUsed), "Specifies if the book is new or used.");
        }
    }
}