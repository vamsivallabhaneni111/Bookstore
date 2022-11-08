using Bookstore.Repository.Entities;
using Bookstore.Repository.Mongo.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Repository.Mongo.Config
{
    public class RepositoryConfig
    {
        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BookStoreDbSettings>(configuration.GetSection(AppConstants.BOOK_STORE_DATABASE));

            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
