using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var rows = await conn.QueryAsync<T>(storedProcedure,
                                                                parameters,
                                                                commandType: CommandType.StoredProcedure);
                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string storedprocedure, T parameter, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return await conn.ExecuteAsync(
                    storedprocedure,
                    parameter,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
