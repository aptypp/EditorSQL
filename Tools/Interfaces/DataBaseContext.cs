using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EditorSQL.Tools.Interfaces
{
    public abstract class DataBaseContext : DbContext
    {
        private readonly string _connectionString;

        protected DataBaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new SqlConnection(_connectionString));
        }
    }
}