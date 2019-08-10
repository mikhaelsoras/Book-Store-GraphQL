using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.Types.Books;

namespace MangaStore.GraphQl
{
    public class MangaStoreMutation : ObjectGraphType
    {
        public MangaStoreMutation(IUnitOfWork unitOfWork)
        {
            Field<BookType>(
                "addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    book = unitOfWork.Books.Add(book);
                    unitOfWork.Commit();
                    return book;
                });
        }
    }
}
