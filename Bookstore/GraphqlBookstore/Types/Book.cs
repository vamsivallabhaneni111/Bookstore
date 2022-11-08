using Bookstore.Services.Models;
using GraphQL.Types;

namespace Bookstore.GraphqlBookstore.Types
{
    public class Book : ObjectGraphType<BookDto>
    {
        public Book()
        {
            Field(x => x.Id, nullable: true, type: typeof(GuidGraphType)).Description("Id");
            Field(x => x.Name).Description("Title of Book");
            Field(x => x.Price, type: typeof(DecimalGraphType)).Description("Cost/ Price");
            Field(x => x.Genere).Description("Genere of the Book");
        }
    }
}
