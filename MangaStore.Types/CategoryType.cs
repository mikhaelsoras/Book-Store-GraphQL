using GraphQL.Types;
using MangaStore.Database.Models;
using MangaStore.Utilities;

namespace MangaStore.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id);
            Field(x => x.Description);
        }
    }
}