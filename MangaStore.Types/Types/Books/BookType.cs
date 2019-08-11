using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.Types.Genres;

namespace MangaStore.GraphQl.Types.Books
{
    public class BookType : ObjectGraphType<Database.Models.Book>
    {
        public BookType(IUnitOfWork unitOfWork)
        {
            Field(book => book.Id);
            Field(book => book.CoverValue, true);
            Field(book => book.Title);
            Field(book => book.IsUsed);

            Field<ListGraphType<GenreType>>("genres",
                resolve: context => unitOfWork.Genres.GetAllForBook(context.Source.Id));
        }
    }
}