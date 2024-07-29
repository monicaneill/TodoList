using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary.DbAccess;

public class SqlDataAccess(IConfiguration config) : ISqlDataAccess
{
    public string ConnectionStringName { get; set; } = "Default";

    public async Task<IEnumerable<T>> LoadData<T, TU>(string storedProcedure, TU parameters)
    {
        using IDbConnection connection = new SqlConnection(config.GetConnectionString(ConnectionStringName));

        return await connection.QueryAsync<T>(storedProcedure, parameters, 
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = new SqlConnection(config.GetConnectionString(ConnectionStringName));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}