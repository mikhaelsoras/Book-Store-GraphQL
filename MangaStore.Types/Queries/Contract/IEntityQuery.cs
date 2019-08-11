using GraphQL.Types;
using MangaStore.DataAccess;

namespace MangaStore.GraphQl.Queries.Contract
{
    public interface IEntityQuery
    {
        void CreateQuery(ObjectGraphType objectGraph, IUnitOfWork unitOfWork);
    }
}