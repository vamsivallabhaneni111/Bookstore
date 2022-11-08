using Newtonsoft.Json.Linq;

namespace Bookstore.GraphqlBookstore.Models
{
    public class BookstoreQueryDto
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
