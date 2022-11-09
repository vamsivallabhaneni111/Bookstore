using Bookstore.Repository.Config;

namespace Bookstore.AppConfig.Db
{
    public class FinInfraDbSettings : IDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionURI { get; set; }

        public DatabaseType DatabaseType => DatabaseType.MS_SQL;
        public ConnectionName ConnectionName => ConnectionName.FinInfraDbConnection;
    }
}
