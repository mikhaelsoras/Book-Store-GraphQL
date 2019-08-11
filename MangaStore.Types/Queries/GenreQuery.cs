using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.GraphTypes.Genres;
using MangaStore.GraphQl.Queries.Contract;

namespace MangaStore.GraphQl.Queries
{
    public class GenreQuery : IEntityQuery
    {
        public void CreateQuery(ObjectGraphType objectGraph, IUnitOfWork unitOfWork)
        {
            objectGraph.Field<ListGraphType<GenreGraphType>>(
                "genres",
                resolve: context => unitOfWork.Genres.GetAll()
            );

            objectGraph.Field<GenreGraphType>(
                "genre",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => unitOfWork.Genres.Get(context.GetArgument<int>("id"))
            );
        }
    }
}