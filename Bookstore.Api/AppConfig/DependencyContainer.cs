using AutoMapper;
using Bookstore.Services.Mappers;
using Bookstore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bookstore.GraphqlBookstore.Queries;
using Bookstore.GraphqlBookstore.Schemas;
using Bookstore.GraphqlBookstore.Types;
using GraphQL.Types;
using Bookstore.GraphqlBookstore.Resolvers;
using GraphQL;
using Bookstore.Services.Core;
using Bookstore.Repository.Entities;
using Bookstore.Repository.Mongo.Entities;
using Bookstore.Repository.Mongo.Config;
using Bookstore.Repository.Config;

namespace Bookstore.AppConfig
{
    public class DependencyContainer
    {
        public static void InitializeConfig(IServiceCollection services, IConfiguration configuration)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile(new BookProfile()));

            services.AddSingleton(typeof(IMapper), new Mapper(config));
            //services.Configure<FinInfraDbSettings>(configuration.GetSection(AppConstants.FIN_INFRA_DATABASE));
        }

        public static void InitializeGraphQlServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Book>();
            services.AddSingleton<BookstoreQuery>();
            services.AddSingleton<ISchema, BookstoreSchema>();

            services.AddSingleton<IBookResolver, BookResolver>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
        }

        public static void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBooksService, BooksService>();
        }

        public static void InitializeRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Book>();
            services.AddTransient<IBookRepository, BookRepository>(); 
            services.Configure<BookStoreDbSettings>(configuration.GetSection(RepoConstants.BOOK_STORE_DATABASE))
                .AddSingleton<IDbSettings>();
        }
    }
}
