using Bookstore.Domain;
using Bookstore.Repository.Core;

namespace Bookstore.Repository.Entities
{
    public interface IBookRepository : IRepository<Book>, IRepositoryAsync<Book>
    {
    }
}
