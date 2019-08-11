using System.Collections;
using System.Collections.Generic;
using MangaStore.Database.Models;

namespace MangaStore.DataAccess.Repositories.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllForGenre(int idGenre);
    }
}