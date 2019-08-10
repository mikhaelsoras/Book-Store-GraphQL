using GraphQL;
using GraphQL.Types;

namespace MangaStore.GraphQl
{
    public class MangaStoreSchema : Schema
    {
        public MangaStoreSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<MangaStoreQuery>();
            Mutation = dependencyResolver.Resolve<MangaStoreMutation>();
        }
    }
}