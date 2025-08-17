using System;
using System.Collections.Generic;

namespace DigiBank.models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Tipo { get; set; } // "cliente" ou "admin"

        // Propriedades de navegação
        public virtual List<Conta> Contas { get; set; }
        public virtual List<CartaoNfc> Cartoes { get; set; }

        public Cliente()
        {
            Ativo = true;
            DataCriacao = DateTime.Now;
            Tipo = "cliente";
            Contas = new List<Conta>();
            Cartoes = new List<CartaoNfc>();
        }

        public Cliente(int id, string nome, string cpf, string login, string senha, string tipo = "cliente")
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Login = login;
            Senha = senha;
            Tipo = tipo;
            Ativo = true;
            DataCriacao = DateTime.Now;
            Contas = new List<Conta>();
            Cartoes = new List<CartaoNfc>();
        }
    }
}
