using Bookstore.Services;
using Bookstore.Services.Core;

namespace Bookstore.GraphqlBookstore.Resolvers
{
    public class BookResolver : IBookResolver
    {
        private readonly IBooksService _booksService;

        public BookResolver(IBooksService booksService)
        {
            _booksService = booksService;
        }
    }
}
