using Bookstore.GraphqlBookstore.Types;
using Bookstore.Services;
using Bookstore.Services.Core;
using GraphQL.Types;

namespace Bookstore.GraphqlBookstore.Queries
{
    public class BookstoreQuery : ObjectGraphType
    {
        public BookstoreQuery(IBooksService booksService)
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<Book>>>>(
                "books",
                arguments: new QueryArguments(),
                resolve: context => booksService.GetBooks());
        }
    }
}
