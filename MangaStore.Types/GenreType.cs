using GraphQL.Types;
using MangaStore.Database.Models;
using MangaStore.Utilities;

namespace MangaStore.Types
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Field(x => x.Id);
            Field(x => x.Description);
        }
    }
}