using GraphQL.Types;
using MangaStore.Database.Models;
using MangaStore.Utilities;

namespace MangaStore.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id);
            Field(x => x.CoverValue);
            Field(x => x.Title);
            Field(x => x.IsUsed);
        }
    }
}