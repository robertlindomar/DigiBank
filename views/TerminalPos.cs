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
    public partial class TerminalPosForm : Form
    {
        #region Campos Privados
        private readonly Usuario _usuarioLogado;
        private readonly TerminalPosController _terminalController;
        private readonly PagamentoPosController _pagamentoController;
        private readonly CartaoController _cartaoController;
        private List<DigiBank.models.TerminalPos> _listaTerminais;
        private List<PagamentoPos> _listaPagamentos;
        private List<CartaoNfc> _listaCartoes;
        private decimal _valorTransacao = 0;
        private bool _processandoPagamento = false;
        #endregion

        #region Construtores
        public TerminalPosForm()
        {
            InitializeComponent();
            _usuarioLogado = new Usuario();
            _terminalController = new TerminalPosController();
            _pagamentoController = new PagamentoPosController();
            _cartaoController = new CartaoController();
            _listaTerminais = new List<DigiBank.models.TerminalPos>();
            _listaPagamentos = new List<PagamentoPos>();
            _listaCartoes = new List<CartaoNfc>();
        }

        public TerminalPosForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogado = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _terminalController = new TerminalPosController();
            _pagamentoController = new PagamentoPosController();
            _cartaoController = new CartaoController();
            _listaTerminais = new List<DigiBank.models.TerminalPos>();
            _listaPagamentos = new List<PagamentoPos>();
            _listaCartoes = new List<CartaoNfc>();

            CarregarDados();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDados()
        {
            try
            {
                Console.WriteLine("=== Carregando dados do Terminal POS ===");
                CarregarTerminais();
                CarregarPagamentosRecentes();
                CarregarCartoes();
                ConfigurarDataGridView();
                AtualizarEstatisticas();
                Console.WriteLine("=== Dados do Terminal POS carregados com sucesso ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTerminais()
        {
            _listaTerminais.Clear();

            try
            {
                // Buscar terminais do banco
                var terminais = _terminalController.BuscarTodos();
                if (terminais != null && terminais.Any())
                {
                    _listaTerminais.AddRange(terminais);
                    Console.WriteLine($"Terminais carregados: {_listaTerminais.Count} terminais");
                }
                else
                {
                    Console.WriteLine("Nenhum terminal encontrado, criando exemplos...");
                    CriarTerminaisExemplo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar terminais: {ex.Message}");
                CriarTerminaisExemplo();
            }
        }

        private void CriarTerminaisExemplo()
        {
            var terminaisExemplo = new List<DigiBank.models.TerminalPos>
            {
                new DigiBank.models.TerminalPos
                {
                    Id = 1,
                    Nome = "Terminal Principal",
                    Localizacao = "Loja Centro",
                    Uid = "POS001",
                    Ativo = true
                },
                new DigiBank.models.TerminalPos
                {
                    Id = 2,
                    Nome = "Terminal Backup",
                    Localizacao = "Loja Shopping",
                    Uid = "POS002",
                    Ativo = false
                }
            };

            _listaTerminais.AddRange(terminaisExemplo);
        }

        private void CarregarPagamentosRecentes()
        {
            _listaPagamentos.Clear();

            try
            {
                // Buscar pagamentos do banco e pegar os mais recentes
                var pagamentos = _pagamentoController.BuscarTodos();
                if (pagamentos != null && pagamentos.Any())
                {
                    // Pegar os 10 mais recentes
                    var pagamentosRecentes = pagamentos
                        .OrderByDescending(p => p.DataPagamento)
                        .Take(10)
                        .ToList();

                    _listaPagamentos.AddRange(pagamentosRecentes);
                    Console.WriteLine($"Pagamentos carregados: {_listaPagamentos.Count} pagamentos recentes");
                }
                else
                {
                    Console.WriteLine("Nenhum pagamento encontrado, criando exemplos...");
                    CriarPagamentosExemplo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar pagamentos: {ex.Message}");
                CriarPagamentosExemplo();
            }
        }

        private void CriarPagamentosExemplo()
        {
            var pagamentosExemplo = new List<PagamentoPos>
            {
                new PagamentoPos
                {
                    Id = 1,
                    Valor = 45.90m,
                    CartaoId = 1,
                    TerminalId = 1,
                    Status = "aprovado",
                    DataPagamento = DateTime.Parse("2024-01-15 14:30")
                },
                new PagamentoPos
                {
                    Id = 2,
                    Valor = 120.50m,
                    CartaoId = 3,
                    TerminalId = 1,
                    Status = "aprovado",
                    DataPagamento = DateTime.Parse("2024-01-15 12:15")
                },
                new PagamentoPos
                {
                    Id = 3,
                    Valor = 25.00m,
                    CartaoId = 1,
                    TerminalId = 1,
                    Status = "recusado",
                    DataPagamento = DateTime.Parse("2024-01-15 10:45")
                },
                new PagamentoPos
                {
                    Id = 4,
                    Valor = 78.30m,
                    CartaoId = 2,
                    TerminalId = 1,
                    Status = "pin_incorreto",
                    DataPagamento = DateTime.Parse("2024-01-14 16:20")
                }
            };

            _listaPagamentos.AddRange(pagamentosExemplo);
        }

        private void CarregarCartoes()
        {
            _listaCartoes.Clear();

            try
            {
                // Buscar TODOS os cartões ativos do banco (de todos os usuários)
                var cartoes = _cartaoController.BuscarTodos();
                if (cartoes != null && cartoes.Any())
                {
                    var cartoesAtivos = cartoes.Where(c => c.Ativo).ToList();
                    _listaCartoes.AddRange(cartoesAtivos);
                    Console.WriteLine($"Cartões carregados: {_listaCartoes.Count} cartões ativos (de todos os usuários)");
                }
                else
                {
                    Console.WriteLine("Nenhum cartão ativo encontrado, criando exemplos...");
                    var cartoesExemplo = new List<CartaoNfc>
                    {
                        new CartaoNfc { Id = 1, Apelido = "Cartão João", Uid = "A1B2C3D4E5F6", Ativo = true, ContaId = 1 },
                        new CartaoNfc { Id = 2, Apelido = "Cartão Maria", Uid = "G7H8I9J0K1L2", Ativo = true, ContaId = 2 },
                        new CartaoNfc { Id = 3, Apelido = "Cartão Pedro", Uid = "M3N4O5P6Q7R8", Ativo = true, ContaId = 3 }
                    };
                    _listaCartoes.AddRange(cartoesExemplo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar cartões: {ex.Message}");
                var cartoesExemplo = new List<CartaoNfc>
                {
                    new CartaoNfc { Id = 1, Apelido = "Cartão João", Uid = "A1B2C3D4E5F6", Ativo = true, ContaId = 1 },
                    new CartaoNfc { Id = 2, Apelido = "Cartão Maria", Uid = "G7H8I9J0K1L2", Ativo = true, ContaId = 2 },
                    new CartaoNfc { Id = 3, Apelido = "Cartão Pedro", Uid = "M3N4O5P6Q7R8", Ativo = true, ContaId = 3 }
                };
                _listaCartoes.AddRange(cartoesExemplo);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvPagamentos.AutoGenerateColumns = false;
            dgvPagamentos.AllowUserToAddRows = false;
            dgvPagamentos.AllowUserToDeleteRows = false;
            dgvPagamentos.ReadOnly = true;
            dgvPagamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagamentos.RowHeadersVisible = false;
            dgvPagamentos.BackgroundColor = Color.White;
            dgvPagamentos.BorderStyle = BorderStyle.None;
            dgvPagamentos.GridColor = Color.FromArgb(229, 231, 235);

            // Configurar colunas
            dgvPagamentos.Columns.Clear();

            // Coluna Valor
            var colValor = new DataGridViewTextBoxColumn
            {
                Name = "Valor",
                HeaderText = "Valor",
                DataPropertyName = "Valor",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Format = "C2"
                }
            };

            // Coluna Cartão
            var colCartao = new DataGridViewTextBoxColumn
            {
                Name = "Cartao",
                HeaderText = "Cartão",
                DataPropertyName = "Cartao",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(107, 114, 128)
                }
            };

            // Coluna Terminal
            var colTerminal = new DataGridViewTextBoxColumn
            {
                Name = "Terminal",
                HeaderText = "Terminal",
                DataPropertyName = "Terminal",
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
                HeaderText = "Data/Hora",
                DataPropertyName = "Data",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Format = "dd/MM HH:mm"
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
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvPagamentos.Columns.AddRange(new DataGridViewColumn[]
            {
                colValor, colCartao, colTerminal, colData, colStatus
            });

            // Configurar estilo do cabeçalho
            dgvPagamentos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvPagamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            dgvPagamentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvPagamentos.ColumnHeadersHeight = 40;
            dgvPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void AtualizarEstatisticas()
        {
            try
            {
                var totalTerminais = _listaTerminais.Count;
                var terminaisAtivos = _listaTerminais.Count(t => t.Ativo);
                var totalPagamentos = _listaPagamentos.Count;
                var pagamentosAprovados = _listaPagamentos.Count(p => p.Status == "aprovado");

                Console.WriteLine($"Estatísticas do Terminal POS:");
                Console.WriteLine($"- Total terminais: {totalTerminais}");
                Console.WriteLine($"- Terminais ativos: {terminaisAtivos}");
                Console.WriteLine($"- Total pagamentos: {totalPagamentos}");
                Console.WriteLine($"- Pagamentos aprovados: {pagamentosAprovados}");

                // Atualizar labels
                lblTotalTerminais.Text = totalTerminais.ToString();
                lblTerminaisAtivos.Text = terminaisAtivos.ToString();
                lblTotalPagamentos.Text = totalPagamentos.ToString();
                lblPagamentosAprovados.Text = pagamentosAprovados.ToString();

                // Atualizar DataGridView
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar estatísticas: {ex.Message}");
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            try
            {
                Console.WriteLine($"Atualizando DataGridView com {_listaPagamentos.Count} pagamentos...");

                // Criar lista de objetos anônimos para o DataGridView
                var dadosParaGrid = _listaPagamentos.Select(p =>
                {
                    var cartao = _listaCartoes.FirstOrDefault(c => c.Id == p.CartaoId.GetValueOrDefault());
                    var terminal = _listaTerminais.FirstOrDefault(t => t.Id == p.TerminalId.GetValueOrDefault());

                    return new
                    {
                        Valor = p.Valor,
                        Cartao = cartao?.Apelido ?? "Cartão Desconhecido",
                        Terminal = terminal?.Nome ?? "Terminal Desconhecido",
                        Data = p.DataPagamento,
                        Status = ObterTextoStatus(p.Status)
                    };
                }).ToList();

                dgvPagamentos.DataSource = dadosParaGrid;

                // Aplicar formatação de cores
                foreach (DataGridViewRow row in dgvPagamentos.Rows)
                {
                    if (row.DataBoundItem != null)
                    {
                        var status = row.Cells["Status"].Value?.ToString();

                        // Colorir status
                        if (status == "Aprovado")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(22, 163, 74);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(220, 252, 231);
                        }
                        else if (status == "Recusado")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(239, 68, 68);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(254, 242, 242);
                        }
                        else if (status == "PIN Incorreto")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(245, 158, 11);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(255, 251, 235);
                        }
                        else
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(107, 114, 128);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(243, 244, 246);
                        }
                    }
                }

                Console.WriteLine($"DataGridView atualizado com sucesso! {dgvPagamentos.Rows.Count} linhas com cores aplicadas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar DataGridView: {ex.Message}");
                MessageBox.Show($"Erro ao atualizar DataGridView: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterTextoStatus(string status)
        {
            switch (status?.ToLower())
            {
                case "aprovado":
                    return "Aprovado";
                case "recusado":
                    return "Recusado";
                case "pin_incorreto":
                    return "PIN Incorreto";
                case "saldo_insuficiente":
                    return "Sem Saldo";
                default:
                    return "Pendente";
            }
        }

        private void AtualizarEstadoPagamento(string estado)
        {
            // Ocultar todos os painéis
            panelIdle.Visible = false;
            panelProcessando.Visible = false;
            panelSucesso.Visible = false;
            panelErro.Visible = false;

            // Mostrar o painel correto
            switch (estado.ToLower())
            {
                case "idle":
                    panelIdle.Visible = true;
                    break;
                case "processando":
                    panelProcessando.Visible = true;
                    break;
                case "sucesso":
                    panelSucesso.Visible = true;
                    break;
                case "erro":
                    panelErro.Visible = true;
                    break;
            }
        }

        private async Task SimularPagamento()
        {
            if (_processandoPagamento)
                return;

            if (_valorTransacao <= 0)
            {
                MessageBox.Show("Por favor, digite um valor válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _processandoPagamento = true;
            btnSimularPagamento.Enabled = false;

            try
            {
                // Mostrar estado de processamento
                AtualizarEstadoPagamento("processando");

                // Simular processamento (2 segundos)
                await Task.Delay(2000);

                // Simular resultado (80% de chance de sucesso)
                var sucesso = new Random().Next(1, 101) <= 80;

                if (sucesso)
                {
                    // Sucesso
                    AtualizarEstadoPagamento("sucesso");
                    lblValorAprovado.Text = _valorTransacao.ToString("C2");

                    // Processar pagamento no backend
                    try
                    {
                        var terminalAtivo = _listaTerminais.FirstOrDefault(t => t.Ativo);
                        var cartaoAtivo = _listaCartoes.FirstOrDefault(c => c.Ativo);

                        if (terminalAtivo != null && cartaoAtivo != null)
                        {
                            var pagamentoId = _pagamentoController.ProcessarPagamento(
                                terminalAtivo.Id,
                                cartaoAtivo.Id,
                                _valorTransacao,
                                $"Pagamento via Terminal {terminalAtivo.Nome}"
                            );

                            Console.WriteLine($"Pagamento processado com sucesso! ID: {pagamentoId}");

                            // Recarregar pagamentos recentes
                            CarregarPagamentosRecentes();
                            AtualizarEstatisticas();
                        }
                        else
                        {
                            Console.WriteLine("Terminal ou cartão ativo não encontrado");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar pagamento no backend: {ex.Message}");
                    }
                }
                else
                {
                    // Erro
                    AtualizarEstadoPagamento("erro");
                }

                // Voltar ao estado inicial após 3 segundos
                await Task.Delay(3000);
                AtualizarEstadoPagamento("idle");
                txtValor.Text = "";
                _valorTransacao = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar pagamento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AtualizarEstadoPagamento("erro");
            }
            finally
            {
                _processandoPagamento = false;
                btnSimularPagamento.Enabled = true;
            }
        }

        private async Task SimularAproximacaoCartao()
        {
            if (_processandoPagamento)
                return;

            if (_valorTransacao <= 0)
            {
                MessageBox.Show("Por favor, digite um valor válido primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _processandoPagamento = true;
            btnSimularPagamento.Enabled = false;

            try
            {
                // Mostrar estado de processamento
                AtualizarEstadoPagamento("processando");

                // Simular processamento (2 segundos)
                await Task.Delay(2000);

                // Simular resultado (80% de chance de sucesso)
                var sucesso = new Random().Next(1, 101) <= 80;

                if (sucesso)
                {
                    // Sucesso
                    AtualizarEstadoPagamento("sucesso");
                    lblValorAprovado.Text = _valorTransacao.ToString("C2");

                    // Processar pagamento no backend
                    try
                    {
                        var terminalAtivo = _listaTerminais.FirstOrDefault(t => t.Ativo);
                        var cartaoAtivo = _listaCartoes.FirstOrDefault(c => c.Ativo);

                        if (terminalAtivo != null && cartaoAtivo != null)
                        {
                            var pagamentoId = _pagamentoController.ProcessarPagamento(
                                terminalAtivo.Id,
                                cartaoAtivo.Id,
                                _valorTransacao,
                                $"Pagamento via Terminal {terminalAtivo.Nome}"
                            );

                            Console.WriteLine($"Pagamento processado com sucesso! ID: {pagamentoId}");

                            // Recarregar pagamentos recentes
                            CarregarPagamentosRecentes();
                            AtualizarEstatisticas();
                        }
                        else
                        {
                            Console.WriteLine("Terminal ou cartão ativo não encontrado");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar pagamento no backend: {ex.Message}");
                    }
                }
                else
                {
                    // Erro
                    AtualizarEstadoPagamento("erro");
                }

                // Voltar ao estado inicial após 3 segundos
                await Task.Delay(3000);
                AtualizarEstadoPagamento("idle");
                txtValor.Text = "";
                _valorTransacao = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar pagamento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AtualizarEstadoPagamento("erro");
            }
            finally
            {
                _processandoPagamento = false;
                btnSimularPagamento.Enabled = true;
            }
        }
        #endregion

        #region Event Handlers
        private void TerminalPosForm_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário
        }

        private void btnSimularPagamento_Click(object sender, EventArgs e)
        {
            _ = SimularAproximacaoCartao();
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você não tem novas notificações!", "Notificações",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal valor))
            {
                _valorTransacao = valor;
            }
            else
            {
                _valorTransacao = 0;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, vírgula, ponto e teclas de controle
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir Enter para simular pagamento
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                _ = SimularPagamento();
            }
        }
        #endregion
    }
}
