using System;
using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Utilities;

namespace MangaStore.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IBookRepository Books { get; }
        IGenreRepository Genres { get; }
    }
}