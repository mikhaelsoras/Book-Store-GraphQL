using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Database.Models;
using MangaStore.GraphQl.GraphTypes.Books;

namespace MangaStore.GraphQl.GraphTypes.Genres
{
    public class GenreGraphType : ObjectGraphType<Genre>
    {
        public GenreGraphType(IUnitOfWork unitOfWork)
        {
            Name = "Genre";
            Field(x => x.Id);
            Field(x => x.Description);

            Field<ListGraphType<BookGraphType>>("books",
                resolve: context => unitOfWork.Books.GetAllForGenre(context.Source.Id));
        }
    }
}