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
    public class UsuarioRepository
    {
        private readonly Database conn = new Database();
        private readonly MySqlConnection conexao;
        public UsuarioRepository()
        {
            conexao = conn.GetConnection();
        }

        public int Criar(Usuario usuario)
        {
            string sql = "INSERT INTO usuario (cliente_id, login, senha, ativo, data_criacao) VALUES (@cliente_id, @login, @senha, @ativo, @data_criacao)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cliente_id", usuario.ClienteId);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@ativo", usuario.Ativo);
            cmd.Parameters.AddWithValue("@data_criacao", usuario.DataCriacao);

            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;

        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = null;
            string sql = "SELECT * FROM usuario WHERE login = @login AND senha = @senha";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@login", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = reader.GetInt32("id"),
                        ClienteId = reader.GetInt32("cliente_id"),
                        Login = reader.GetString("login"),
                        Senha = reader.GetString("senha"),
                        Ativo = reader.GetBoolean("ativo"),
                        DataCriacao = reader.GetDateTime("data_criacao")
                    };
                }
            }
            conexao.Close();

            return usuario;
        }
    }
}
