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

                // Garantir que as transações filtradas estejam carregadas
                _transacoesFiltradas = new List<Transacao>(_listaTransacoes);

                // Aplicar cores imediatamente
                AtualizarDataGridView();
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

            // Debug: Log das transações carregadas
            Console.WriteLine($"Transações carregadas: {_listaTransacoes.Count}");
            foreach (var transacao in _listaTransacoes.Take(5)) // Mostrar apenas as 5 primeiras
            {
                Console.WriteLine($"- Transação {transacao.Id}: {transacao.Tipo} - {transacao.Valor:C} - {transacao.DataTransacao:dd/MM/yyyy}");
            }

            // Se não houver transações reais, criar dados de exemplo
            if (_listaTransacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação encontrada, criando dados de exemplo...");
                CriarTransacoesExemplo();
            }

            _transacoesFiltradas = new List<Transacao>(_listaTransacoes);

            Console.WriteLine($"Transações filtradas inicializadas: {_transacoesFiltradas.Count} transações");
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
            Console.WriteLine("Configurando DataGridView...");

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

            Console.WriteLine("DataGridView configurado com sucesso!");
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
                var mesAtual = DateTime.Now.Month;
                var anoAtual = DateTime.Now.Year;

                var transacoesMes = _listaTransacoes
                    .Where(t => t.DataTransacao.Month == mesAtual && t.DataTransacao.Year == anoAtual)
                    .ToList();

                // Separar transferências de entrada e saída baseado na conta do usuário
                var transferenciasEntrada = transacoesMes
                    .Where(t => t.Tipo == "transferencia" && t.ContaDestinoId.HasValue &&
                               _listaContas.Any(c => c.Id == t.ContaDestinoId.Value))
                    .ToList();

                var transferenciasSaida = transacoesMes
                    .Where(t => t.Tipo == "transferencia" && t.ContaOrigemId.HasValue &&
                               _listaContas.Any(c => c.Id == t.ContaOrigemId.Value))
                    .ToList();

                var totalEntradas = transacoesMes
                    .Where(t => t.Tipo == "deposito")
                    .Sum(t => t.Valor) + transferenciasEntrada.Sum(t => t.Valor);

                var totalSaidas = transacoesMes
                    .Where(t => t.Tipo == "saque")
                    .Sum(t => Math.Abs(t.Valor)) + transferenciasSaida.Sum(t => Math.Abs(t.Valor));

                var saldoLiquido = totalEntradas - totalSaidas;

                // Debug: Log das estatísticas
                Console.WriteLine($"Estatísticas do mês {mesAtual}/{anoAtual}:");
                Console.WriteLine($"- Transações no mês: {transacoesMes.Count}");

                var depositos = transacoesMes.Where(t => t.Tipo == "deposito").ToList();
                var saques = transacoesMes.Where(t => t.Tipo == "saque").ToList();

                Console.WriteLine($"- Depósitos: {depositos.Count} transações, total: {depositos.Sum(t => t.Valor):C}");
                Console.WriteLine($"- Saques: {saques.Count} transações, total: {saques.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"- Transferências de entrada: {transferenciasEntrada.Count} transações, total: {transferenciasEntrada.Sum(t => t.Valor):C}");
                Console.WriteLine($"- Transferências de saída: {transferenciasSaida.Count} transações, total: {transferenciasSaida.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"- Total entradas: {totalEntradas:C}");
                Console.WriteLine($"- Total saídas: {totalSaidas:C}");
                Console.WriteLine($"- Saldo líquido: {saldoLiquido:C}");

                // Atualizar labels
                if (lblTotalEntradas != null)
                    lblTotalEntradas.Text = totalEntradas.ToString("C");

                if (lblTotalSaidas != null)
                    lblTotalSaidas.Text = totalSaidas.ToString("C");

                if (lblSaldoLiquido != null)
                {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar estatísticas: {ex.Message}");
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            try
            {
                var termoBusca = txtBuscar.Text?.ToLower() ?? "";

                // Ignorar o texto placeholder
                if (termoBusca == "🔍 buscar transações...")
                {
                    termoBusca = "";
                }

                var tipoSelecionado = cmbTipoTransacao.SelectedItem?.ToString();

                _transacoesFiltradas = _listaTransacoes.Where(t =>
                {
                    var matchesSearch = string.IsNullOrEmpty(termoBusca) ||
                                       (t.Descricao?.ToLower().Contains(termoBusca) ?? false);

                    var matchesType = tipoSelecionado == "Todas" ||
                                    (tipoSelecionado == "Depósitos" && t.Valor > 0) ||
                                    (tipoSelecionado == "Saques" && t.Tipo == "saque") ||
                                    (tipoSelecionado == "Transferências" && t.Tipo == "transferencia");

                    return matchesSearch && matchesType;
                }).ToList();

                // Debug: Log dos filtros aplicados
                Console.WriteLine($"Filtros aplicados:");
                Console.WriteLine($"- Termo busca: '{termoBusca}'");
                Console.WriteLine($"- Tipo selecionado: '{tipoSelecionado}'");
                Console.WriteLine($"- Transações filtradas: {_transacoesFiltradas.Count} de {_listaTransacoes.Count}");

                AtualizarDataGridView();
                AtualizarContador();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao aplicar filtros: {ex.Message}");
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            try
            {
                Console.WriteLine($"Atualizando DataGridView com {_transacoesFiltradas.Count} transações...");

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

                        // Determinar se é entrada ou saída baseado no tipo e conta
                        var transacaoOriginal = _transacoesFiltradas[row.Index];
                        var isEntrada = false;

                        if (transacaoOriginal.Tipo == "deposito")
                        {
                            isEntrada = true;
                        }
                        else if (transacaoOriginal.Tipo == "transferencia")
                        {
                            // Se tem ContaDestinoId e é uma das minhas contas, é entrada
                            isEntrada = transacaoOriginal.ContaDestinoId.HasValue &&
                                       _listaContas.Any(c => c.Id == transacaoOriginal.ContaDestinoId.Value);
                        }
                        // Saque sempre é saída

                        // Colorir valores
                        if (isEntrada)
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
                                row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(34, 197, 94); // Verde
                                break;
                            case "saque":
                                row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho
                                break;
                            case "transferência":
                                if (isEntrada)
                                {
                                    row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(34, 197, 94); // Verde (recebimento)
                                }
                                else
                                {
                                    row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho (envio)
                                }
                                break;
                        }
                    }
                }

                Console.WriteLine($"DataGridView atualizado com sucesso! {dgvTransacoes.Rows.Count} linhas com cores aplicadas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar DataGridView: {ex.Message}");
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
                case "pix":
                    return "Transferência PIX";
                case "pagamento":
                    return "Pagamento";
                default:
                    return tipo;
            }
        }

        private void RefreshDados()
        {
            try
            {
                Console.WriteLine("Atualizando dados das transações...");
                CarregarContas();
                CarregarTransacoes();
                AtualizarEstatisticas();
                AplicarFiltros();
                Console.WriteLine("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar dados: {ex.Message}");
                MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNovaTransferencia_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se há pelo menos 2 contas para transferir
                if (_listaContas.Count < 2)
                {
                    MessageBox.Show("É necessário ter pelo menos 2 contas para realizar transferências.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Criar formulário simples para transferência
                using (var form = new Form())
                {
                    form.Text = "Nova Transferência";
                    form.Size = new Size(400, 300);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    // Conta de origem
                    var lblOrigem = new Label { Text = "Conta de Origem:", Location = new Point(20, 20), AutoSize = true };
                    var cmbOrigem = new ComboBox
                    {
                        Location = new Point(20, 45),
                        Size = new Size(350, 25),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    // Conta de destino
                    var lblDestino = new Label { Text = "Conta de Destino:", Location = new Point(20, 80), AutoSize = true };
                    var cmbDestino = new ComboBox
                    {
                        Location = new Point(20, 105),
                        Size = new Size(350, 25),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    // Valor
                    var lblValor = new Label { Text = "Valor:", Location = new Point(20, 140), AutoSize = true };
                    var txtValor = new TextBox { Location = new Point(20, 165), Size = new Size(350, 25) };

                    // Botões
                    var btnConfirmar = new Button
                    {
                        Text = "Confirmar",
                        Location = new Point(200, 210),
                        Size = new Size(80, 30),
                        DialogResult = DialogResult.OK
                    };
                    var btnCancelar = new Button
                    {
                        Text = "Cancelar",
                        Location = new Point(290, 210),
                        Size = new Size(80, 30),
                        DialogResult = DialogResult.Cancel
                    };

                    // Preencher combos
                    foreach (var conta in _listaContas)
                    {
                        var texto = $"{conta.NumeroConta} - {conta.Tipo} (Saldo: {conta.Saldo:C})";
                        cmbOrigem.Items.Add(new { Conta = conta, Texto = texto });
                        cmbDestino.Items.Add(new { Conta = conta, Texto = texto });
                    }

                    cmbOrigem.DisplayMember = "Texto";
                    cmbDestino.DisplayMember = "Texto";

                    if (cmbOrigem.Items.Count > 0)
                        cmbOrigem.SelectedIndex = 0;
                    if (cmbDestino.Items.Count > 1)
                        cmbDestino.SelectedIndex = 1;

                    // Adicionar controles
                    form.Controls.AddRange(new Control[] { lblOrigem, cmbOrigem, lblDestino, cmbDestino, lblValor, txtValor, btnConfirmar, btnCancelar });

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Validar seleções
                        if (cmbOrigem.SelectedItem == null || cmbDestino.SelectedItem == null)
                        {
                            MessageBox.Show("Selecione as contas de origem e destino.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor <= 0)
                        {
                            MessageBox.Show("Digite um valor válido maior que zero.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var contaOrigem = ((dynamic)cmbOrigem.SelectedItem).Conta;
                        var contaDestino = ((dynamic)cmbDestino.SelectedItem).Conta;

                        if (contaOrigem.Id == contaDestino.Id)
                        {
                            MessageBox.Show("Conta de origem e destino não podem ser iguais.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Realizar transferência
                        var transacaoId = _transacaoController.RealizarTransferencia(
                            contaOrigem.Id,
                            contaDestino.Id,
                            valor,
                            $"Transferência de {contaOrigem.Tipo} para {contaDestino.Tipo}"
                        );

                        MessageBox.Show($"Transferência realizada com sucesso!\nID da transação: {transacaoId}", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recarregar dados
                        RefreshDados();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar transferência: {ex.Message}", "Erro",
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
