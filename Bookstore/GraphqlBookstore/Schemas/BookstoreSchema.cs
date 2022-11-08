using Bookstore.GraphqlBookstore.Queries;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bookstore.GraphqlBookstore.Schemas
{
    public class BookstoreSchema : Schema, ISchema
    {
        public BookstoreSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BookstoreQuery>();
        }
    }
}
