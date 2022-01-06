using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using POC.Adapters.MySqlDataAccess.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POC.Adapters.MySqlDataAccess
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MySqlContext>
    {
        public MySqlContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<MySqlContext>();

            var connectionString = configuration.GetConnectionString("MySqlConnectionString");

            dbContextBuilder.UseMySQL(connectionString);

            return new MySqlContext(dbContextBuilder.Options);
        }
    }
}
