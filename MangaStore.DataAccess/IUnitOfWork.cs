using System;
using MangaStore.DataAccess.Repositories.Contracts;

namespace MangaStore.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
    }
}