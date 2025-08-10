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
        public Main() {
            InitializeComponent();

            labelUsuarioLogado.Text = "DESENVOLVEDOR !";
        }
        public Main(Usuario usuarioLogado)
        {
            InitializeComponent();
            if(usuarioLogado != null)
            {
                labelUsuarioLogado.Text = $"Usuário: {usuarioLogado.Login}";
            }
            


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

            painelPrincipal.Controls.Clear();

            DashBoard telaDashboard = new DashBoard
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            painelPrincipal.Controls.Add(telaDashboard);
            telaDashboard.Show();
        }
        private void btnTransacoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnTransacoes);

            painelPrincipal.Controls.Clear();
            
            //Transacoes tela = new Transacoes
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //painelPrincipal.Controls.Add(tela);
            //tela.Show();
        }

        private void btnCartoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnCartoes);

            painelPrincipal.Controls.Clear();

            //Cartoes tela = new Cartoes
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //painelPrincipal.Controls.Add(tela);
            //tela.Show();
        }

        private void btnTerminalPOS_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnTerminalPOS);

            painelPrincipal.Controls.Clear();

            //TerminalPOS tela = new TerminalPOS
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //painelPrincipal.Controls.Add(tela);
            //tela.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnConfiguracoes);

            painelPrincipal.Controls.Clear();

            //Configuracoes tela = new Configuracoes
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};
            //painelPrincipal.Controls.Add(tela);
            //tela.Show();
        }
        


        private void painelPrincipal_Paint(object sender, PaintEventArgs e)
        {

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
            botao.ForeColor = Color.FromArgb(57, 82, 251);
        }
    }
}
