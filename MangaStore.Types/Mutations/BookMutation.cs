using System;
using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.Mutations.Contract;
using MangaStore.GraphQl.Types.Books;

namespace MangaStore.GraphQl.Mutations
{
    public class BookMutation : IEntityMutation
    {
        public void CreateMutation(ObjectGraphType objectGraph, IUnitOfWork unitOfWork)
        {
            objectGraph.Field<BookType>("addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    book = unitOfWork.Books.Add(book);
                    unitOfWork.Commit();
                    return book;
                });

            objectGraph.Field<BookType>("updateBook",
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

            objectGraph.Field<StringGraphType>("removeBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    var book = unitOfWork.Books.Get(id) ?? throw new ArgumentException($"{nameof(Book.Id)} not informed.");
                    unitOfWork.Books.Remove(book);
                    unitOfWork.Commit();

                    return $"The book with Id ({id}) has been successfully removed.";
                });
        }
    }
}