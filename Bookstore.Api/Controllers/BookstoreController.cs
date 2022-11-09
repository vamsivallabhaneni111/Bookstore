using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bookstore.GraphqlBookstore.Models;
using GraphQL.NewtonsoftJson;

namespace Bookstore.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class BookstoreController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public BookstoreController(
            ISchema schema,
            IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookstoreQueryDto query)
        {
            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Variables = query.Variables?.ToInputs();
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}
