using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DigiBank.repositories
{
    public class ClienteRepository
    {
        public int Criar(Cliente novoCliente)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "INSERT INTO cliente (nome, cpf, data_criacao) VALUES (@nome, @cpf, @data_criacao); SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", novoCliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", novoCliente.Cpf);
                    cmd.Parameters.AddWithValue("@data_criacao", novoCliente.DataCriacao);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
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
                string sql = "SELECT * FROM cliente ORDER BY nome";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString(),
                            Cpf = reader["cpf"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["data_criacao"])
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
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                DataCriacao = Convert.ToDateTime(reader["data_criacao"])
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
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                DataCriacao = Convert.ToDateTime(reader["data_criacao"])
                            };
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            var clientes = new List<Cliente>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cliente WHERE nome LIKE @nome ORDER BY nome";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", $"%{nome}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                DataCriacao = Convert.ToDateTime(reader["data_criacao"])
                            });
                        }
                    }
                }
                db.CloseConnection();
            }
            return clientes;
        }

        public bool ExistePorCpf(string cpf)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT COUNT(*) FROM cliente WHERE cpf = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }
    }
}
