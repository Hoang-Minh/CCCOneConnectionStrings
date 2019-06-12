using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseConnectionString.Data;
using DatabaseConnectionString.Models;

namespace DatabaseConnectionString.Services
{
    public class ConnectionStringRepository : IConnectionString
    {
        private readonly ConnectionStringsDbContext connectionStringDbContext;

        public ConnectionStringRepository(ConnectionStringsDbContext aConnectionStringDbContext)
        {
            connectionStringDbContext = aConnectionStringDbContext;
        }

        public ConnectionString GetConnectionString(int id)
        {
            var connectionString = connectionStringDbContext.ConnectionStrings.Find(id);
            return connectionString;
        }

        public ConnectionString GetConnectionString(string environmentName)
        {
            var connectionString =
                connectionStringDbContext.ConnectionStrings.SingleOrDefault(x => x.EnvironmentName == environmentName);
            return connectionString;
        }

        public IEnumerable<ConnectionString> GetConnectionStrings()
        {
            return connectionStringDbContext.ConnectionStrings;
        }

        public void AddConnectionString(ConnectionString connectionString)
        {
            connectionStringDbContext.ConnectionStrings.Add(connectionString);
            connectionStringDbContext.SaveChanges(true);
        }

        public void UpdateConnectionString(ConnectionString connectionString)
        {
            connectionStringDbContext.ConnectionStrings.Update(connectionString);
            connectionStringDbContext.SaveChanges(true);
        }

        public void DeleteConnectionString(ConnectionString connectionString)
        {
            connectionStringDbContext.ConnectionStrings.Remove(connectionString);
            connectionStringDbContext.SaveChanges(true);
        }
    }
}
