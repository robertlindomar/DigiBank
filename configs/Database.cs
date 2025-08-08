using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.configs
{
    public class Database
    {
        private const string connectionString = "Server=localhost;Database=digibank;Uid=root;Pwd=;";

        public Database() { }


        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;
            }
        }
    }
}
