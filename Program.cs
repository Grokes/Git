using Microsoft.Data.Sqlite;
using System.IO;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Git
{
    internal static class Program
    {
        static void Main()
        {
            using (var connection = new SqliteConnection("Data Source=GoodInvest.db"))
            {
                connection.Open();

                SendSQLCommandNonQuery(connection, @"CREATE TABLE Investors (
                                                    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                    [Name] TEXT(50) NOT NULL,
                                                    [Investment] INT NOT NULL,
                                                    [age] int NOT NULL);");
                SendSQLCommandNonQuery(connection, @"CREATE TABLE Companies (
                                                    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                    [Name] TEXT(50) NOT NULL,
                                                    [Investment] INT NOT NULL);");
                SendSQLCommandNonQuery(connection, @"CREATE TABLE GrowthOfShares (
                                                    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                    [CompanyId] INT NOT NULL,
                                                    [Percent] REAL NOT NULL);");
            }
        }

        private static void SendSQLCommandNonQuery(SqliteConnection connection, string textCommand)
        {
            using SqliteCommand command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = textCommand;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
        }
    }


}