using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConnectionString.Models;

namespace DatabaseConnectionString.Services
{
    public interface IConnectionString
    {
        //CRUD operation
        IEnumerable<ConnectionString> GetConnectionStrings();
        ConnectionString GetConnectionString(int id);
        ConnectionString GetConnectionString(string name);
        void AddConnectionString(ConnectionString connectionString);
        void UpdateConnectionString(ConnectionString connectionString);
        void DeleteConnectionString(ConnectionString connectionString);
    }
}
