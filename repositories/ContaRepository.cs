using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
namespace DigiBank.repositories
{
    public class ContaRepository
    {
        public int Criar(Conta novaConta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO conta 
                               (numero, tipo, saldo, ativa, cliente_id, data_abertura) 
                               VALUES (@numero, @tipo, @saldo, @ativa, @cliente_id, @data_abertura)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numero", novaConta.NumeroConta);
                    cmd.Parameters.AddWithValue("@tipo", novaConta.Tipo);
                    cmd.Parameters.AddWithValue("@saldo", novaConta.Saldo);
                    cmd.Parameters.AddWithValue("@ativa", novaConta.Ativa);
                    cmd.Parameters.AddWithValue("@cliente_id", novaConta.ClienteId);
                    cmd.Parameters.AddWithValue("@data_abertura", novaConta.DataAbertura);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<Conta> BuscarTodas()
        {
            var contas = new List<Conta>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contas.Add(MapearConta(reader));
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
                            return MapearConta(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public Conta BuscarPorNumero(string numeroConta)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM conta WHERE numero = @numero";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numero", numeroConta);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearConta(reader);
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
                string sql = "SELECT * FROM conta WHERE cliente_id = @cliente_id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@cliente_id", clienteId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contas.Add(MapearConta(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return contas;
        }

        public Conta Atualizar(Conta contaAtualizada)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE conta SET 
                               numero = @numero, tipo = @tipo, saldo = @saldo, ativa = @ativa, 
                               cliente_id = @cliente_id, data_abertura = @data_abertura 
                               WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", contaAtualizada.Id);
                    cmd.Parameters.AddWithValue("@numero", contaAtualizada.NumeroConta);
                    cmd.Parameters.AddWithValue("@tipo", contaAtualizada.Tipo);
                    cmd.Parameters.AddWithValue("@saldo", contaAtualizada.Saldo);
                    cmd.Parameters.AddWithValue("@ativa", contaAtualizada.Ativa);
                    cmd.Parameters.AddWithValue("@cliente_id", contaAtualizada.ClienteId);
                    cmd.Parameters.AddWithValue("@data_abertura", contaAtualizada.DataAbertura);

                    int result = cmd.ExecuteNonQuery();
                    db.CloseConnection();

                    if (result > 0)
                    {
                        return BuscarPorId(contaAtualizada.Id);
                    }
                }
            }
            return null;
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

        // Método privado para evitar repetição do mapeamento
        private Conta MapearConta(MySqlDataReader reader)
        {
            return new Conta
            {
                Id = reader.GetInt32("id"),
                NumeroConta = reader.GetString("numero_conta"),
                Tipo = reader.GetString("tipo"),
                Saldo = reader.GetDecimal("saldo"),
                Ativa = reader.GetBoolean("ativa"),
                ClienteId = reader.GetInt32("cliente_id"),
                DataAbertura = reader.GetDateTime("data_abertura")
            };
        }
    }
}
