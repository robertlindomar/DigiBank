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
        private readonly Cliente _clienteLogado;
        private readonly TerminalPosController _terminalController;
        private readonly PagamentoPosController _pagamentoController;
        private readonly CartaoController _cartaoController;
        private readonly ContaController _contaController;
        private readonly ClienteController _clienteController;
        private List<DigiBank.models.TerminalPos> _listaTerminais;
        private List<PagamentoPos> _listaPagamentos;
        private List<CartaoNfc> _listaCartoes;
        private List<Conta> _listaContasUsuario;
        private decimal _valorTransacao = 0;
        private bool _processandoPagamento = false;
        #endregion

        #region Construtores
        public TerminalPosForm()
        {
            InitializeComponent();
            _clienteLogado = new Cliente();
            _terminalController = new TerminalPosController();
            _pagamentoController = new PagamentoPosController();
            _cartaoController = new CartaoController();
            _contaController = new ContaController();
            _clienteController = new ClienteController();
            _listaTerminais = new List<DigiBank.models.TerminalPos>();
            _listaPagamentos = new List<PagamentoPos>();
            _listaCartoes = new List<CartaoNfc>();
            _listaContasUsuario = new List<Conta>();
        }

        public TerminalPosForm(Cliente cliente)
        {
            InitializeComponent();
            _clienteLogado = cliente ?? throw new ArgumentNullException(nameof(cliente));
            _terminalController = new TerminalPosController();
            _pagamentoController = new PagamentoPosController();
            _cartaoController = new CartaoController();
            _contaController = new ContaController();
            _clienteController = new ClienteController();
            _listaTerminais = new List<DigiBank.models.TerminalPos>();
            _listaPagamentos = new List<PagamentoPos>();
            _listaCartoes = new List<CartaoNfc>();
            _listaContasUsuario = new List<Conta>();

            // Conectar eventos
            txtUidCartao.KeyPress += txtUidCartao_KeyPress;

            CarregarDados();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDados()
        {
            try
            {
                Console.WriteLine("=== Carregando dados do Terminal POS ===");
                Console.WriteLine($"Cliente logado: {_clienteLogado.Login} (Cliente ID: {_clienteLogado.Id})");

                CarregarContasUsuario();
                CarregarTerminaisUsuario();
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

        private void CarregarContasUsuario()
        {
            _listaContasUsuario.Clear();

            try
            {
                Console.WriteLine("=== CARREGANDO CONTAS DO USUÁRIO ===");

                // Buscar contas do cliente logado
                var contas = _contaController.BuscarPorClienteId(_clienteLogado.Id);
                Console.WriteLine($"Resultado da busca: {contas?.Count ?? 0} contas encontradas");

                if (contas != null && contas.Any())
                {
                    _listaContasUsuario.AddRange(contas);
                    Console.WriteLine($"✅ Contas carregadas: {_listaContasUsuario.Count} contas do usuário");

                    // Mostrar detalhes das contas
                    foreach (var conta in _listaContasUsuario)
                    {
                        Console.WriteLine($"  - Conta: {conta.NumeroConta} ({conta.Tipo}) - Saldo: R$ {conta.Saldo:F2}");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Nenhuma conta encontrada para o usuário logado");
                    MessageBox.Show("Você não possui contas cadastradas. Crie uma conta primeiro.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao carregar contas: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar contas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTerminaisUsuario()
        {
            _listaTerminais.Clear();

            try
            {
                Console.WriteLine("=== CARREGANDO TERMINAIS DO USUÁRIO ===");

                if (!_listaContasUsuario.Any())
                {
                    Console.WriteLine("❌ Usuário não possui contas para buscar terminais");
                    AtualizarInterfaceSemContas();
                    return;
                }

                // Buscar terminais das contas do usuário logado
                var todosTerminais = new List<DigiBank.models.TerminalPos>();

                foreach (var conta in _listaContasUsuario)
                {
                    var terminaisConta = _terminalController.BuscarPorContaId(conta.Id);
                    if (terminaisConta != null && terminaisConta.Any())
                    {
                        todosTerminais.AddRange(terminaisConta);
                    }
                }

                Console.WriteLine($"Resultado da busca: {todosTerminais.Count} terminais encontrados");

                if (todosTerminais.Any())
                {
                    _listaTerminais.AddRange(todosTerminais);
                    Console.WriteLine($"✅ Terminais carregados: {_listaTerminais.Count} terminais do usuário");

                    // Mostrar detalhes dos terminais
                    foreach (var terminal in _listaTerminais)
                    {
                        var conta = _listaContasUsuario.FirstOrDefault(c => c.Id == terminal.ContaId);
                        Console.WriteLine($"  - Terminal: {terminal.Nome} ({terminal.NomeLoja}) - Conta: {conta?.NumeroConta} - Ativo: {terminal.Ativo}");
                    }

                    // Atualizar interface para mostrar instruções normais
                    AtualizarInterfaceComTerminais();
                }
                else
                {
                    Console.WriteLine("❌ Nenhum terminal encontrado para o usuário logado");
                    AtualizarInterfaceSemTerminais();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao carregar terminais: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar terminais: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarPagamentosRecentes()
        {
            _listaPagamentos.Clear();

            try
            {
                Console.WriteLine("=== CARREGANDO PAGAMENTOS RECENTES ===");

                // Buscar pagamentos dos terminais do usuário
                var todosPagamentos = new List<PagamentoPos>();

                if (_listaTerminais.Any())
                {
                    var pagamentos = _pagamentoController.BuscarTodos();
                    if (pagamentos != null && pagamentos.Any())
                    {
                        // Filtrar apenas pagamentos dos terminais do usuário
                        var pagamentosUsuario = pagamentos.Where(p =>
                            p.TerminalId.HasValue &&
                            _listaTerminais.Any(t => t.Id == p.TerminalId.Value)
                        ).ToList();

                        // Pegar os 10 mais recentes
                        var pagamentosRecentes = pagamentosUsuario
                            .OrderByDescending(p => p.DataPagamento)
                            .Take(10)
                            .ToList();

                        _listaPagamentos.AddRange(pagamentosRecentes);
                        Console.WriteLine($"✅ Pagamentos carregados: {_listaPagamentos.Count} pagamentos recentes do usuário");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum terminal encontrado para carregar pagamentos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar pagamentos: {ex.Message}");
                MessageBox.Show($"Erro ao carregar pagamentos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarCartoes()
        {
            _listaCartoes.Clear();

            try
            {
                Console.WriteLine("=== CARREGANDO CARTÕES ===");

                // Buscar TODOS os cartões ativos do banco (de todos os usuários)
                // pois o usuário pode receber pagamentos de qualquer cartão
                var cartoes = _cartaoController.BuscarTodos();
                Console.WriteLine($"Resultado da busca: {cartoes?.Count ?? 0} cartões encontrados");

                if (cartoes != null && cartoes.Any())
                {
                    var cartoesAtivos = cartoes.Where(c => c.Ativo).ToList();
                    _listaCartoes.AddRange(cartoesAtivos);
                    Console.WriteLine($"✅ Cartões carregados: {_listaCartoes.Count} cartões ativos (de todos os usuários)");

                    // Mostrar detalhes dos cartões
                    foreach (var cartao in _listaCartoes)
                    {
                        Console.WriteLine($"  - Cartão: {cartao.Apelido} (UID: {cartao.Uid}) - Ativo: {cartao.Ativo}");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Nenhum cartão ativo encontrado no banco de dados");
                    MessageBox.Show("Nenhum cartão ativo encontrado. Crie cartões primeiro.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao carregar cartões: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar cartões: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Console.WriteLine($"- Total terminais do usuário: {totalTerminais}");
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

            // Verificar se o usuário possui terminais ativos
            if (!_listaTerminais.Any(t => t.Ativo))
            {
                MessageBox.Show("Você não possui terminais ativos. Crie um terminal primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var uid = txtUidCartao?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(uid))
            {
                MessageBox.Show("Informe o UID do cartão (ex: 0066581178)", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar cartão real pelo UID
            var cartaoPeloUid = _cartaoController.BuscarPorUid(uid);
            if (cartaoPeloUid == null || !cartaoPeloUid.Ativo)
            {
                MessageBox.Show("Cartão não encontrado ou inativo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se o cartão não pertence ao próprio usuário (não pode pagar para si mesmo)
            var contaCartao = _contaController.BuscarPorId(cartaoPeloUid.ContaId);
            if (contaCartao != null && _listaContasUsuario.Any(c => c.Id == contaCartao.Id))
            {
                MessageBox.Show("Você não pode fazer pagamentos para sua própria conta.", "Aviso",
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

                // Processar pagamento real no backend
                try
                {
                    var terminalAtivo = _listaTerminais.FirstOrDefault(t => t.Ativo);
                    var cartaoAtivo = cartaoPeloUid;

                    if (terminalAtivo != null && cartaoAtivo != null)
                    {
                        Console.WriteLine($"Processando pagamento: R$ {_valorTransacao:F2}");
                        Console.WriteLine($"Terminal: {terminalAtivo.Nome} (ID: {terminalAtivo.Id})");
                        Console.WriteLine($"Cartão: {cartaoAtivo.Apelido} (ID: {cartaoAtivo.Id}) UID: {cartaoAtivo.Uid}");

                        var pagamentoId = _pagamentoController.ProcessarPagamento(
                            terminalAtivo.Id,
                            cartaoAtivo.Id,
                            _valorTransacao,
                            $"Pagamento via {terminalAtivo.NomeLoja}"
                        );

                        Console.WriteLine($"✅ Pagamento processado com sucesso! ID: {pagamentoId}");

                        // Sucesso
                        AtualizarEstadoPagamento("sucesso");
                        lblValorAprovado.Text = _valorTransacao.ToString("C2");

                        // Recarregar dados
                        CarregarPagamentosRecentes();
                        AtualizarEstatisticas();
                    }
                    else
                    {
                        throw new Exception("Terminal ou cartão ativo não encontrado");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro ao processar pagamento: {ex.Message}");

                    // Erro
                    AtualizarEstadoPagamento("erro");

                    MessageBox.Show($"Pagamento recusado: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Voltar ao estado inicial após 3 segundos
                await Task.Delay(3000);
                AtualizarEstadoPagamento("idle");
                txtValor.Text = "";
                txtUidCartao.Text = "";
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

        private void btnCriarTerminal_Click(object sender, EventArgs e)
        {
            _ = CriarTerminalPadrao();
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
                _ = SimularAproximacaoCartao();
            }
        }

        private void txtUidCartao_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir Enter para simular pagamento
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                _ = SimularAproximacaoCartao();
            }
        }

        private async Task CriarTerminalPadrao()
        {
            try
            {
                if (!_listaContasUsuario.Any())
                {
                    MessageBox.Show("Você precisa ter uma conta antes de criar um terminal.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var contaPadrao = _listaContasUsuario.First();
                var cliente = _clienteController.BuscarPorId(_clienteLogado.Id);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var novoTerminal = new DigiBank.models.TerminalPos
                {
                    Nome = $"Terminal {cliente.Nome}",
                    NomeLoja = cliente.Nome,
                    Localizacao = "Localização Padrão",
                    Uid = $"TERM_{DateTime.Now:yyyyMMddHHmmss}",
                    ContaId = contaPadrao.Id,
                    Ativo = true
                };

                var terminalId = _terminalController.Criar(novoTerminal);
                Console.WriteLine($"✅ Terminal padrão criado com sucesso! ID: {terminalId}");

                // Recarregar dados
                CarregarTerminaisUsuario();
                CarregarPagamentosRecentes();
                AtualizarEstatisticas();

                MessageBox.Show($"Terminal padrão criado com sucesso!\nNome: {novoTerminal.Nome}\nUID: {novoTerminal.Uid}", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao criar terminal padrão: {ex.Message}");
                MessageBox.Show($"Erro ao criar terminal padrão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void AtualizarInterfaceSemContas()
        {
            // Desabilitar campos e botões
            txtValor.Enabled = false;
            txtUidCartao.Enabled = false;
            btnSimularPagamento.Enabled = false;

            // Atualizar instruções
            lblInstrucao.Text = "Você não possui contas cadastradas. Crie uma conta primeiro.";
            lblInstrucao.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho
        }

        private void AtualizarInterfaceSemTerminais()
        {
            // Desabilitar campos e botões
            txtValor.Enabled = false;
            txtUidCartao.Enabled = false;
            btnSimularPagamento.Enabled = false;

            // Atualizar instruções
            lblInstrucao.Text = "Você não possui terminais cadastrados. Clique em 'Criar Terminal' para começar.";
            lblInstrucao.ForeColor = Color.FromArgb(245, 158, 11); // Laranja

            // Mostrar botão para criar terminal (se não existir, será criado dinamicamente)
            MostrarBotaoCriarTerminal();
        }

        private void AtualizarInterfaceComTerminais()
        {
            // Habilitar campos e botões
            txtValor.Enabled = true;
            txtUidCartao.Enabled = true;
            btnSimularPagamento.Enabled = true;

            // Atualizar instruções
            lblInstrucao.Text = "Digite valor e UID do cartão e clique para aproximar";
            lblInstrucao.ForeColor = Color.FromArgb(107, 114, 128); // Cinza original

            // Ocultar botão de criar terminal se existir
            OcultarBotaoCriarTerminal();
        }

        private void MostrarBotaoCriarTerminal()
        {
            // Verificar se o botão já existe
            var btnCriar = panelIdle.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnCriarTerminal");

            if (btnCriar == null)
            {
                // Criar botão dinamicamente
                btnCriar = new Button
                {
                    Name = "btnCriarTerminal",
                    Text = "🚀 Criar Terminal Padrão",
                    BackColor = Color.FromArgb(34, 197, 94), // Verde
                    FlatAppearance = { BorderSize = 0 },
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    Size = new Size(304, 40),
                    Location = new Point(24, 250), // Abaixo do botão de simular pagamento
                    UseVisualStyleBackColor = false
                };

                btnCriar.Click += btnCriarTerminal_Click;
                panelIdle.Controls.Add(btnCriar);
            }

            btnCriar.Visible = true;
        }

        private void OcultarBotaoCriarTerminal()
        {
            var btnCriar = panelIdle.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnCriarTerminal");
            if (btnCriar != null)
            {
                btnCriar.Visible = false;
            }
        }
    }
}
