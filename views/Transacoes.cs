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
    public partial class Transacoes : Form
    {
        #region Campos Privados
        private readonly Usuario _usuarioLogado;
        private readonly TransacaoController _transacaoController;
        private readonly ContaController _contaController;
        private List<Transacao> _listaTransacoes;
        private List<Conta> _listaContas;
        private List<Transacao> _transacoesFiltradas;
        #endregion

        #region Construtores
        public Transacoes()
        {
            InitializeComponent();
            _usuarioLogado = new Usuario();
            _transacaoController = new TransacaoController();
            _contaController = new ContaController();
            _listaTransacoes = new List<Transacao>();
            _listaContas = new List<Conta>();
            _transacoesFiltradas = new List<Transacao>();
        }

        public Transacoes(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogado = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _transacaoController = new TransacaoController();
            _contaController = new ContaController();
            _listaTransacoes = new List<Transacao>();
            _listaContas = new List<Conta>();
            _transacoesFiltradas = new List<Transacao>();

            CarregarDados();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDados()
        {
            try
            {
                CarregarContas();
                CarregarTransacoes();
                ConfigurarDataGridView();
                ConfigurarFiltros();
                AtualizarEstatisticas();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CarregarTransacoes()
        {
            _listaTransacoes.Clear();

            // Buscar transações de todas as contas do usuário
            foreach (var conta in _listaContas)
            {
                var transacoes = _transacaoController.BuscarPorContaId(conta.Id);
                if (transacoes != null)
                {
                    _listaTransacoes.AddRange(transacoes);
                }
            }

            // Se não houver transações reais, criar dados de exemplo
            if (_listaTransacoes.Count == 0)
            {
                CriarTransacoesExemplo();
            }

            _transacoesFiltradas = new List<Transacao>(_listaTransacoes);
        }

        private void CriarTransacoesExemplo()
        {
            var transacoesExemplo = new List<Transacao>
            {
                new Transacao
                {
                    Id = 1,
                    Tipo = "transferencia",
                    Valor = -250.00m,
                    Descricao = "Transferência PIX para Maria Silva",
                    DataTransacao = DateTime.Parse("2024-01-15 14:30"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 2,
                    Tipo = "deposito",
                    Valor = 1200.00m,
                    Descricao = "Depósito em dinheiro - Agência Centro",
                    DataTransacao = DateTime.Parse("2024-01-15 10:15"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 3,
                    Tipo = "saque",
                    Valor = -100.00m,
                    Descricao = "Saque ATM - Shopping Center",
                    DataTransacao = DateTime.Parse("2024-01-14 16:45"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 4,
                    Tipo = "transferencia",
                    Valor = -75.50m,
                    Descricao = "Pagamento NFC - Supermercado ABC",
                    DataTransacao = DateTime.Parse("2024-01-14 12:20"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 5,
                    Tipo = "transferencia",
                    Valor = -45.90m,
                    Descricao = "Pagamento NFC - Farmácia XYZ",
                    DataTransacao = DateTime.Parse("2024-01-13 18:30"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 6,
                    Tipo = "deposito",
                    Valor = 500.00m,
                    Descricao = "Transferência recebida de João Santos",
                    DataTransacao = DateTime.Parse("2024-01-13 09:15"),
                    ContaOrigemId = 2
                },
                new Transacao
                {
                    Id = 7,
                    Tipo = "saque",
                    Valor = -200.00m,
                    Descricao = "Saque ATM - Centro da Cidade",
                    DataTransacao = DateTime.Parse("2024-01-12 14:00"),
                    ContaOrigemId = 1
                },
                new Transacao
                {
                    Id = 8,
                    Tipo = "transferencia",
                    Valor = -120.00m,
                    Descricao = "Pagamento NFC - Restaurante Italiano",
                    DataTransacao = DateTime.Parse("2024-01-12 20:15"),
                    ContaOrigemId = 1
                }
            };

            _listaTransacoes.AddRange(transacoesExemplo);
        }

        private void ConfigurarDataGridView()
        {
            dgvTransacoes.AutoGenerateColumns = false;
            dgvTransacoes.AllowUserToAddRows = false;
            dgvTransacoes.AllowUserToDeleteRows = false;
            dgvTransacoes.ReadOnly = true;
            dgvTransacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransacoes.RowHeadersVisible = false;
            dgvTransacoes.BackgroundColor = Color.White;
            dgvTransacoes.BorderStyle = BorderStyle.None;
            dgvTransacoes.GridColor = Color.FromArgb(229, 231, 235);

            // Configurar colunas
            dgvTransacoes.Columns.Clear();

            // Coluna Tipo
            var colTipo = new DataGridViewTextBoxColumn
            {
                Name = "Tipo",
                HeaderText = "Tipo",
                DataPropertyName = "Tipo",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(17, 24, 39)
                }
            };

            // Coluna Descrição
            var colDescricao = new DataGridViewTextBoxColumn
            {
                Name = "Descricao",
                HeaderText = "Descrição",
                DataPropertyName = "Descricao",
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39)
                }
            };

            // Coluna Conta
            var colConta = new DataGridViewTextBoxColumn
            {
                Name = "Conta",
                HeaderText = "Conta",
                DataPropertyName = "ContaOrigemId",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(107, 114, 128)
                }
            };

            // Coluna Data
            var colData = new DataGridViewTextBoxColumn
            {
                Name = "Data",
                HeaderText = "Data",
                DataPropertyName = "DataTransacao",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Format = "dd/MM/yyyy HH:mm"
                }
            };

            // Coluna Valor
            var colValor = new DataGridViewTextBoxColumn
            {
                Name = "Valor",
                HeaderText = "Valor",
                DataPropertyName = "Valor",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Format = "C",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            // Coluna Status
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 163, 74),
                    BackColor = Color.FromArgb(220, 252, 231),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvTransacoes.Columns.AddRange(new DataGridViewColumn[]
            {
                colTipo, colDescricao, colConta, colData, colValor, colStatus
            });

            // Configurar estilo do cabeçalho
            dgvTransacoes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvTransacoes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            dgvTransacoes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvTransacoes.ColumnHeadersHeight = 40;
            dgvTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void ConfigurarFiltros()
        {
            // Configurar ComboBox de tipo
            cmbTipoTransacao.Items.Clear();
            cmbTipoTransacao.Items.AddRange(new object[]
            {
                "Todas",
                "Depósitos",
                "Saques",
                "Transferências"
            });
            cmbTipoTransacao.SelectedIndex = 0;

            // Configurar eventos
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            txtBuscar.Enter += TxtBuscar_Enter;
            txtBuscar.Leave += TxtBuscar_Leave;
            cmbTipoTransacao.SelectedIndexChanged += CmbTipoTransacao_SelectedIndexChanged;
        }

        private void AtualizarEstatisticas()
        {
            try
            {
                var transacoesMes = _listaTransacoes
                    .Where(t => t.DataTransacao.Month == DateTime.Now.Month)
                    .ToList();

                var totalEntradas = transacoesMes
                    .Where(t => t.Valor > 0)
                    .Sum(t => t.Valor);

                var totalSaidas = transacoesMes
                    .Where(t => t.Valor < 0)
                    .Sum(t => Math.Abs(t.Valor));

                var saldoLiquido = totalEntradas - totalSaidas;

                // Atualizar labels
                lblTotalEntradas.Text = totalEntradas.ToString("C");
                lblTotalSaidas.Text = totalSaidas.ToString("C");
                lblSaldoLiquido.Text = saldoLiquido.ToString("C");

                // Configurar cores do saldo líquido
                if (saldoLiquido >= 0)
                {
                    lblSaldoLiquido.ForeColor = Color.FromArgb(34, 197, 94); // Verde
                }
                else
                {
                    lblSaldoLiquido.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            try
            {
                var termoBusca = txtBuscar.Text.ToLower();

                // Ignorar o texto placeholder
                if (termoBusca == "🔍 buscar transações...")
                {
                    termoBusca = "";
                }

                var tipoSelecionado = cmbTipoTransacao.SelectedItem?.ToString();

                _transacoesFiltradas = _listaTransacoes.Where(t =>
                {
                    var matchesSearch = string.IsNullOrEmpty(termoBusca) ||
                                       t.Descricao.ToLower().Contains(termoBusca);

                    var matchesType = tipoSelecionado == "Todas" ||
                                    (tipoSelecionado == "Depósitos" && t.Valor > 0) ||
                                    (tipoSelecionado == "Saques" && t.Tipo == "saque") ||
                                    (tipoSelecionado == "Transferências" && t.Tipo == "transferencia");

                    return matchesSearch && matchesType;
                }).ToList();

                AtualizarDataGridView();
                AtualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            try
            {
                // Criar lista de objetos anônimos para o DataGridView
                var dadosParaGrid = _transacoesFiltradas.Select(t =>
                {
                    var conta = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                    var nomeConta = conta != null ?
                        (conta.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança") :
                        "Conta";

                    return new
                    {
                        Tipo = ObterNomeTipoTransacao(t.Tipo),
                        Descricao = t.Descricao,
                        Conta = nomeConta,
                        DataTransacao = t.DataTransacao,
                        Valor = t.Valor,
                        Status = "Concluída"
                    };
                }).ToList();

                dgvTransacoes.DataSource = dadosParaGrid;

                // Aplicar formatação de cores
                foreach (DataGridViewRow row in dgvTransacoes.Rows)
                {
                    if (row.DataBoundItem != null)
                    {
                        var valor = (decimal)row.Cells["Valor"].Value;
                        var tipo = row.Cells["Tipo"].Value?.ToString();

                        // Colorir valores
                        if (valor > 0)
                        {
                            row.Cells["Valor"].Style.ForeColor = Color.FromArgb(34, 197, 94); // Verde
                        }
                        else
                        {
                            row.Cells["Valor"].Style.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho
                        }

                        // Colorir tipos
                        switch (tipo?.ToLower())
                        {
                            case "depósito":
                                row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(34, 197, 94);
                                break;
                            case "saque":
                                row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(239, 68, 68);
                                break;
                            case "transferência":
                                row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(59, 130, 246);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar DataGridView: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarContador()
        {
            lblContadorTransacoes.Text = $"{_transacoesFiltradas.Count} transações encontradas";
        }

        private string ObterNomeTipoTransacao(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
                return "Desconhecido";

            switch (tipo.ToLower())
            {
                case "deposito":
                    return "Depósito";
                case "saque":
                    return "Saque";
                case "transferencia":
                    return "Transferência";
                default:
                    return tipo;
            }
        }
        #endregion

        #region Event Handlers
        private void Transacoes_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "🔍 Buscar transações...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.FromArgb(17, 24, 39);
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "🔍 Buscar transações...";
                txtBuscar.ForeColor = Color.FromArgb(156, 163, 175);
            }
        }

        private void CmbTipoTransacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnMaisFiltros_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de filtros avançados será implementada em breve!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivo CSV (*.csv)|*.csv|Arquivo Excel (*.xlsx)|*.xlsx",
                    Title = "Exportar Transações",
                    FileName = $"transacoes_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implementar exportação
                    MessageBox.Show("Funcionalidade de exportação será implementada em breve!", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você não tem novas notificações!", "Notificações",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
