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
                        // Debug: mostrar o UID lido
                        Console.WriteLine($"Tentando login com UID: {uidLido}");

                        // Primeiro, buscar o cartão pelo UID
                        CartaoController cartaoController = new CartaoController();
                        var cartao = cartaoController.BuscarPorUid(uidLido);

                        if (cartao != null && cartao.Ativo)
                        {
                            Console.WriteLine($"Cartão encontrado: ID={cartao.Id}, ContaID={cartao.ContaId}");

                            // Buscar a conta associada ao cartão
                            ContaController contaController = new ContaController();
                            var conta = contaController.BuscarPorId(cartao.ContaId);

                            if (conta != null)
                            {
                                Console.WriteLine($"Conta encontrada: ID={conta.Id}, ClienteID={conta.ClienteId}");

                                // Buscar o usuário associado ao cliente da conta
                                var usuario = usuarioController.BuscarPorClienteId(conta.ClienteId);

                                if (usuario != null && usuario.Ativo)
                                {
                                    Console.WriteLine($"Usuário encontrado: ID={usuario.Id}, Login={usuario.Login}");
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
                                    lblError.Text = "Usuário associado ao cartão não encontrado ou inativo!";
                                    bufferUID = "";
                                    Console.WriteLine("Usuário não encontrado ou inativo");
                                }
                            }
                            else
                            {
                                lblError.Text = "Conta associada ao cartão não encontrada!";
                                bufferUID = "";
                                Console.WriteLine("Conta não encontrada");
                            }
                        }
                        else
                        {
                            lblError.Text = "Cartão não encontrado ou inativo!";
                            bufferUID = "";
                            Console.WriteLine("Cartão não encontrado ou inativo");
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = $"Erro no login por UID: {ex.Message}";
                        bufferUID = "";
                        Console.WriteLine($"Erro no login por UID: {ex.Message}");
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

                var usuario = usuarioController.FazerLogin(email, senha);
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

                        // Buscar usuário
                        var usuario = usuarioController.BuscarPorClienteId(conta.ClienteId);
                        if (usuario != null)
                        {
                            mensagem += $"Usuário encontrado: ID={usuario.Id}, Login={usuario.Login}\n";
                        }
                        else
                        {
                            mensagem += "Usuário NÃO encontrado!\n";
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
    }
}

