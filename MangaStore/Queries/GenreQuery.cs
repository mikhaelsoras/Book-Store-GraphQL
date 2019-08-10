using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Types;
using MangaStore.Utilities;

namespace MangaStore.Queries
{
    public class GenreQuery : ObjectGraphType
    {
        public GenreQuery(IUnitOfWork unitOfWork)
        {
            Field<ListGraphType<GenreType>>(
                "categories",
                resolve: context => unitOfWork.Genres.GetAll()
            );
        }
    }
}