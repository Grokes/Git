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
            if (File.Exists("GoodInvest.db"))
            {
                File.Delete("GoodInvest.db");
            }
            using (var connection = new SqliteConnection("Data Source=GoodInvest.db"))
            {
                connection.Open();

                SendSQLCommandNonQuery(connection, @"CREATE TABLE Investors (
                                                [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                [Name] TEXT(50) NOT NULL,
                                                [Investment] INT NOT NULL,
                                                [age] int NOT NULL);
                                                CREATE TABLE Companies (
                                                [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                [Name] TEXT(50) NOT NULL,
                                                [Investment] INT NOT NULL);
                                                CREATE TABLE GrowthOfShares (
                                                [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                [CompanyId] INT NOT NULL,
                                                [Percent] REAL NOT NULL);");
                SendSQLCommandNonQuery(connection, @"INSERT INTO Companies(Name, Investment)
                                                    VALUES ('Google', 1000), ('Yandex', 500), ('Mail.ru', 100);
                                                    INSERT INTO Investors(Name, Investment, age)
                                                    VALUES ('Dmitriy', 1000, 30), ('Alexey', 500, 40), ('Victor', 100, 22);
                                                    INSERT INTO GrowthOfShares(CompanyId, Percent)
                                                    VALUES (1, 10), (2, 20), (3, 30);");
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