using GraphQL.Types;
using MangaStore.DataAccess;

namespace MangaStore.GraphQl.Mutations.Contract
{
    public interface IEntityMutation
    {
        void CreateMutation(ObjectGraphType objectGraph, IUnitOfWork unitOfWork);
    }
}