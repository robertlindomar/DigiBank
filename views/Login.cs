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

        private void button2_Click(object sender, EventArgs e)
        {
            // Teste para verificar cartoes no banco
            try
            {
                CartaoController cartaoController = new CartaoController();
                var cartoes = cartaoController.BuscarTodos();

                string mensagem = $"Cartões encontrados: {cartoes.Count}\n\n";
                foreach (var cartao in cartoes)
                {
                    mensagem += $"ID: {cartao.Id}, UID: {cartao.Uid}, Ativo: {cartao.Ativo}, ContaID: {cartao.ContaId}\n";
                }

                // Teste específico com UID conhecido
                string uidTeste = "0848182788"; // UID do admin no banco
                var cartaoTeste = cartaoController.BuscarPorUid(uidTeste);
                if (cartaoTeste != null)
                {
                    mensagem += $"\n\nTeste com UID {uidTeste}:\n";
                    mensagem += $"Cartão encontrado: ID={cartaoTeste.Id}, ContaID={cartaoTeste.ContaId}\n";

                    // Buscar conta
                    ContaController contaController = new ContaController();
                    var conta = contaController.BuscarPorId(cartaoTeste.ContaId);
                    if (conta != null)
                    {
                        mensagem += $"Conta encontrada: ID={conta.Id}, ClienteID={conta.ClienteId}\n";

                        // Buscar cliente
                        var cliente = clienteController.BuscarPorId(conta.ClienteId);
                        if (cliente != null)
                        {
                            mensagem += $"Cliente encontrado: ID={cliente.Id}, Login={cliente.Login}\n";
                        }
                        else
                        {
                            mensagem += "Cliente NÃO encontrado!\n";
                        }
                    }
                    else
                    {
                        mensagem += "Conta NÃO encontrada!\n";
                    }
                }
                else
                {
                    mensagem += $"\n\nTeste com UID {uidTeste}: Cartão NÃO encontrado!\n";
                }

                MessageBox.Show(mensagem, "Teste de Cartões");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar cartões: {ex.Message}", "Erro");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //criar cliente
                ClienteController clienteController = new ClienteController();
                clienteController.Criar(new Cliente(1, "admin", "35987612544", "admin", "123456", "admin"));
                clienteController.Criar(new Cliente(2, "usuario", "36985265377", "usuario", "123456", "cliente"));
                MessageBox.Show("Clientes cadastrados com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuários: {ex.Message}", "Erro");
            }
        }
    }
}

