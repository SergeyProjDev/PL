using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;


using System.IO;

namespace ConsoleApp1
{ 
    partial class Program : DataBase
    {
        string databaseAdress = "MyDB.db";
        string databaseTableName = "MyTable";
        public List<DatabaseField> database = new List<DatabaseField>();

        private void StartConsole()
        {
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseAdress));
            ConnectToDatabase(databaseAdress);
            database = new List<DatabaseField>(GetTableContent(connection, databaseTableName, database));

            foreach (DatabaseField field in database)
            {
                Console.WriteLine(field.Id.ToString().PadRight(5) + field.Name + field.Age.ToString().PadLeft(5));
            }
        }
    }

    class DataBase
    {
        public void ConnectToDatabase(string getedDatabaseAdress)
        {
            string result = string.Empty;
            try
            {
                if (File.Exists(getedDatabaseAdress)) result = "База данных найдена!";
                else
                {
                    result = "База Данных не найдена!";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                Console.WriteLine(result);
            }
        }
        public List<DatabaseField> GetTableContent(SQLiteConnection connection, string tableName, List<DatabaseField> database)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {tableName};", connection);
            SQLiteDataReader sqlDR = command.ExecuteReader();

            Program program = new Program();

            while (sqlDR.Read())
            {
                DatabaseField databaseField = new DatabaseField();

                databaseField.Id = int.Parse(sqlDR.GetValue(0).ToString());
                databaseField.Age = int.Parse(sqlDR.GetValue(1).ToString());
                databaseField.Name = sqlDR.GetValue(2).ToString();

                database.Add(databaseField);
            }
            sqlDR.Close();
            connection.Close();

            return database;
        }
    }

    class DatabaseField
    {
        public int Id;
        public int Age;
        public string Name;
    }
}