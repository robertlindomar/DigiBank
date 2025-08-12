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
                AtualizarEstatisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarLabelBemVindo()
        {
            if (lblSubtitulo != null)
            {
                lblSubtitulo.Text = $"Bem-vindo de volta, {_usuarioLogado.Login}!";
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
            if (lblTipoConta != null)
            {
                var nomeTipo = string.Equals(tipo, TIPO_CONTA_CORRENTE, StringComparison.OrdinalIgnoreCase)
                    ? "Conta Corrente"
                    : "Conta Poupança";

                var conta = ObterContaPorTipo(tipo);
                if (conta != null)
                {
                    lblTipoConta.Text = $"{nomeTipo} • {conta.NumeroConta}";
                }
            }
        }

        private void AtualizarEstatisticas()
        {
            try
            {
                // Carregar transações recentes (apenas 2)
                CarregarTransacoesRecentes();

                // Carregar cartões NFC (apenas 2 - limite máximo)
                CarregarCartoesNFC();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTransacoesRecentes()
        {
            try
            {
                panelListaTransacoes.Controls.Clear();

                // TODO: Buscar transações recentes do banco
                // Por enquanto, criar transações de exemplo
                var transacoes = new[]
                {
                    new { Tipo = "Transferência PIX", Data = "2024-01-15 14:30", Valor = -250.00m, Cor = Color.Red },
                    new { Tipo = "Depósito em dinheiro", Data = "2024-01-15 10:15", Valor = 1200.00m, Cor = Color.Green },
                    new { Tipo = "Saque ATM", Data = "2024-01-14 16:45", Valor = -100.00m, Cor = Color.Red },
                    new { Tipo = "Pagamento de conta", Data = "2024-01-13 09:20", Valor = -89.90m, Cor = Color.Red },
                    new { Tipo = "Depósito PIX", Data = "2024-01-12 16:45", Valor = 500.00m, Cor = Color.Green }
                };

                // Mostrar apenas as 2 transações mais recentes
                var transacoesRecentes = transacoes.Take(2).ToArray();

                foreach (var transacao in transacoesRecentes)
                {
                    var panel = new Panel
                    {
                        BackColor = Color.FromArgb(249, 250, 251),
                        Size = new Size(380, 60),
                        Margin = new Padding(0, 0, 0, 8)
                    };

                    var lblTipo = new Label
                    {
                        Text = transacao.Tipo,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.FromArgb(17, 24, 39),
                        Location = new Point(12, 8),
                        AutoSize = true
                    };

                    var lblData = new Label
                    {
                        Text = transacao.Data,
                        Font = new Font("Segoe UI", 8),
                        ForeColor = Color.FromArgb(107, 114, 128),
                        Location = new Point(12, 28),
                        AutoSize = true
                    };

                    var lblValor = new Label
                    {
                        Text = transacao.Valor.ToString("C"),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = transacao.Cor,
                        Location = new Point(280, 20),
                        AutoSize = true
                    };

                    panel.Controls.Add(lblTipo);
                    panel.Controls.Add(lblData);
                    panel.Controls.Add(lblValor);
                    panelListaTransacoes.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar transações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarCartoesNFC()
        {
            try
            {
                panelListaCartoes.Controls.Clear();

                // TODO: Buscar cartões do banco
                // Por enquanto, criar cartões de exemplo
                var cartoes = new[]
                {
                    new { Nome = "Cartão Principal", Conta = "Conta Corrente", UID = "A1B2C3D4", Ativo = true },
                    new { Nome = "Cartão Backup", Conta = "Conta Poupança", UID = "E5F6G7H8", Ativo = false }
                };

                // Limite máximo de 2 cartões por usuário
                const int LIMITE_CARTOES = 2;
                var cartoesExibidos = cartoes.Take(LIMITE_CARTOES).ToArray();

                foreach (var cartao in cartoesExibidos)
                {
                    var panel = new Panel
                    {
                        BackColor = Color.FromArgb(249, 250, 251),
                        Size = new Size(380, 60),
                        Margin = new Padding(0, 0, 0, 8)
                    };

                    var lblNome = new Label
                    {
                        Text = cartao.Nome,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.FromArgb(17, 24, 39),
                        Location = new Point(12, 8),
                        AutoSize = true
                    };

                    var lblConta = new Label
                    {
                        Text = cartao.Conta,
                        Font = new Font("Segoe UI", 8),
                        ForeColor = Color.FromArgb(107, 114, 128),
                        Location = new Point(12, 28),
                        AutoSize = true
                    };

                    var lblUID = new Label
                    {
                        Text = $"UID: {cartao.UID}",
                        Font = new Font("Segoe UI", 7),
                        ForeColor = Color.FromArgb(156, 163, 175),
                        Location = new Point(12, 42),
                        AutoSize = true
                    };

                    var lblStatus = new Label
                    {
                        Text = cartao.Ativo ? "Ativo" : "Inativo",
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        ForeColor = cartao.Ativo ? Color.FromArgb(30, 64, 175) : Color.FromArgb(107, 114, 128),
                        BackColor = cartao.Ativo ? Color.FromArgb(219, 234, 254) : Color.FromArgb(243, 244, 246),
                        Location = new Point(280, 20),
                        Size = new Size(60, 20),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    panel.Controls.Add(lblNome);
                    panel.Controls.Add(lblConta);
                    panel.Controls.Add(lblUID);
                    panel.Controls.Add(lblStatus);
                    panelListaCartoes.Controls.Add(panel);
                }

                // Atualizar estatísticas dos cartões
                if (lblCartoesAtivos != null)
                {
                    lblCartoesAtivos.Text = cartoesExibidos.Count(c => c.Ativo).ToString();
                }

                if (progressBarCartoes != null)
                {
                    int percentual = cartoesExibidos.Length > 0 ? (cartoesExibidos.Count(c => c.Ativo) * 100) / cartoesExibidos.Length : 0;
                    progressBarCartoes.Value = percentual;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cartões: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AtualizarEstatisticas();

            // Atualizar estilo dos botões
            btnCorrente.BackColor = Color.FromArgb(37, 99, 235);
            btnCorrente.ForeColor = Color.White;
            btnPoupanca.BackColor = Color.White;
            btnPoupanca.ForeColor = Color.FromArgb(55, 65, 81);
        }

        private void btnPoupanca_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo(TIPO_CONTA_POUPANCA);
            AtualizarEstatisticas();

            // Atualizar estilo dos botões
            btnPoupanca.BackColor = Color.FromArgb(37, 99, 235);
            btnPoupanca.ForeColor = Color.White;
            btnCorrente.BackColor = Color.White;
            btnCorrente.ForeColor = Color.FromArgb(55, 65, 81);
        }

        private void btnVerTodasTransacoes_Click(object sender, EventArgs e)
        {
            try
            {
                // Acessar o formulário pai (Main) e executar a mesma lógica do btnTransacoes_Click
                if (this.ParentForm is Main mainForm)
                {
                    // Simular o clique no botão de Transações do Main
                    mainForm.btnTransacoes_Click(null, null);
                }
                else
                {
                    // Fallback: se não conseguir acessar o Main, abrir em nova janela
                    var telaTransacoes = new Transacoes(_usuarioLogado);
                    telaTransacoes.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir transações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers vazios podem ser removidos se não forem necessários
        // ou implementados conforme necessário
        #endregion
    }
}
