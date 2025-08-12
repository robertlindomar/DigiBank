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
        #region Campos Privados
        private readonly Usuario _usuarioLogado;
        private readonly List<Conta> _listaContas;
        private readonly ContaController _contaController;
        private Conta _contaAtual;
        #endregion

        #region Constantes
        private const string TIPO_CONTA_CORRENTE = "corrente";
        private const string TIPO_CONTA_POUPANCA = "poupanca";
        #endregion

        #region Construtores
        public DashBoard()
        {
            InitializeComponent();
            _usuarioLogado = new Usuario();
            _listaContas = new List<Conta>();
            _contaController = new ContaController();
        }

        public DashBoard(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogado = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _listaContas = new List<Conta>();
            _contaController = new ContaController();

            CarregarDadosUsuario();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDadosUsuario()
        {
            try
            {
                AtualizarLabelBemVindo();
                CarregarContas();
                ConfigurarInterface();
                ExibirSaldoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarLabelBemVindo()
        {
            if (labelBemVindo != null)
            {
                labelBemVindo.Text = $"Bem-vindo de volta, {_usuarioLogado.Login}!";
            }
        }

        private void CarregarContas()
        {
            _listaContas.Clear();
            var contas = _contaController.BuscarPorClienteId(_usuarioLogado.ClienteId);

            if (contas != null)
            {
                _listaContas.AddRange(contas);
            }
        }

        private void ConfigurarInterface()
        {
            var contaCorrente = ObterContaPorTipo(TIPO_CONTA_CORRENTE);
            var contaPoupanca = ObterContaPorTipo(TIPO_CONTA_POUPANCA);

            // Configurar botões
            ConfigurarBotaoConta(btnCorrente, contaCorrente, "Conta Corrente");
            ConfigurarBotaoConta(btnPoupanca, contaPoupanca, "Conta Poupança");

            // Definir conta inicial (prioridade: corrente > poupança)
            _contaAtual = contaCorrente ?? contaPoupanca;
        }

        private void ConfigurarBotaoConta(Button botao, Conta conta, string tipoConta)
        {
            if (botao != null)
            {
                botao.Visible = conta != null;
                botao.Enabled = conta != null;

                if (conta != null)
                {
                    botao.Text = $"{tipoConta} • {conta.NumeroConta}";
                }
            }
        }

        private Conta ObterContaPorTipo(string tipo)
        {
            return _listaContas.FirstOrDefault(c =>
                string.Equals(c.Tipo, tipo, StringComparison.OrdinalIgnoreCase));
        }

        private void ExibirSaldoInicial()
        {
            if (_contaAtual != null)
            {
                ExibirSaldoPorTipo(_contaAtual.Tipo);
            }
        }

        private void ExibirSaldoPorTipo(string tipoDesejado)
        {
            try
            {
                var saldoTotal = CalcularSaldoTotal(tipoDesejado);
                AtualizarLabelSaldo(saldoTotal);
                AtualizarLabelTipoConta(tipoDesejado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir saldo: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularSaldoTotal(string tipoDesejado)
        {
            return _listaContas
                .Where(c => string.Equals(c.Tipo, tipoDesejado, StringComparison.OrdinalIgnoreCase))
                .Sum(c => c.Saldo);
        }

        private void AtualizarLabelSaldo(decimal saldo)
        {
            if (lblSaldo != null)
            {
                lblSaldo.Text = saldo.ToString("C");
            }
        }

        private void AtualizarLabelTipoConta(string tipo)
        {
            if (labelCorrenteOuPoupanca != null)
            {
                var nomeTipo = string.Equals(tipo, TIPO_CONTA_CORRENTE, StringComparison.OrdinalIgnoreCase)
                    ? "Conta Corrente"
                    : "Conta Poupança";

                var conta = ObterContaPorTipo(tipo);
                if (conta != null)
                {
                    labelCorrenteOuPoupanca.Text = $"{nomeTipo} • {conta.NumeroConta}";
                }
            }
        }
        #endregion

        #region Event Handlers
        private void Form2_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário
        }

        private void btnCorrente_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo(TIPO_CONTA_CORRENTE);
        }

        private void btnPoupanca_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo(TIPO_CONTA_POUPANCA);
        }

        // Event handlers vazios podem ser removidos se não forem necessários
        // ou implementados conforme necessário
        #endregion
    }
}
