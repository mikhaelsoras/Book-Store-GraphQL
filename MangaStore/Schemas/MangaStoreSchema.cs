using GraphQL;
using GraphQL.Types;
using MangaStore.Queries;

namespace MangaStore.Schemas
{
    public class MangaStoreSchema : Schema
    {
        public MangaStoreSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<MangaStoreQuery>();
        }
    }
}