using GraphQL.Types;
using MangaStore.Database.Models;
using MangaStore.GraphQl.GraphTypes.Moneys;

namespace MangaStore.GraphQl.GraphTypes.Books
{
    public class BookInputGraphType : InputObjectGraphType
    {
        public BookInputGraphType()
        {
            Field<StringGraphType>(nameof(Book.Title), "Book title.");
            Field<BooleanGraphType>(nameof(Book.IsUsed), "Specifies if the book is new or used.");
            Field<MoneyInputGraphType>(nameof(Book.CoverPrice), "Price in the cover of the book.");
        }
    }
}