using System;
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
            Field<BookType>("addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    book = unitOfWork.Books.Add(book);
                    unitOfWork.Commit();
                    return book;
                });

            Field<BookType>("updateBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var bookValues = context.GetArgument<Book>("book");

                    var book = unitOfWork.Books.Get(id) ?? throw new ArgumentException($"{nameof(Book.Id)} not informed.");
                    book.CoverValue = bookValues.CoverValue;
                    book.IsUsed = bookValues.IsUsed;
                    book.Title = bookValues.Title;
                    unitOfWork.Commit();

                    return book;
                });
        }
    }
}
