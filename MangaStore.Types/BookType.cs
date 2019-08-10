using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;

namespace MangaStore.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IUnitOfWork unitOfWork)
        {
            Field(book => book.Id);
            Field(book => book.CoverValue);
            Field(book => book.Title);
            Field(book => book.IsUsed);

            Field<ListGraphType<GenreType>>("genres",
                resolve: context => unitOfWork.Genres.GetAllForBook(context.Source.Id));
        }
    }
}