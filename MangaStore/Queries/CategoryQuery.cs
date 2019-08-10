using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Types;
using MangaStore.Utilities;

namespace MangaStore.Queries
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(IUnitOfWork unitOfWork)
        {
            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => unitOfWork.Categories.GetAll()
            );
        }
    }
}