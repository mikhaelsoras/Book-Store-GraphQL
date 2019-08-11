using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.Types.Genres;
using MangaStore.GraphQl.Types.Moneys;

namespace MangaStore.GraphQl.Types.Books
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IUnitOfWork unitOfWork)
        {
            Name = "Book";
            Field(book => book.Id);
            Field(book => book.Title);
            Field(book => book.IsUsed);
            Field(book => book.CoverPrice, type: typeof(MoneyType));

            Field<ListGraphType<GenreType>>("genres",
                resolve: context => unitOfWork.Genres.GetAllForBook(context.Source.Id));
        }
    }
}