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
        public int Criar(Cliente cliente)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "INSERT INTO cliente (nome, cpf) VALUES (@nome, @cpf)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<Cliente> BuscarTodos()
        {
            var clientes = new List<Cliente>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cliente";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            DataCriacao = reader.GetDateTime("data_criacao")
                        });
                    }
                }
                db.CloseConnection();
            }
            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cliente WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
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
                }
                db.CloseConnection();
            }
            return null;
        }

        public void Atualizar(Cliente cliente)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE cliente SET nome = @nome, cpf = @cpf WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@id", cliente.Id);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void Deletar(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "DELETE FROM cliente WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
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
                db.CloseConnection();
            }
            return null;
        }
    }
}
