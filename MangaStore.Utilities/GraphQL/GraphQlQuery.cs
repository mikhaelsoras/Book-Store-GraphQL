using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MangaStore.Utilities.GraphQL
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
