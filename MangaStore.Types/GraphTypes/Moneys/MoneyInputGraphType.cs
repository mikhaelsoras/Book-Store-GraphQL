using GraphQL.Types;
using MangaStore.Shared.Models;

namespace MangaStore.GraphQl.GraphTypes.Moneys
{
    public class MoneyInputGraphType : InputObjectGraphType
    {
        public MoneyInputGraphType()
        {
            Field<DecimalGraphType>(nameof(Money.Value), "Amount of money.");
            Field<StringGraphType>(nameof(Money.Currency), "Describe the money currency type.");
        }
    }
}