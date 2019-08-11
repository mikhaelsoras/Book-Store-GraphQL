using System.Collections.Generic;
using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.GraphQl.Mutations;
using MangaStore.GraphQl.Mutations.Contract;

namespace MangaStore.GraphQl
{
    public class MangaStoreMutation : ObjectGraphType
    {
        private readonly List<IEntityMutation> _mutations = new List<IEntityMutation>();
        public MangaStoreMutation(IUnitOfWork unitOfWork)
        {
            _mutations.AddRange(new IEntityMutation[]
            {
                new BookMutation()
            });

            Build(unitOfWork);
        }

        private void Build(IUnitOfWork unitOfWork)
        {
            foreach (var query in _mutations)
                query.CreateMutation(this, unitOfWork);
        }
    }
}
