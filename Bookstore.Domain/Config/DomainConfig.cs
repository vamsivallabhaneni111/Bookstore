
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Domain.Config
{
    public class DomainConfig
    {
        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Book>();
        }
    }
}
