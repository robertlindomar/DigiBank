using DigiBank.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigiBank.models;

namespace DigiBank.views
{
    public partial class Login : Form
    {
        UsuarioController usuarioController = new UsuarioController();
        public Login()
        {
            InitializeComponent();

        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = textLogin.Text;
            string senha = textSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            try
            {
                var usuario = usuarioController.Login(email, senha);
                if (usuario != null)
                {
                    MessageBox.Show("Login realizado com sucesso!");

                    Main telaDashboard = new Main(usuario);

                    telaDashboard.Show();
                    this.Hide(); // Esconde a tela de login

                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar fazer login: {ex.Message}");
            }

        }









        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main telaDashboard = new Main();

            telaDashboard.Show();
            this.Hide(); // Esconde a tela de login
        }
    }
}
