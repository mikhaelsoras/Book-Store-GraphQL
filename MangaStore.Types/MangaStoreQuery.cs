using System.Collections.Generic;
using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.Queries;
using MangaStore.GraphQl.Queries.Contract;

namespace MangaStore.GraphQl
{
    public class MangaStoreQuery : ObjectGraphType
    {
        private readonly List<IEntityQuery> _queries = new List<IEntityQuery>();
        public MangaStoreQuery(IUnitOfWork unitOfWork)
        {
            _queries.AddRange(new IEntityQuery[]
            {
                new BookQuery(),
                new GenreQuery()
            });

            Build(unitOfWork);
        }

        private void Build(IUnitOfWork unitOfWork)
        {
            foreach (var query in _queries)
                query.CreateQuery(this, unitOfWork);
        }
    }
}