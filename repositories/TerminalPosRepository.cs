using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DigiBank.repositories
{
    public class TerminalPosRepository
    {
        public int Criar(TerminalPos terminal)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO terminal_pos (nome, nome_loja, localizacao, uid, conta_id, ativo) 
                              VALUES (@nome, @nomeLoja, @localizacao, @uid, @contaId, @ativo)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", terminal.Nome);
                    cmd.Parameters.AddWithValue("@nomeLoja", terminal.NomeLoja);
                    cmd.Parameters.AddWithValue("@localizacao", terminal.Localizacao);
                    cmd.Parameters.AddWithValue("@uid", terminal.Uid);
                    cmd.Parameters.AddWithValue("@contaId", terminal.ContaId);
                    cmd.Parameters.AddWithValue("@ativo", terminal.Ativo);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<TerminalPos> BuscarTodos()
        {
            var terminais = new List<TerminalPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM terminal_pos ORDER BY nome_loja";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        terminais.Add(LerTerminalDoReader(reader));
                    }
                }
                db.CloseConnection();
            }
            return terminais;
        }

        public TerminalPos BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM terminal_pos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerTerminalDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public TerminalPos BuscarPorUid(string uid)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM terminal_pos WHERE uid = @uid";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerTerminalDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<TerminalPos> BuscarPorContaId(int contaId)
        {
            var terminais = new List<TerminalPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM terminal_pos WHERE conta_id = @contaId ORDER BY nome_loja";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@contaId", contaId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terminais.Add(LerTerminalDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return terminais;
        }

        public List<TerminalPos> BuscarPorLocalizacao(string localizacao)
        {
            var terminais = new List<TerminalPos>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM terminal_pos WHERE localizacao LIKE @localizacao ORDER BY nome_loja";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@localizacao", $"%{localizacao}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terminais.Add(LerTerminalDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return terminais;
        }

        public void Atualizar(TerminalPos terminal)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE terminal_pos SET nome = @nome, nome_loja = @nomeLoja, localizacao = @localizacao, 
                              uid = @uid, conta_id = @contaId, ativo = @ativo WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", terminal.Nome);
                    cmd.Parameters.AddWithValue("@nomeLoja", terminal.NomeLoja);
                    cmd.Parameters.AddWithValue("@localizacao", terminal.Localizacao);
                    cmd.Parameters.AddWithValue("@uid", terminal.Uid);
                    cmd.Parameters.AddWithValue("@contaId", terminal.ContaId);
                    cmd.Parameters.AddWithValue("@ativo", terminal.Ativo);
                    cmd.Parameters.AddWithValue("@id", terminal.Id);

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
                string sql = "DELETE FROM terminal_pos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public bool ExisteUid(string uid)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT COUNT(*) FROM terminal_pos WHERE uid = @uid";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }

        private TerminalPos LerTerminalDoReader(MySqlDataReader reader)
        {
            return new TerminalPos
            {
                Id = Convert.ToInt32(reader["id"]),
                Nome = reader["nome"].ToString(),
                NomeLoja = reader["nome_loja"].ToString(),
                Localizacao = reader["localizacao"].ToString(),
                Uid = reader["uid"].ToString(),
                ContaId = Convert.ToInt32(reader["conta_id"]),
                Ativo = Convert.ToBoolean(reader["ativo"])
            };
        }
    }
}
