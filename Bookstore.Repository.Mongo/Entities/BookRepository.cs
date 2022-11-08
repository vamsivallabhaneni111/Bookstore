using Bookstore.Domain;
using Bookstore.Repository.Entities;
using Bookstore.Repository.Mongo.Config;
using Bookstore.Repository.Mongo.Core;
using Microsoft.Extensions.Options;

namespace Bookstore.Repository.Mongo.Entities
{
    public class BookRepository : MongoRepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IOptions<BookStoreDbSettings> dbSettings) 
            : base(dbSettings.Value)
        {
        }
    }
}
