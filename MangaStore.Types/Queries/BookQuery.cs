using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.GraphTypes.Books;
using MangaStore.GraphQl.Queries.Contract;

namespace MangaStore.GraphQl.Queries
{
    public class BookQuery : IEntityQuery
    {
        public void CreateQuery(ObjectGraphType objectGraph, IUnitOfWork unitOfWork)
        {
            objectGraph.Field<ListGraphType<BookGraphType>>(
                "books",
                resolve: context => unitOfWork.Books.GetAll()
            );

            objectGraph.Field<BookGraphType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => unitOfWork.Books.Get(context.GetArgument<int>("id"))
            );
        }
    }
}