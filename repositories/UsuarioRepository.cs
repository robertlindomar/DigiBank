using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DigiBank.repositories
{
    public class UsuarioRepository
    {
        public int Criar(Usuario usuario)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "INSERT INTO usuario (cliente_id, login, senha, ativo, data_criacao, tipo) VALUES (@cliente_id, @login, @senha, @ativo, @data_criacao, @tipo)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    cmd.Parameters.AddWithValue("@cliente_id", usuario.ClienteId);
                    cmd.Parameters.AddWithValue("@login", usuario.Login);
                    cmd.Parameters.AddWithValue("@senha", senhaHash);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Ativo);
                    cmd.Parameters.AddWithValue("@data_criacao", usuario.DataCriacao);
                    cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);

                    cmd.ExecuteNonQuery();
                    db.CloseConnection();
                    return (int)cmd.LastInsertedId;
                }
            }
        }

        public Usuario Login(string login, string senha)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario WHERE login = @login";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string senhaHash = reader.GetString("senha");
                            if (BCrypt.Net.BCrypt.Verify(senha, senhaHash))
                            {
                                return new Usuario
                                {
                                    Id = reader.GetInt32("id"),
                                    ClienteId = reader.GetInt32("cliente_id"),
                                    Login = reader.GetString("login"),
                                    Senha = senhaHash,
                                    Ativo = reader.GetBoolean("ativo"),
                                    DataCriacao = reader.GetDateTime("data_criacao"),
                                    Tipo = reader.GetString("tipo")
                                };
                            }
                        }
                    }
                }
                db.CloseConnection();
                return null;
            }
        }

        public Usuario LoginPorUID(string uid)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"
                    SELECT u.*
                    FROM usuario u
                    INNER JOIN cliente c ON u.cliente_id = c.id
                    INNER JOIN conta co ON co.cliente_id = c.id
                    INNER JOIN cartao ca ON ca.conta_id = co.id
                    WHERE ca.uid = @uid
                    AND u.ativo = TRUE
                    AND ca.ativo = TRUE
                    AND co.ativa = TRUE
                    LIMIT 1;
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt32("id"),
                                ClienteId = reader.GetInt32("cliente_id"),
                                Login = reader.GetString("login"),
                                Senha = reader.GetString("senha"),
                                Ativo = reader.GetBoolean("ativo"),
                                DataCriacao = reader.GetDateTime("data_criacao"),
                                Tipo = reader.GetString("tipo")
                            };
                        }
                    }
                }
                db.CloseConnection();
                return null;
            }
        }
    }
}
