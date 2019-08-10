using GraphQL.Types;
using MangaStore.Database.Models;

namespace MangaStore.GraphQl.Types.Books
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            const Book reference = null;
            Field<StringGraphType>(nameof(reference.Title));
            Field<DecimalGraphType>(nameof(reference.CoverValue));
            Field<BooleanGraphType>(nameof(reference.IsUsed));
        }
    }
}