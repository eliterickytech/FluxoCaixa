using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Infrastructure.Repository
{
    public class BaseRepository
    {
        private IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetSection("ConnectionStrings:SQL").Value);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parametes = null)
        {
            using(var connection = CreateConnection())
            {
                connection.Open();
                return await connection.QueryAsync<T>(query, parametes);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parametes = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<T>(query, parametes);
            }
        }

        public async Task<int> ExecuteAsync<T>(string query, object parametes = null)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                return await connection.ExecuteAsync(query, parametes);

            }
        }

    }
}
