using Bookstore.Repository.Core;

namespace Bookstore.Repository.Mongo.Core
{
    public interface IMongoRepository<TDomain>
        : IRepository<TDomain>, IRepositoryAsync<TDomain>
        where TDomain : class
    {
    }
}
