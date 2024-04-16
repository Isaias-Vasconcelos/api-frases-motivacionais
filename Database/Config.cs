
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace FrasesMotivacionais.Database;
public class Config
{
    private static IDbConnection Connection { get; } = new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_CONNECTION"));
    public static IDbConnection Database()
    {
        CreateTables();
        return Connection;
    }
    static void CreateTables()
    {
        Connection.Execute(@"CREATE TABLE IF NOT EXISTS mensagens (
            id INT NOT NULL AUTO_INCREMENT,
            texto TEXT,
            PRIMARY KEY(id)
        )");
    }
}