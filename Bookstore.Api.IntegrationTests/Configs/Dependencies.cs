using AutoMapper;
using Bookstore.Api.IntegrationTests.Steps.BooksControllerFeature;
using Bookstore.Controllers;
using Bookstore.Repository.Entities;
using Bookstore.Repository.Mongo.Config;
using Bookstore.Repository.Mongo.Entities;
using Bookstore.Services;
using Bookstore.Services.Core;
using Bookstore.Services.Mappers;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace Bookstore.Api.IntegrationTests.Configs
{
    internal class Dependencies
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            RegisterBooksConfigInContainer(services);

            return services;
        }

        public static void RegisterBooksConfigInContainer(ServiceCollection services)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile(new BookProfile()));

            services.AddSingleton(typeof(IMapper), new Mapper(config));
            
            var cc = ConfigurationProvider.Configuration.GetSection(BookStoreDbSettings.ConfigName);

            services.Configure<BookStoreDbSettings>(ConfigurationProvider.Configuration.GetSection(BookStoreDbSettings.ConfigName));
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddScoped<IBooksService, TestBooksService>();
            
            services.AddSingleton<BooksController>(provider =>
            {
                var bookService = provider.GetRequiredService<IBooksService>();
                return new BooksController(bookService);
            });
        }
    }
}
