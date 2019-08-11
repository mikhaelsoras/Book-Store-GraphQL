using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.Queries.Contract;
using MangaStore.GraphQl.Types.Genres;

namespace MangaStore.GraphQl.Queries
{
    public class GenreQuery : IEntityQuery
    {
        public void CreateQuery(ObjectGraphType objectGraph, IUnitOfWork unitOfWork)
        {
            objectGraph.Field<ListGraphType<GenreType>>(
                "genres",
                resolve: context => unitOfWork.Genres.GetAll()
            );

            objectGraph.Field<GenreType>(
                "genre",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => unitOfWork.Genres.Get(context.GetArgument<int>("id"))
            );
        }
    }
}