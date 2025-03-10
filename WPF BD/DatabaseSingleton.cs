using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WPF_BD
{
    // Singleton для доступа к базе данных
    public sealed class DatabaseSingleton
    {
        private static DatabaseSingleton instance = null;
        private static readonly object padlock = new object();
        private readonly string connectionString;

        private DatabaseSingleton()
        {
            // Замените на вашу строку подключения
            connectionString = "Data Source=WIN-1GF78P49AAA\\SQLEXPRESS;Initial Catalog=ShoppingCenterDB;Integrated Security=True;";
        }

        public static DatabaseSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseSingleton();
                    }
                    return instance;
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
                return null;
            }
            return dataTable;
        }
    }
}