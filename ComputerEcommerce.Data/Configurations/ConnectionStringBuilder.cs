using Microsoft.Extensions.Configuration;
using System.Text;

namespace ComputerEcommerce.API.Configurations
{
    public static class ConnectionStringBuilder
    {
        public static string BuildConnectionString(IConfiguration configuration)
        {
            DatabaseConnectionSettings databaseConfig = new DatabaseConnectionSettings();
            configuration.Bind("SqlServerConnection", databaseConfig);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Server={databaseConfig.Server};");
            sb.Append($"Database={databaseConfig.Database};");
            sb.Append($"User Id={databaseConfig.UserId};");
            sb.Append($"Password={databaseConfig.Password};");
            sb.Append($"Trusted_Connection={databaseConfig.TrustedConnection};");
            sb.Append($"TrustServerCertificate={databaseConfig.TrustServerCertificate};");
            return sb.ToString();
        }
    }
}
