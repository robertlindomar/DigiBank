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
        private readonly Database conn = new Database();
        private readonly MySqlConnection conexao;

        public ContaRepository()
        {
            conexao = conn.GetConnection();
        }


        public int Criar(Conta novaConta)
        {
            string sql = "INSERT INTO conta (numero, tipo, saldo, ativa, cliente_id, data_abertura) VALUES (@numero, @tipo, @saldo, @ativa, @cliente_id, @data_abertura)";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@numero", novaConta.NumeroConta);
                cmd.Parameters.AddWithValue("@tipo", novaConta.Tipo);
                cmd.Parameters.AddWithValue("@saldo", novaConta.Saldo);
                cmd.Parameters.AddWithValue("@ativa", novaConta.Ativa);
                cmd.Parameters.AddWithValue("@cliente_id", novaConta.ClienteId);
                cmd.Parameters.AddWithValue("@data_abertura", novaConta.DataAbertura);

                conexao.Open();
                int result = cmd.ExecuteNonQuery();
                conexao.Close();
                return result;
            }


        }

        public List<Conta> BuscarTodas()
        {
            List<Conta> contas = new List<Conta>();
            string sql = "SELECT * FROM conta";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                conexao.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Conta conta = new Conta
                        {
                            Id = reader.GetInt32("id"),
                            NumeroConta = reader.GetString("numero"),
                            Tipo = reader.GetString("tipo"),
                            Saldo = reader.GetDecimal("saldo"),
                            Ativa = reader.GetBoolean("ativa"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            DataAbertura = reader.GetDateTime("data_abertura")
                        };
                        contas.Add(conta);
                    }
                }
                conexao.Close();
            }
            return contas;
        }

        public Conta BuscarPorId(int id)
        {
            string sql = "SELECT * FROM conta WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Conta
                        {
                            Id = reader.GetInt32("id"),
                            NumeroConta = reader.GetString("numero"),
                            Tipo = reader.GetString("tipo"),
                            Saldo = reader.GetDecimal("saldo"),
                            Ativa = reader.GetBoolean("ativa"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            DataAbertura = reader.GetDateTime("data_abertura")
                        };
                    }
                }
                conexao.Close();
            }
            return null;
        }

        public Conta BuscarPorNumero(string numeroConta)
        {
            string sql = "SELECT * FROM conta WHERE numero = @numero";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@numero", numeroConta);
                conexao.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Conta
                        {
                            Id = reader.GetInt32("id"),
                            NumeroConta = reader.GetString("numero"),
                            Tipo = reader.GetString("tipo"),
                            Saldo = reader.GetDecimal("saldo"),
                            Ativa = reader.GetBoolean("ativa"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            DataAbertura = reader.GetDateTime("data_abertura")
                        };
                    }
                }
                conexao.Close();
            }
            return null;
        }

        public List<Conta> BuscarPorClienteId(int clienteId)
        {
            string sql = "SELECT * FROM conta WHERE cliente_id = @cliente_id";
            List<Conta> contas = new List<Conta>();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                conexao.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contas.Add(new Conta
                        {
                            Id = reader.GetInt32("id"),
                            NumeroConta = reader.GetString("numero"),
                            Tipo = reader.GetString("tipo"),
                            Saldo = reader.GetDecimal("saldo"),
                            Ativa = reader.GetBoolean("ativa"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            DataAbertura = reader.GetDateTime("data_abertura")
                        });
                    }
                }
                conexao.Close();
            }

            return contas;
        }

        public List<Conta> ListarTodas()
        {
            string sql = "SELECT * FROM conta";
            List<Conta> contas = new List<Conta>();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                conexao.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contas.Add(new Conta
                        {
                            Id = reader.GetInt32("id"),
                            NumeroConta = reader.GetString("numero"),
                            Tipo = reader.GetString("tipo"),
                            Saldo = reader.GetDecimal("saldo"),
                            Ativa = reader.GetBoolean("ativa"),
                            ClienteId = reader.GetInt32("cliente_id"),
                            DataAbertura = reader.GetDateTime("data_abertura")
                        });
                    }
                }
                conexao.Close();
            }

            return contas;
        }

        public Conta Atualizar(Conta contaAtualizada)
        {
            string sql = "UPDATE conta SET numero = @numero, tipo = @tipo, saldo = @saldo, ativa = @ativa, cliente_id = @cliente_id, data_abertura = @data_abertura WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@id", contaAtualizada.Id);
                cmd.Parameters.AddWithValue("@numero", contaAtualizada.NumeroConta);
                cmd.Parameters.AddWithValue("@tipo", contaAtualizada.Tipo);
                cmd.Parameters.AddWithValue("@saldo", contaAtualizada.Saldo);
                cmd.Parameters.AddWithValue("@ativa", contaAtualizada.Ativa);
                cmd.Parameters.AddWithValue("@cliente_id", contaAtualizada.ClienteId);
                cmd.Parameters.AddWithValue("@data_abertura", contaAtualizada.DataAbertura);

                conexao.Open();
                int result = cmd.ExecuteNonQuery();
                conexao.Close();

                if (result > 0)
                {
                    return BuscarPorId(contaAtualizada.Id);
                }
            }
            return null;
        }

        public void Deletar(int id)
        {
            string sql = "DELETE FROM conta WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }









    }
}
