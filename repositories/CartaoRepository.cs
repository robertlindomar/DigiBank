using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DigiBank.repositories
{
    public class CartaoRepository
    {
        public int Criar(CartaoNfc cartao)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO cartao (uid, apelido, pin_hash, conta_id, ativo, data_vinculacao) 
                              VALUES (@uid, @apelido, @pinHash, @contaId, @ativo, @dataVinculacao)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", cartao.Uid);
                    cmd.Parameters.AddWithValue("@apelido", cartao.Apelido);
                    cmd.Parameters.AddWithValue("@pinHash", cartao.PinHash);
                    cmd.Parameters.AddWithValue("@contaId", cartao.ContaId);
                    cmd.Parameters.AddWithValue("@ativo", cartao.Ativo);
                    cmd.Parameters.AddWithValue("@dataVinculacao", cartao.DataVinculacao);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<CartaoNfc> BuscarTodos()
        {
            var cartoes = new List<CartaoNfc>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cartao ORDER BY data_vinculacao DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cartoes.Add(LerCartaoDoReader(reader));
                    }
                }
                db.CloseConnection();
            }
            return cartoes;
        }

        public CartaoNfc BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cartao WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerCartaoDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public CartaoNfc BuscarPorUid(string uid)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cartao WHERE uid = @uid AND ativo = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerCartaoDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<CartaoNfc> BuscarPorContaId(int contaId)
        {
            var cartoes = new List<CartaoNfc>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM cartao WHERE conta_id = @contaId AND ativo = 1 ORDER BY data_vinculacao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@contaId", contaId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cartoes.Add(LerCartaoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return cartoes;
        }

        public List<CartaoNfc> BuscarPorClienteId(int clienteId)
        {
            var cartoes = new List<CartaoNfc>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"SELECT c.* FROM cartao c 
                              INNER JOIN conta co ON c.conta_id = co.id 
                              WHERE co.cliente_id = @clienteId AND c.ativo = 1
                              ORDER BY c.data_vinculacao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cartoes.Add(LerCartaoDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return cartoes;
        }

        public void Atualizar(CartaoNfc cartao)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE cartao SET uid = @uid, apelido = @apelido, pin_hash = @pinHash, 
                              conta_id = @contaId, ativo = @ativo, data_vinculacao = @dataVinculacao 
                              WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", cartao.Uid);
                    cmd.Parameters.AddWithValue("@apelido", cartao.Apelido);
                    cmd.Parameters.AddWithValue("@pinHash", cartao.PinHash);
                    cmd.Parameters.AddWithValue("@contaId", cartao.ContaId);
                    cmd.Parameters.AddWithValue("@ativo", cartao.Ativo);
                    cmd.Parameters.AddWithValue("@dataVinculacao", cartao.DataVinculacao);
                    cmd.Parameters.AddWithValue("@id", cartao.Id);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void AtualizarPin(int id, string novoPinHash)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE cartao SET pin_hash = @pinHash WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pinHash", novoPinHash);
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
                string sql = "DELETE FROM cartao WHERE id = @id";

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
                string sql = "UPDATE cartao SET ativo = 0 WHERE id = @id";

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
                string sql = "SELECT COUNT(*) FROM cartao WHERE uid = @uid";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }

        public bool ValidarPin(int cartaoId, string pinHash)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT COUNT(*) FROM cartao WHERE id = @id AND pin_hash = @pinHash AND ativo = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", cartaoId);
                    cmd.Parameters.AddWithValue("@pinHash", pinHash);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }

        private CartaoNfc LerCartaoDoReader(MySqlDataReader reader)
        {
            return new CartaoNfc
            {
                Id = Convert.ToInt32(reader["id"]),
                Uid = reader["uid"].ToString(),
                Apelido = reader["apelido"] == DBNull.Value ? null : reader["apelido"].ToString(),
                PinHash = reader["pin_hash"] == DBNull.Value ? null : reader["pin_hash"].ToString(),
                ContaId = Convert.ToInt32(reader["conta_id"]),
                Ativo = Convert.ToBoolean(reader["ativo"]),
                DataVinculacao = Convert.ToDateTime(reader["data_vinculacao"])
            };
        }
    }
}
