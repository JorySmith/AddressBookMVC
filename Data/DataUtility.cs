using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Data
{
    // Make class static so you can use it without instantiating it
    public static class DataUtility
    {
        // Get connection string depending on if working locally or operating on heroku
        public static string GetConnectionString(IConfiguration configuration)
        {
            // The default connection string will come from appSettings like usual
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // It will be overwritten if app is running on Heroku
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            // If databaseUrl is null/empty = return local connecitonString,
            // otherwise return BuildConnectionString(databaseUrl)
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        // Build connection string
        public static string BuildConnectionString(string databaseUrl)
        {
            // Uniform resource identifier (Uri()) provides an object
            // representation of URI and easy access to its parts
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            // NpgsqlConnectionStringBuilder helps you create and manage the
            // contents of connection strings used by the NpgsqlConnection class
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };

            // Return data as a conntection string
            return builder.ToString();
        }
    }
}
