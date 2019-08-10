using System.Collections;
using System.Collections.Generic;
using MangaStore.Database.Models;

namespace MangaStore.DataAccess.Repositories.Contracts
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IEnumerable<Genre> GetAllForBook(int idBook);
    }
}