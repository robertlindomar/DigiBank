using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.repositories
{
    public class ClienteRepository
    {

        private readonly Database conn = new Database();
        private readonly MySqlConnection conexao;
        public ClienteRepository()
        {
            conexao = conn.GetConnection();
        }



        public int Criar(Cliente cliente)
        {
            string sql = "INSERT INTO cliente (nome, cpf) VALUES (@nome, @cpf)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.ExecuteNonQuery();


            return (int)cmd.LastInsertedId;
        }

        public List<Cliente> BuscarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "SELECT * FROM cliente";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = reader.GetInt32("id"),
                        Nome = reader.GetString("nome"),
                        Cpf = reader.GetString("cpf"),
                        DataCriacao = reader.GetDateTime("data_criacao")
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            string sql = "SELECT * FROM cliente WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Cliente
                    {
                        Id = reader.GetInt32("id"),
                        Nome = reader.GetString("nome"),
                        Cpf = reader.GetString("cpf"),
                        DataCriacao = reader.GetDateTime("data_criacao")
                    };
                }
            }
            return null;
        }

        public void Atualizar(Cliente cliente)
        {
            string sql = "UPDATE cliente SET nome = @nome, cpf = @cpf WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.ExecuteNonQuery();
        }



        public void Deletar(int id)
        {
            string sql = "DELETE FROM cliente WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            string sql = "SELECT * FROM cliente WHERE cpf = @cpf";

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            DataCriacao = reader.GetDateTime("data_criacao")
                        };
                    }
                }
            }

            return null;
        }



    }
}
