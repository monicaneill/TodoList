namespace DataAccessLibrary.DbAccess;

public interface ISqlDataAccess
{
    string ConnectionStringName { get; set; }

    Task<IEnumerable<T>> LoadData<T, TU>(string sql, TU parameters);
    Task SaveData<T>(string storedProcedure, T parameters);
}