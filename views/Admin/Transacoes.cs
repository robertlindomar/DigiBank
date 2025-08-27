using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigiBank.services;
using DigiBank.models;
using System.IO;

namespace DigiBank.views.Admin
{
    public partial class Transacoes : Form
    {
        private TransacaoService _transacaoService;
        private ContaService _contaService;
        private List<Transacao> _transacoesOriginais;
        private List<Transacao> _transacoesFiltradas;
        private bool _isPlaceholderVisible = true;

        public Transacoes()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarTransacoes();
        }

        private void InicializarServicos()
        {
            _transacaoService = new TransacaoService();
            _contaService = new ContaService();
            _transacoesOriginais = new List<Transacao>();
            _transacoesFiltradas = new List<Transacao>();
        }

        private void ConfigurarInterface()
        {
            // Configurar DataGridView
            dgvTransacoes.AutoGenerateColumns = false;
            dgvTransacoes.Columns.Clear();

            // Adicionar colunas
            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 120,
                ReadOnly = true
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Valor",
                HeaderText = "Valor (R$)",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataTransacao",
                HeaderText = "Data/Hora",
                Width = 150,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContaOrigemId",
                HeaderText = "Conta Origem",
                Width = 100,
                ReadOnly = true
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContaDestinoId",
                HeaderText = "Conta Destino",
                Width = 100,
                ReadOnly = true
            });

            dgvTransacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descricao",
                HeaderText = "Descrição",
                Width = 200,
                ReadOnly = true
            });

            // Configurar comboboxes
            ConfigurarComboboxes();
            cmbTipoClientes.SelectedIndex = 0;
            cmbTipoClienteAtvInt.SelectedIndex = 0;

            // Configurar placeholders
            ConfigurarPlaceholder();
        }

        private void ConfigurarComboboxes()
        {
            // Limpar e configurar cmbTipoClientes (tipos de transação)
            cmbTipoClientes.Items.Clear();
            cmbTipoClientes.Items.AddRange(new object[] { "Todas", "Depósitos", "Saques", "Transferências" });

            // Limpar e configurar cmbTipoClienteAtvInt (tipos de conta)
            cmbTipoClienteAtvInt.Items.Clear();
            cmbTipoClienteAtvInt.Items.AddRange(new object[] { "Todas as Contas", "Conta Corrente", "Conta Poupança" });
        }

        private void ConfigurarPlaceholder()
        {
            txtBuscarClientes.ForeColor = Color.Gray;
            txtBuscarClientes.Text = "🔍 Buscar por descrição, valor ou ID...";
            _isPlaceholderVisible = true;
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnExportarTransacao.Click += BtnExportarTransacao_Click;

            // Eventos de filtros
            txtBuscarClientes.Enter += TxtBuscarClientes_Enter;
            txtBuscarClientes.Leave += TxtBuscarClientes_Leave;
            txtBuscarClientes.TextChanged += TxtBuscarClientes_TextChanged;

            // Eventos do DataGridView
            dgvTransacoes.SelectionChanged += DgvTransacoes_SelectionChanged;
            dgvTransacoes.CellDoubleClick += DgvTransacoes_CellDoubleClick;

            // Eventos dos comboboxes
            cmbTipoClientes.SelectedIndexChanged += CmbTipoClientes_SelectedIndexChanged;
            cmbTipoClienteAtvInt.SelectedIndexChanged += CmbTipoClienteAtvInt_SelectedIndexChanged;
        }

        private void TxtBuscarClientes_Enter(object sender, EventArgs e)
        {
            if (_isPlaceholderVisible)
            {
                txtBuscarClientes.Text = "";
                txtBuscarClientes.ForeColor = Color.Black;
                _isPlaceholderVisible = false;
            }
        }

        private void TxtBuscarClientes_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarClientes.Text))
            {
                ConfigurarPlaceholder();
            }
        }

        private void TxtBuscarClientes_TextChanged(object sender, EventArgs e)
        {
            if (!_isPlaceholderVisible)
            {
                AplicarFiltros();
            }
        }

        private void CmbTipoClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CmbTipoClienteAtvInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            try
            {
                var textoBusca = _isPlaceholderVisible ? "" : txtBuscarClientes.Text.Trim().ToLower();
                var tipoTransacao = cmbTipoClientes.SelectedItem?.ToString();
                var tipoConta = cmbTipoClienteAtvInt.SelectedItem?.ToString();

                _transacoesFiltradas = _transacoesOriginais.Where(t =>
                {
                    // Filtro de texto
                    bool matchTexto = string.IsNullOrEmpty(textoBusca) ||
                                    t.Descricao?.ToLower().Contains(textoBusca) == true ||
                                    t.Id.ToString().Contains(textoBusca) ||
                                    t.Valor.ToString().Contains(textoBusca);

                    // Filtro por tipo de transação
                    bool matchTipo = tipoTransacao == "Todas" ||
                                   (tipoTransacao == "Depósitos" && t.Tipo?.ToLower() == "deposito") ||
                                   (tipoTransacao == "Saques" && t.Tipo?.ToLower() == "saque") ||
                                   (tipoTransacao == "Transferências" && t.Tipo?.ToLower() == "transferencia");

                    // Filtro por tipo de conta (será implementado quando tivermos acesso às contas)
                    bool matchConta = tipoConta == "Todas as Contas"; // Por enquanto sempre true

                    return matchTexto && matchTipo && matchConta;
                }).ToList();

                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            dgvTransacoes.DataSource = null;
            dgvTransacoes.DataSource = _transacoesFiltradas;
            AtualizarContadores();
        }

        private void AtualizarContadores()
        {
            var totalTransacoes = _transacoesFiltradas.Count;
            var totalGeral = _transacoesOriginais.Count;

            if (totalTransacoes != totalGeral)
            {
                lblSubtitulo.Text = $"Monitore todas as transações do sistema - {totalTransacoes} de {totalGeral} transações";
            }
            else
            {
                lblSubtitulo.Text = $"Monitore todas as transações do sistema - {totalGeral} transações";
            }
        }

        private void CarregarTransacoes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _transacoesOriginais = _transacaoService.BuscarTodas();
                _transacoesFiltradas = _transacoesOriginais.ToList();
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar transações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnExportarTransacao_Click(object sender, EventArgs e)
        {
            try
            {
                if (_transacoesFiltradas.Count == 0)
                {
                    MessageBox.Show("Não há transações para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Arquivo CSV (Excel) (*.csv)|*.csv|Todos os arquivos (*.*)|*.*",
                    FileName = $"transacoes_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Exportar Transações para Excel"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarParaCSV(saveDialog.FileName);
                    MessageBox.Show($"Transações exportadas com sucesso para:\n{saveDialog.FileName}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar transações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarParaCSV(string caminhoArquivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, false, Encoding.UTF8))
                {
                    // Cabeçalho - usando ponto e vírgula como separador
                    writer.WriteLine("ID;Tipo;Valor;Data/Hora;Conta Origem;Conta Destino;Descrição");

                    // Dados
                    foreach (var transacao in _transacoesFiltradas)
                    {
                        // Tratar cada campo adequadamente para evitar problemas no Excel
                        var id = transacao.Id.ToString();
                        var tipo = transacao.Tipo ?? "";
                        var valor = transacao.Valor.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                        var data = transacao.DataTransacao.ToString("dd/MM/yyyy HH:mm:ss");
                        var contaOrigem = transacao.ContaOrigemId?.ToString() ?? "";
                        var contaDestino = transacao.ContaDestinoId?.ToString() ?? "";
                        var descricao = transacao.Descricao?.Replace(";", ",").Replace("\"", "'") ?? "";

                        // Montar linha com ponto e vírgula como separador
                        var linha = $"{id};{tipo};{valor};{data};{contaOrigem};{contaDestino};{descricao}";

                        writer.WriteLine(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao escrever arquivo CSV: {ex.Message}");
            }
        }

        private void DgvTransacoes_SelectionChanged(object sender, EventArgs e)
        {
            // Por enquanto não há ações específicas para seleção
            // Pode ser implementado no futuro para mostrar detalhes da transação
        }

        private void DgvTransacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Por enquanto não há edição de transações
                // Pode ser implementado no futuro para mostrar detalhes da transação
                var transacao = dgvTransacoes.Rows[e.RowIndex].DataBoundItem as Transacao;
                if (transacao != null)
                {
                    MessageBox.Show(
                        $"Detalhes da Transação:\n\n" +
                        $"ID: {transacao.Id}\n" +
                        $"Tipo: {transacao.Tipo}\n" +
                        $"Valor: R$ {transacao.Valor:F2}\n" +
                        $"Data: {transacao.DataTransacao:dd/MM/yyyy HH:mm:ss}\n" +
                        $"Conta Origem: {transacao.ContaOrigemId?.ToString() ?? "N/A"}\n" +
                        $"Conta Destino: {transacao.ContaDestinoId?.ToString() ?? "N/A"}\n" +
                        $"Descrição: {transacao.Descricao ?? "N/A"}",
                        "Detalhes da Transação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carregar dados quando o formulário for carregado
            CarregarTransacoes();
        }
    }
}
