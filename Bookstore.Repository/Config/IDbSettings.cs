namespace Bookstore.Repository.Config
{
    public interface IDbSettings
    {
        static string ConfigName { get; }
        DatabaseType DatabaseType { get; }
        string ConnectionURI { get; set; }
        string DatabaseName { get; set; }
    }
}