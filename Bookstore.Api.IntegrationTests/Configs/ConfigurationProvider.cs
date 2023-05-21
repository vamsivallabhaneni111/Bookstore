using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bookstore.Api.IntegrationTests.Configs
{
    public static class ConfigurationProvider
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationProvider()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Tests.json")
                .Build();
        }
    }
}
