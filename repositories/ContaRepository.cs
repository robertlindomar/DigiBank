using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DigiBank.repositories
{
    public class ContaRepository
    {
        public int Criar(Conta conta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO conta (numero_conta, tipo, saldo, ativa, cliente_id, data_abertura) 
                              VALUES (@numeroConta, @tipo, @saldo, @ativa, @clienteId, @dataAbertura)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroConta", conta.NumeroConta);
                    cmd.Parameters.AddWithValue("@tipo", conta.Tipo);
                    cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
                    cmd.Parameters.AddWithValue("@ativa", conta.Ativa);
                    cmd.Parameters.AddWithValue("@clienteId", conta.ClienteId);
                    cmd.Parameters.AddWithValue("@dataAbertura", conta.DataAbertura);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<Conta> BuscarTodos()
        {
            var contas = new List<Conta>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta ORDER BY data_abertura DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contas.Add(LerContaDoReader(reader));
                    }
                }
                db.CloseConnection();
            }
            return contas;
        }

        public Conta BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerContaDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<Conta> BuscarPorClienteId(int clienteId)
        {
            var contas = new List<Conta>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta WHERE cliente_id = @clienteId AND ativa = 1 ORDER BY tipo, data_abertura";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contas.Add(LerContaDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return contas;
        }

        public Conta BuscarPorNumeroConta(string numeroConta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta WHERE numero_conta = @numeroConta AND ativa = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroConta", numeroConta);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerContaDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<Conta> BuscarPorTipo(string tipo)
        {
            var contas = new List<Conta>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta WHERE tipo = @tipo AND ativa = 1 ORDER BY data_abertura";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contas.Add(LerContaDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return contas;
        }

        public void Atualizar(Conta conta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE conta SET numero_conta = @numeroConta, tipo = @tipo, 
                              saldo = @saldo, ativa = @ativa, cliente_id = @clienteId 
                              WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroConta", conta.NumeroConta);
                    cmd.Parameters.AddWithValue("@tipo", conta.Tipo);
                    cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
                    cmd.Parameters.AddWithValue("@ativa", conta.Ativa);
                    cmd.Parameters.AddWithValue("@clienteId", conta.ClienteId);
                    cmd.Parameters.AddWithValue("@id", conta.Id);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void AtualizarSaldo(int contaId, decimal novoSaldo)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE conta SET saldo = @saldo WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@saldo", novoSaldo);
                    cmd.Parameters.AddWithValue("@id", contaId);

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
                string sql = "DELETE FROM conta WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void Desativar(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE conta SET ativa = FALSE WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public bool ExisteNumeroConta(string numeroConta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT COUNT(*) FROM conta WHERE numero_conta = @numeroConta";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroConta", numeroConta);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }

        private Conta LerContaDoReader(MySqlDataReader reader)
        {
            return new Conta
            {
                Id = Convert.ToInt32(reader["id"]),
                NumeroConta = reader["numero_conta"].ToString(),
                Tipo = reader["tipo"].ToString(),
                Saldo = Convert.ToDecimal(reader["saldo"]),
                Ativa = Convert.ToBoolean(reader["ativa"]),
                ClienteId = Convert.ToInt32(reader["cliente_id"]),
                DataAbertura = Convert.ToDateTime(reader["data_abertura"])
            };
        }
    }
}
