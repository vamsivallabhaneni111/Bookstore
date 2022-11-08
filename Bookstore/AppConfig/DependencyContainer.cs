using AutoMapper;
using Bookstore.AppConfig.Db;
using Bookstore.Services.Mappers;
using Bookstore.Repository.Entities;
using Bookstore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bookstore.GraphqlBookstore.Queries;
using Bookstore.GraphqlBookstore.Schemas;
using Bookstore.GraphqlBookstore.Types;
using GraphQL.Types;
using Bookstore.GraphqlBookstore.Resolvers;
using GraphQL;

namespace Bookstore.AppConfig
{
    public class DependencyContainer
    {
        public static void InitializeGraphQlServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
