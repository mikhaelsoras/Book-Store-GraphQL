using GraphQL.Types;
using MangaStore.DataAccess;

namespace MangaStore.Types.Book
{
    public class BookType : ObjectGraphType<Database.Models.Book>
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