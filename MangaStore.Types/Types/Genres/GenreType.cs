using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.Types.Books;

namespace MangaStore.GraphQl.Types.Genres
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType(IUnitOfWork unitOfWork)
        {
            Name = "Genre";
            Field(x => x.Id);
            Field(x => x.Description);

            Field<ListGraphType<BookType>>("books",
                resolve: context => unitOfWork.Books.GetAllForGenre(context.Source.Id));
        }
    }
}