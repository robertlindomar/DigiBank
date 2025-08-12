using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DigiBank.repositories
{
    public class PagamentoPosRepository
    {
        public int Criar(PagamentoPos pagamento)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO pagamento_pos (terminal_id, cartao_id, valor, data_hora, status, descricao) 
                              VALUES (@terminalId, @cartaoId, @valor, @dataHora, @status, @descricao)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@terminalId", pagamento.TerminalId);
                    cmd.Parameters.AddWithValue("@cartaoId", pagamento.CartaoId);
                    cmd.Parameters.AddWithValue("@valor", pagamento.Valor);
                    cmd.Parameters.AddWithValue("@dataHora", pagamento.DataHora);
                    cmd.Parameters.AddWithValue("@status", pagamento.Status);
                    cmd.Parameters.AddWithValue("@descricao", pagamento.Descricao);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<PagamentoPos> BuscarTodos()
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pagamentos.Add(LerPagamentoDoReader(reader));
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public PagamentoPos BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerPagamentoDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<PagamentoPos> BuscarPorTerminalId(int terminalId)
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE terminal_id = @terminalId ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@terminalId", terminalId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagamentos.Add(LerPagamentoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public List<PagamentoPos> BuscarPorCartaoId(int cartaoId)
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE cartao_id = @cartaoId ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@cartaoId", cartaoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagamentos.Add(LerPagamentoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public List<PagamentoPos> BuscarPorStatus(string status)
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE status = @status ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@status", status);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagamentos.Add(LerPagamentoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public List<PagamentoPos> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE data_hora BETWEEN @dataInicio AND @dataFim ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagamentos.Add(LerPagamentoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public List<PagamentoPos> BuscarPorValor(decimal valorMinimo, decimal valorMaximo)
        {
            var pagamentos = new List<PagamentoPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM pagamento_pos WHERE valor BETWEEN @valorMinimo AND @valorMaximo ORDER BY data_hora DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@valorMinimo", valorMinimo);
                    cmd.Parameters.AddWithValue("@valorMaximo", valorMaximo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagamentos.Add(LerPagamentoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return pagamentos;
        }

        public void Atualizar(PagamentoPos pagamento)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE pagamento_pos SET terminal_id = @terminalId, cartao_id = @cartaoId, 
                              valor = @valor, data_hora = @dataHora, status = @status, descricao = @descricao 
                              WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@terminalId", pagamento.TerminalId);
                    cmd.Parameters.AddWithValue("@cartaoId", pagamento.CartaoId);
                    cmd.Parameters.AddWithValue("@valor", pagamento.Valor);
                    cmd.Parameters.AddWithValue("@dataHora", pagamento.DataHora);
                    cmd.Parameters.AddWithValue("@status", pagamento.Status);
                    cmd.Parameters.AddWithValue("@descricao", pagamento.Descricao);
                    cmd.Parameters.AddWithValue("@id", pagamento.Id);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE pagamento_pos SET status = @status WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@status", novoStatus);
                    cmd.Parameters.AddWithValue("@id", id);

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
                string sql = "DELETE FROM pagamento_pos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public decimal ObterTotalVendidoPorTerminal(int terminalId, DateTime dataInicio, DateTime dataFim)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"SELECT COALESCE(SUM(valor), 0) as total_vendido 
                              FROM pagamento_pos 
                              WHERE terminal_id = @terminalId AND status = 'aprovado' 
                              AND data_hora BETWEEN @dataInicio AND @dataFim";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@terminalId", terminalId);
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);

                    var resultado = cmd.ExecuteScalar();
                    db.CloseConnection();
                    return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                }
            }
        }

        private PagamentoPos LerPagamentoDoReader(MySqlDataReader reader)
        {
            return new PagamentoPos
            {
                Id = Convert.ToInt32(reader["id"]),
                TerminalId = reader["terminal_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["terminal_id"]),
                CartaoId = reader["cartao_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["cartao_id"]),
                Valor = Convert.ToDecimal(reader["valor"]),
                DataHora = Convert.ToDateTime(reader["data_hora"]),
                Status = reader["status"].ToString(),
                Descricao = reader["descricao"] == DBNull.Value ? null : reader["descricao"].ToString()
            };
        }
    }
}
