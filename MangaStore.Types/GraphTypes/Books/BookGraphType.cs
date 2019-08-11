using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.GraphTypes.Genres;
using MangaStore.GraphQl.GraphTypes.Moneys;

namespace MangaStore.GraphQl.GraphTypes.Books
{
    public class BookGraphType : ObjectGraphType<Book>
    {
        public BookGraphType(IUnitOfWork unitOfWork)
        {
            Name = "Book";
            Field(book => book.Id);
            Field(book => book.Title);
            Field(book => book.IsUsed);
            Field(book => book.CoverPrice, type: typeof(MoneyGraphType));

            Field<ListGraphType<GenreGraphType>>("genres",
                resolve: context => unitOfWork.Genres.GetAllForBook(context.Source.Id));
        }
    }
}