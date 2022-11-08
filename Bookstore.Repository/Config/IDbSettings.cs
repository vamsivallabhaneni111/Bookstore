namespace Bookstore.Repository.Config
{
    public interface IDbSettings
    {
        ConnectionName ConnectionName { get; }
        DatabaseType DatabaseType { get; }
        string ConnectionURI { get; set; }
        string DatabaseName { get; set; }
    }
}