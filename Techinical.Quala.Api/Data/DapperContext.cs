using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Technical_Test_Quala.Data
{
    public class DrapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DrapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CadenaConexion");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
