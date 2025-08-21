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
using DigiBank.repositories;

namespace DigiBank.views
{
    public partial class Login : Form
    {
        ClienteController clienteController = new ClienteController();
        private string bufferUID = "";
        private bool bloqueioLeitura = false;
        public Login()
        {
            InitializeComponent();
            lblError.Text = "";

            // Para capturar as teclas digitadas
            this.KeyPreview = true;

            // Configurar os textos da nova interface
            // lblIcon.Text = "⚡";
            // lblLogo.Text = "DigiBank";
            // lblTagline.Text = "Seu banco digital com tecnologia NFC";
            // lblTitle.Text = "Entrar na sua conta";
            // lblSubtitle.Text = "Digite suas credenciais para acessar o sistema";
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

                        // Primeiro, buscar o cartão pelo UID
                        CartaoController cartaoController = new CartaoController();
                        var cartao = cartaoController.BuscarPorUid(uidLido);

                        if (cartao != null && cartao.Ativo)
                        {

                            // Buscar a conta associada ao cartão
                            ContaController contaController = new ContaController();
                            var conta = contaController.BuscarPorId(cartao.ContaId);

                            if (conta != null)
                            {

                                // Buscar o cliente associado à conta
                                var cliente = clienteController.BuscarPorId(conta.ClienteId);

                                if (cliente != null && cliente.Ativo)
                                {
                                    bloqueioLeitura = true;

                                    Main telaDashboard = new Main(cliente);
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
                                    lblError.Text = "Usuário associado ao cartão não encontrado ou inativo!";
                                    bufferUID = "";
                                }
                            }
                            else
                            {
                                lblError.Text = "Conta associada ao cartão não encontrada!";
                                bufferUID = "";
                            }
                        }
                        else
                        {
                            lblError.Text = "Cartão não encontrado ou inativo!";
                            bufferUID = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = $"Erro no login por UID: {ex.Message}";
                        bufferUID = "";
                    }
                }
                return true;
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
                lblError.Text = "Por favor, preencha todos os campos.";
                return;
            }
            try
            {

                var cliente = clienteController.FazerLogin(email, senha);
                if (cliente != null)
                {



                    Main telaDashboard = new Main(cliente);
                    telaDashboard.FormClosed += (s, args) => this.Show();

                    telaDashboard.Show();
                    this.Hide(); // Esconde a tela de login
                    bufferUID = "";
                }
                else
                {
                    lblError.Text = "Usuário ou senha inválidos.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"Ocorreu um erro ao tentar fazer login: {ex.Message}";
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

