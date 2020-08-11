using Npgsql;

namespace TestShop.Shared.PostgreSqlSettings
{
    public abstract class DbSettings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public int MaxPoolSize { get; set; }

        public string GetConnectionString()
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Host,
                Port = Port,
                Database = DbName,
                Username = User,
                Password = Password,
                MaxPoolSize = MaxPoolSize
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}