using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.configs
{
    public class Database : IDisposable
    {
        private const string connectionString = "Server=localhost;Database=digibank;Uid=root;Pwd=;";
        private MySqlConnection conn;

        public Database()
        {
            conn = new MySqlConnection(connectionString);
        }

        // Método para abrir conexão
        public MySqlConnection OpenConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;
            }
        }

        // Método para fechar conexão
        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        // Dispose para liberar recursos
        public void Dispose()
        {
            if (conn != null)
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
    }
}
