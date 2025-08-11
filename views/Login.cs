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
        private string bufferUID = "";
        private bool bloqueioLeitura = false;
        public Login()
        {
            InitializeComponent();
            lblError.Text = "";

            // Para capturar as teclas digitadas
            this.KeyPreview = true;

            




        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (bloqueioLeitura)
                return base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Enter)
            {
                string uidLido = bufferUID.Trim();
                bufferUID = "";

                if (!string.IsNullOrEmpty(uidLido))
                {
                    try
                    {
                        var usuario = usuarioController.LoginPorUID(uidLido);
                        if (usuario != null)
                        {
                            bloqueioLeitura = true;
                            
                            Main telaDashboard = new Main(usuario);
                            telaDashboard.FormClosed += (s, args) =>
                            {
                                bloqueioLeitura = false;
                                this.Show();
                            };
                            telaDashboard.Show();
                            this.Hide();
                            lblError.Text = "";
                        }
                        else
                        {
                            lblError.Text = "UID inválido!";
                            bufferUID = "";

                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = $"Erro no login por UID: {ex.Message}";
                        bufferUID = "";

                        
                    }
                }
                return true; // tecla processada
            }
            else
            {
                // Acumula os caracteres no buffer apenas para caracteres imprimíveis
                if (!char.IsControl((char)keyData))
                {
                    bufferUID += (char)keyData;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtLogin.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                bufferUID = "Por favor, preencha todos os campos.";

                return;
            }
            try
            {

                var usuario = usuarioController.Login(email, senha);
                if (usuario != null)
                {

                    

                    Main telaDashboard = new Main(usuario);
                    telaDashboard.FormClosed += (s, args) => this.Show();

                    telaDashboard.Show();
                    this.Hide(); // Esconde a tela de login
                    bufferUID = "";
                }
                else
                {
                    bufferUID = "Usuário ou senha inválidos.";
                }
            }
            catch (Exception ex)
            {
                bufferUID = $"Ocorreu um erro ao tentar fazer login: {ex.Message}";
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
            this.Hide();
        }
    }
}
