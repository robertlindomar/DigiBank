using DigiBank.controllers;
using DigiBank.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.views
{

    public partial class DashBoard : Form
    {
        Usuario usuarioLogado = new Usuario();

        List<Conta> listaContaLogada = new List<Conta>();

        Cliente clienteLogado = new Cliente();

        ContaController contaController = new ContaController();






        public DashBoard()
        {
            InitializeComponent();
            
        }
        public DashBoard(Usuario usuario)
        {
            InitializeComponent();
            CarregarClientes(usuario);

        }
        private void CarregarClientes(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            labelBemVindo.Text = $"Bem-vindo de volta, {usuarioLogado.Login}!";


            listaContaLogada = contaController.BuscarPorClienteId(usuarioLogado.ClienteId);
        }

        private void CarregarPagina()
        {
            // Verifica se existe conta corrente
            bool temCorrente = false;
            bool temPoupanca = false;

            foreach (Conta c in listaContaLogada)
            {
                if (string.Equals(c.Tipo, "corrente", StringComparison.OrdinalIgnoreCase))
                {
                    temCorrente = true;
                    labelCorrenteOuPoupanca.Text = $"Conta Corrente • 12345-6";

                }


                if (string.Equals(c.Tipo, "poupanca", StringComparison.OrdinalIgnoreCase))
                {
                    temPoupanca = true;
                    labelCorrenteOuPoupanca.Text = $"Conta Poupanca • 12345-6";
                }
            }

             //Mostra ou esconde os botões
            btnCorrente.Visible = temCorrente;
            btnPoupanca.Visible = temPoupanca;

            // Se preferir só desabilitar em vez de ocultar:
            //btnCorrente.Enabled = temCorrente;
            //btnPoupanca.Enabled = temPoupanca;
        }


        private void ExibirSaldoPorTipo(string tipoDesejado)
        {
            decimal saldoTotal = 0;

            foreach (Conta c in listaContaLogada)
            {
                if (string.Equals(c.Tipo, tipoDesejado, StringComparison.OrdinalIgnoreCase))
                {

                    saldoTotal += c.Saldo;
                }
            }

            CarregarPagina();
            lblSaldo.Text = saldoTotal.ToString("C");

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCorrente_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo("corrente");

        }

        private void btnPoupanca_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo("poupança");

        }
    }
}
