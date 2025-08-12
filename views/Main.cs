using DigiBank.controllers;
using DigiBank.models;
using DigiBank.repositories;
using DigiBank.services;
using DigiBank.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank
{
    public partial class Main : Form
    {

        Usuario usuarioLogado = new Usuario();


        public Main()
        {
            InitializeComponent();
            ConfigurarUsuario();
        }
        public Main(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogado = usuario;
            if (usuario != null)
            {
                ConfigurarUsuario();
            }

            // Carregar dashboard por padrão
            btnDashboard_Click(null, null);
        }

        private void ConfigurarUsuario()
        {
            if (usuarioLogado != null)
            {
                // Configurar informações do usuário
                lblNomeUsuario.Text = usuarioLogado.Login;
                lblCPF.Text = $"ID: {usuarioLogado.Id}";

                // Gerar iniciais do nome
                var iniciais = GerarIniciais(usuarioLogado.Login);
                lblIniciais.Text = iniciais;
            }
            else
            {
                lblNomeUsuario.Text = "Usuário";
                lblCPF.Text = "CPF: Não informado";
                lblIniciais.Text = "U";
            }
        }

        private string GerarIniciais(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return "U";

            var palavras = nome.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (palavras.Length == 0)
                return nome.Substring(0, 1).ToUpper();

            if (palavras.Length == 1)
                return palavras[0].Substring(0, 1).ToUpper();

            return (palavras[0].Substring(0, 1) + palavras[palavras.Length - 1].Substring(0, 1)).ToUpper();
        }

        private void CarregarClientes()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnDashboard);

            panelPrincipal.Controls.Clear();

            DashBoard telaDashboard = new DashBoard(usuarioLogado)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(telaDashboard);
            telaDashboard.Show();
        }
        public void btnTransacoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnTransacoes);

            panelPrincipal.Controls.Clear();

            Transacoes tela = new Transacoes(usuarioLogado)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnCartoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnCartoes);

            panelPrincipal.Controls.Clear();

            Cartoes tela = new Cartoes(usuarioLogado)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnTerminalPOS_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnTerminalPOS);

            panelPrincipal.Controls.Clear();

            //TerminalPOS tela = new TerminalPOS
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //panelPrincipal.Controls.Add(tela);
            //tela.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnConfiguracoes);

            panelPrincipal.Controls.Clear();

            //Configuracoes tela = new Configuracoes
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //panelPrincipal.Controls.Add(tela);
            //tela.Show();
        }





        private void ResetarEstiloBotoes()
        {
            // Lista com todos os botões do menu
            List<Button> botoesMenu = new List<Button>
            {
                btnDashboard,
                btnTransacoes,
                btnCartoes,
                btnTerminalPOS,
                btnConfiguracoes
            };

            foreach (var botao in botoesMenu)
            {
                botao.BackColor = Color.White;
                botao.ForeColor = Color.Black;
                botao.FlatAppearance.BorderSize = 0;
            }
        }

        private void SelecionarBotao(Button botao)
        {
            // Resetar todos
            ResetarEstiloBotoes();

            // Estilo de selecionado
            botao.BackColor = Color.FromArgb(239, 246, 255);
            botao.ForeColor = Color.FromArgb(37, 99, 235);
        }
    }
}
