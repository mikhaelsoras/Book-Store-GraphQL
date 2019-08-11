using GraphQL.Types;
using MangaStore.Shared.Models;

namespace MangaStore.GraphQl.Types.Moneys
{
    public class MoneyGraphType : ObjectGraphType<Money>
    {
        public MoneyGraphType()
        {
            Name = "Money";
            Description = "Represents Money";
            Field(money => money.Value, true, typeof(DecimalGraphType)).Description("Amount of money.");
            Field(money => money.Currency, true).Description("Describe the money currency type.");
        }
    }
}