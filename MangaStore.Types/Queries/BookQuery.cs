using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.Queries.Contract;
using MangaStore.GraphQl.Types.Books;

namespace MangaStore.GraphQl.Queries
{
    public class BookQuery : IEntityQuery
    {
        public void CreateQuery(ObjectGraphType objectGraph, IUnitOfWork unitOfWork)
        {
            objectGraph.Field<ListGraphType<BookType>>(
                "books",
                resolve: context => unitOfWork.Books.GetAll()
            );

            objectGraph.Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => unitOfWork.Books.Get(context.GetArgument<int>("id"))
            );
        }
    }
}