using System;
using System.Data;
using System.Data.Odbc;


namespace fiangonana_cs.database;

public class SqlServerConnectivity
{
    private static readonly string _server = "localhost\\SQLEXPRESS";
    private static readonly string _database = "fiangonana";

    public static IDbConnection NewConnection()
    {
        try
        {
            string connectionString = $"DRIVER=ODBC Driver 17 for SQL Server;SERVER={_server};DATABASE={_database};Trusted_Connection=yes";
            var connection = new OdbcConnection(connectionString);
            return connection;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error connecting to SQL Server: {ex.Message}");
        }
    }
}
