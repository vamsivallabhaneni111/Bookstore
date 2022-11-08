using Bookstore.Repository.Mongo.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bookstore.Repository.Mongo.Core
{
    public class MongoRepositoryBase<TDomain> : IMongoRepository<TDomain>
        where TDomain : class
    {
        private readonly BookStoreDbSettings _dbSettings;
        protected readonly IMongoCollection<TDomain> _collection;

        public MongoRepositoryBase(BookStoreDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.DatabaseName);
            _collection = mongoDatabase.GetCollection<TDomain>(typeof(TDomain).Name);
        }

        public void Add(TDomain record)
        {
            _collection.InsertOne(record);
        }

        public void Add(IEnumerable<TDomain> records)
        {
            _collection.InsertMany(records);
        }

        public Task AddAsync(TDomain record)
        {
           return _collection.InsertOneAsync(record);
        }

        public Task AddAsync(IEnumerable<TDomain> records)
        {
            return _collection.InsertManyAsync(records);
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDomain record)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TDomain record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TDomain Find(Guid id)
        {
            return _collection.Find(FilterById(id)).SingleOrDefault();
        }

        public IEnumerable<TDomain> Find(Expression<Func<TDomain, bool>> predicate)
        {
            var filter = Builders<TDomain>.Filter.Where(predicate);
            return _collection.Find(filter).ToList();
        }

        public Task<TDomain> FindAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TDomain Update(TDomain record)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TDomain> records)
        {
            throw new NotImplementedException();
        }

        public Task<TDomain> UpdateAsync(TDomain record)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<TDomain> records)
        {
            throw new NotImplementedException();
        }

        private static FilterDefinition<TDomain> FilterById(Guid id) =>
            Builders<TDomain>.Filter.Eq("Id", id);
    }
}
