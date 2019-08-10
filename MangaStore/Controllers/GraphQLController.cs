using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Introspection;
using GraphQL.Types;
using MangaStore.GraphQl;
using MangaStore.GraphQl.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQlController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQlController(ISchema schema,
            IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery graphQlQuery)
        {
            var executionOptions = ValidateGraphQuery(graphQlQuery);

            var result = await _documentExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
                return BadRequest(result);

            return Ok(result);
        }

        private ExecutionOptions ValidateGraphQuery(GraphQlQuery graphQlQuery)
        {
            if (graphQlQuery is null)
                throw new ArgumentNullException($"{nameof(graphQlQuery)} was not informed.");

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = graphQlQuery.Query,
                Inputs = graphQlQuery.Variables?.ToInputs()
            };

            return executionOptions;
        }
    }
}