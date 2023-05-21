using AutoMapper;
using Bookstore.Repository.Entities;
using Bookstore.Services;

namespace Bookstore.Api.IntegrationTests.Steps.BooksControllerFeature
{
    public class TestBooksService : BooksService
    {
        public TestBooksService(IMapper mapper, IBookRepository bookRepository)
            : base(mapper, bookRepository)
        {
        }
    }
}
