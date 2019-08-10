using GraphQL.Types;
using MangaStore.Database.Models;

namespace MangaStore.GraphQl.Types.Genres
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