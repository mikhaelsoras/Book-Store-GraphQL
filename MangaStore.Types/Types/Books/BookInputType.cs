using GraphQL.Types;
using MangaStore.Database.Models;

namespace MangaStore.GraphQl.Types.Books
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Field<StringGraphType>(nameof(Book.Title));
            Field<DecimalGraphType>(nameof(Book.CoverValue));
            Field<BooleanGraphType>(nameof(Book.IsUsed));
        }
    }
}