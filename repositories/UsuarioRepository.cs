using DigiBank.configs;
using DigiBank.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;



namespace DigiBank.repositories
{
    public class UsuarioRepository
    {
        public int Criar(Usuario usuario)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"INSERT INTO usuario (cliente_id, login, senha, ativo, tipo, data_criacao) 
                              VALUES (@clienteId, @login, @senha, @ativo, @tipo, @dataCriacao)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", usuario.ClienteId);
                    cmd.Parameters.AddWithValue("@login", usuario.Login);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Ativo);
                    cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);
                    cmd.Parameters.AddWithValue("@dataCriacao", usuario.DataCriacao);

                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    db.CloseConnection();
                    return id;
                }
            }
        }

        public List<Usuario> BuscarTodos()
        {
            var usuarios = new List<Usuario>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario ORDER BY data_criacao DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(LerUsuarioDoReader(reader));
                    }
                }
                db.CloseConnection();
            }
            return usuarios;
        }

        public Usuario BuscarPorId(int id)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerUsuarioDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public Usuario BuscarPorLogin(string login)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario WHERE login = @login AND ativo = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerUsuarioDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public Usuario BuscarPorClienteId(int clienteId)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario WHERE cliente_id = @clienteId AND ativo = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return LerUsuarioDoReader(reader);
                        }
                    }
                }
                db.CloseConnection();
            }
            return null;
        }

        public List<Usuario> BuscarPorTipo(string tipo)
        {
            var usuarios = new List<Usuario>();
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT * FROM usuario WHERE tipo = @tipo AND ativo = 1 ORDER BY data_criacao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(LerUsuarioDoReader(reader));
                        }
                    }
                }
                db.CloseConnection();
            }
            return usuarios;
        }

        public void Atualizar(Usuario usuario)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = @"UPDATE usuario SET cliente_id = @clienteId, login = @login, 
                              senha = @senha, ativo = @ativo, tipo = @tipo 
                              WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteId", usuario.ClienteId);
                    cmd.Parameters.AddWithValue("@login", usuario.Login);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Ativo);
                    cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);
                    cmd.Parameters.AddWithValue("@id", usuario.Id);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public void AtualizarSenha(int id, string novaSenha)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "UPDATE usuario SET senha = @senha WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@senha", novaSenha);
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
                string sql = "DELETE FROM usuario WHERE id = @id";

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
                string sql = "UPDATE usuario SET ativo = FALSE WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
        }

        public bool ExisteLogin(string login)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT COUNT(*) FROM usuario WHERE login = @login";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.CloseConnection();
                    return count > 0;
                }
            }
        }

        public bool ValidarCredenciais(string login, string senha)
        {
            using (var db = new Database())
            {
                var conexao = db.OpenConnection();
                string sql = "SELECT senha FROM usuario WHERE login = @login AND ativo = 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    var resultado = cmd.ExecuteScalar();
                    db.CloseConnection();

                    if (resultado == null || resultado == DBNull.Value)
                        return false;

                    string senhaHash = resultado.ToString();
                    return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
                }
            }
        }

        private Usuario LerUsuarioDoReader(MySqlDataReader reader)
        {
            return new Usuario
            {
                Id = Convert.ToInt32(reader["id"]),
                ClienteId = Convert.ToInt32(reader["cliente_id"]),
                Login = reader["login"].ToString(),
                Senha = reader["senha"].ToString(),
                Ativo = Convert.ToBoolean(reader["ativo"]),
                DataCriacao = Convert.ToDateTime(reader["data_criacao"]),
                Tipo = reader["tipo"].ToString()
            };
        }
    }
}
