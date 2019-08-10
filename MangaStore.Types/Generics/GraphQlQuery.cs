using Newtonsoft.Json.Linq;

namespace MangaStore.GraphQl.Generics
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
