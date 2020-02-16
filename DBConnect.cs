using System;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace angulardemo
{
    public class DBConnect
    {
        public DBConnect()
        {
            System.Diagnostics.Debug.WriteLine("db connect constructor");
        }

        private string databaseName = "wes";

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnect _instance = null;
        public static DBConnect Instance()
        {
            if (_instance == null)
                _instance = new DBConnect();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root;", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
