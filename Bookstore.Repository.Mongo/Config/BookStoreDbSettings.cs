using Bookstore.Repository.Config;

namespace Bookstore.Repository.Mongo.Config
{
    public class BookStoreDbSettings : IDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionURI { get; set; }

        public DatabaseType DatabaseType => DatabaseType.MONGO;
        public static string ConfigName  => "BookstoreDbConnection";
    }
}
