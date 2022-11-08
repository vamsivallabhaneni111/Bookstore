using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bookstore.Repository.Core
{
    public interface IRepository<TDomain> 
        where TDomain : class
    {
        TDomain Find(Guid id);
        IEnumerable<TDomain> Find(Expression<Func<TDomain, bool>> predicate);
        void Add(TDomain record);
        void Add(IEnumerable<TDomain> records);
        TDomain Update(TDomain record);
        void Update(IEnumerable<TDomain> records);
        void Delete(Guid id);
        void Delete(TDomain record);
        void Delete(Expression<Func<TDomain, bool>> predicate);
        void DeleteAll();
        long Count();
    }
}
