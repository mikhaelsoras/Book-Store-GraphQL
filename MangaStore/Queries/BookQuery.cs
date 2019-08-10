using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Types;
using MangaStore.Utilities;

namespace MangaStore.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IUnitOfWork unitOfWork)
        {
            Field<ListGraphType<BookType>>(
                "books", 
                resolve: context => unitOfWork.Books.GetAll()
            );
        }
    }
}