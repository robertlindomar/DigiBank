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
        private readonly Cliente _clienteLogado;
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
            _clienteLogado = new Cliente();
            _transacaoController = new TransacaoController();
            _contaController = new ContaController();
            _listaTransacoes = new List<Transacao>();
            _listaContas = new List<Conta>();
            _transacoesFiltradas = new List<Transacao>();
        }

        public Transacoes(Cliente cliente)
        {
            InitializeComponent();
            _clienteLogado = cliente ?? throw new ArgumentNullException(nameof(cliente));
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
                Console.WriteLine("=== INICIANDO CARREGAMENTO DE DADOS ===");

                CarregarContas();
                Console.WriteLine($"Contas carregadas: {_listaContas.Count}");

                CarregarTransacoes();
                Console.WriteLine($"Transações carregadas: {_listaTransacoes.Count}");

                ConfigurarDataGridView();
                ConfigurarFiltros();

                Console.WriteLine("Chamando AtualizarEstatisticas...");
                AtualizarEstatisticas();
                Console.WriteLine("AtualizarEstatisticas concluído!");

                // Garantir que as transações filtradas estejam carregadas
                _transacoesFiltradas = new List<Transacao>(_listaTransacoes);

                // Aplicar cores imediatamente
                AtualizarDataGridView();

                Console.WriteLine("=== CARREGAMENTO DE DADOS CONCLUÍDO ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO no CarregarDados: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarContas()
        {
            _listaContas.Clear();
            var contas = _contaController.BuscarPorClienteId(_clienteLogado.Id);

            if (contas != null && contas.Any())
            {
                _listaContas.AddRange(contas);
                Console.WriteLine($"Contas carregadas do banco: {contas.Count}");
            }
            else
            {
                Console.WriteLine("Nenhuma conta encontrada no banco para o usuário.");
                MessageBox.Show("Nenhuma conta encontrada. Entre em contato com o suporte.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    foreach (var transacao in transacoes)
                    {
                        // Para transferências, criar uma cópia específica para cada conta
                        // com o valor correto (negativo para origem, positivo para destino)
                        if (transacao.Tipo == "transferencia")
                        {
                            if (transacao.ContaOrigemId == conta.Id)
                            {
                                // Esta conta é a origem da transferência (SAÍDA)
                                var transacaoSaida = new Transacao
                                {
                                    Id = transacao.Id,
                                    Tipo = transacao.Tipo,
                                    Descricao = transacao.Descricao,
                                    Valor = -Math.Abs(transacao.Valor), // Negativo (saída)
                                    DataTransacao = transacao.DataTransacao,
                                    ContaOrigemId = transacao.ContaOrigemId,
                                    ContaDestinoId = transacao.ContaDestinoId
                                };
                                _listaTransacoes.Add(transacaoSaida);
                            }
                            else if (transacao.ContaDestinoId == conta.Id)
                            {
                                // Esta conta é o destino da transferência (ENTRADA)
                                var transacaoEntrada = new Transacao
                                {
                                    Id = transacao.Id,
                                    Tipo = transacao.Tipo,
                                    Descricao = transacao.Descricao,
                                    Valor = Math.Abs(transacao.Valor), // Positivo (entrada)
                                    DataTransacao = transacao.DataTransacao,
                                    ContaOrigemId = transacao.ContaOrigemId,
                                    ContaDestinoId = transacao.ContaDestinoId
                                };
                                _listaTransacoes.Add(transacaoEntrada);
                            }
                        }
                        else
                        {
                            // Para outras transações (depósitos, saques), adicionar normalmente
                            _listaTransacoes.Add(transacao);
                        }
                    }
                }
            }

            // Debug: Log das transações carregadas
            Console.WriteLine($"Transações carregadas: {_listaTransacoes.Count}");
            foreach (var transacao in _listaTransacoes.Take(5)) // Mostrar apenas as 5 primeiras
            {
                Console.WriteLine($"- Transação {transacao.Id}: {transacao.Tipo} - {transacao.Valor:C} - {transacao.DataTransacao:dd/MM/yyyy}");
            }

            // Verificar se há transações
            if (_listaTransacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação encontrada para o usuário.");
            }

            _transacoesFiltradas = new List<Transacao>(_listaTransacoes);

            Console.WriteLine($"Transações filtradas inicializadas: {_transacoesFiltradas.Count} transações");
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

            // Coluna Extrato (CORRIGIDA: Mostra origem → destino)
            var colExtrato = new DataGridViewTextBoxColumn
            {
                Name = "Extrato",
                HeaderText = "Extrato",
                DataPropertyName = "Extrato",
                Width = 150,
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
                colTipo, colDescricao, colExtrato, colData, colValor, colStatus
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
            // Configurar ComboBox de tipo de conta
            cmbTipoConta.Items.Clear();
            cmbTipoConta.Items.AddRange(new object[]
            {
                "Todas as Contas",
                "Conta Corrente",
                "Conta Poupança"
            });
            cmbTipoConta.SelectedIndex = 0;

            // Configurar ComboBox de tipo de transação
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
            cmbTipoConta.SelectedIndexChanged += CmbTipoConta_SelectedIndexChanged;
        }

        private void AtualizarEstatisticas()
        {
            try
            {
                var mesAtual = DateTime.Now.Month;
                var anoAtual = DateTime.Now.Year;

                Console.WriteLine($"=== ATUALIZANDO ESTATÍSTICAS ===");
                Console.WriteLine($"Mês atual: {mesAtual}, Ano atual: {anoAtual}");
                Console.WriteLine($"Total de transações na lista: {_listaTransacoes.Count}");
                Console.WriteLine($"Total de contas na lista: {_listaContas.Count}");

                // Mostrar algumas transações para debug
                if (_listaTransacoes.Count > 0)
                {
                    Console.WriteLine("Primeiras 3 transações:");
                    foreach (var t in _listaTransacoes.Take(3))
                    {
                        Console.WriteLine($"  - {t.Tipo}: {t.Valor:C} em {t.DataTransacao:dd/MM/yyyy}");
                    }
                }

                var transacoesMes = _listaTransacoes
                    .Where(t => t.DataTransacao.Month == mesAtual && t.DataTransacao.Year == anoAtual)
                    .ToList();

                Console.WriteLine($"Transações do mês atual ({mesAtual}/{anoAtual}): {transacoesMes.Count}");

                // Separar transferências de entrada e saída baseado no valor
                // Agora as transferências já têm valores corretos: negativos para saídas, positivos para entradas
                var transferenciasEntrada = transacoesMes
                    .Where(t => t.Tipo == "transferencia" && t.Valor > 0)
                    .ToList();

                var transferenciasSaida = transacoesMes
                    .Where(t => t.Tipo == "transferencia" && t.Valor < 0)
                    .ToList();

                // Para transferências entre contas do mesmo usuário, agora aparecem duas vezes
                // Uma vez como saída da conta de origem (valor negativo) e outra como entrada na conta de destino (valor positivo)
                // Isso é correto pois cada conta tem seu próprio extrato
                var transferenciasInternas = transacoesMes
                    .Where(t => t.Tipo == "transferencia" &&
                               t.ContaOrigemId.HasValue && t.ContaDestinoId.HasValue &&
                               _listaContas.Any(c => c.Id == t.ContaOrigemId.Value) &&
                               _listaContas.Any(c => c.Id == t.ContaDestinoId.Value))
                    .ToList();

                Console.WriteLine($"Transferências de entrada: {transferenciasEntrada.Count}");
                Console.WriteLine($"Transferências de saída: {transferenciasSaida.Count}");
                Console.WriteLine($"Transferências internas: {transferenciasInternas.Count}");

                // Para debug, mostrar detalhes das transferências
                if (transferenciasEntrada.Count > 0)
                {
                    Console.WriteLine("Transferências de entrada:");
                    foreach (var t in transferenciasEntrada.Take(3))
                    {
                        Console.WriteLine($"  - {t.Valor:C} para conta {t.ContaDestinoId}");
                    }
                }

                if (transferenciasSaida.Count > 0)
                {
                    Console.WriteLine("Transferências de saída:");
                    foreach (var t in transferenciasSaida.Take(3))
                    {
                        Console.WriteLine($"  - {t.Valor:C} da conta {t.ContaOrigemId}");
                    }
                }

                var depositos = transacoesMes.Where(t => t.Tipo == "deposito").ToList();
                var saques = transacoesMes.Where(t => t.Tipo == "saque").ToList();

                // Para transferências, usar os valores já corrigidos (positivos para entradas, negativos para saídas)
                var totalEntradas = depositos.Sum(t => Math.Abs(t.Valor)) + transferenciasEntrada.Sum(t => Math.Abs(t.Valor));
                var totalSaidas = saques.Sum(t => Math.Abs(t.Valor)) + transferenciasSaida.Sum(t => Math.Abs(t.Valor));

                // Garantir que os valores sejam positivos para o cálculo
                totalEntradas = Math.Max(0, totalEntradas);
                totalSaidas = Math.Max(0, totalSaidas);

                Console.WriteLine($"Depósitos: {depositos.Count} transações, total: {depositos.Sum(t => t.Valor):C}");
                Console.WriteLine($"Transferências de entrada: {transferenciasEntrada.Count} transações, total: {transferenciasEntrada.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"Saques: {saques.Count} transações, total: {saques.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"Transferências de saída: {transferenciasSaida.Count} transações, total: {transferenciasSaida.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"Total entradas calculado: {totalEntradas:C}");
                Console.WriteLine($"Total saídas calculado: {totalSaidas:C}");

                var saldoLiquido = totalEntradas - totalSaidas;

                // Debug: Log das estatísticas
                Console.WriteLine($"Estatísticas do mês {mesAtual}/{anoAtual}:");
                Console.WriteLine($"- Transações no mês: {transacoesMes.Count}");

                Console.WriteLine($"- Depósitos: {depositos.Count} transações, total: {depositos.Sum(t => t.Valor):C}");
                Console.WriteLine($"- Saques: {saques.Count} transações, total: {saques.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"- Transferências de entrada: {transferenciasEntrada.Count} transações, total: {transferenciasEntrada.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"- Transferências de saída: {transferenciasSaida.Count} transações, total: {transferenciasSaida.Sum(t => Math.Abs(t.Valor)):C}");
                Console.WriteLine($"- Total entradas: {totalEntradas:C}");
                Console.WriteLine($"- Total saídas: {totalSaidas:C}");
                Console.WriteLine($"- Saldo líquido: {saldoLiquido:C}");

                // Atualizar labels
                Console.WriteLine("Atualizando labels das estatísticas...");

                if (lblTotalEntradas != null)
                {
                    lblTotalEntradas.Text = totalEntradas.ToString("C");
                    Console.WriteLine($"Label Total Entradas atualizado: {totalEntradas:C}");
                }
                else
                {
                    Console.WriteLine("ERRO: lblTotalEntradas é null!");
                }

                if (lblTotalSaidas != null)
                {
                    lblTotalSaidas.Text = totalSaidas.ToString("C");
                    Console.WriteLine($"Label Total Saídas atualizado: {totalSaidas:C}");
                }
                else
                {
                    Console.WriteLine("ERRO: lblTotalSaidas é null!");
                }

                if (lblSaldoLiquido != null)
                {
                    lblSaldoLiquido.Text = saldoLiquido.ToString("C");
                    Console.WriteLine($"Label Saldo Líquido atualizado: {saldoLiquido:C}");

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
                else
                {
                    Console.WriteLine("ERRO: lblSaldoLiquido é null!");
                }

                Console.WriteLine("=== ESTATÍSTICAS ATUALIZADAS COM SUCESSO ===");
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
                var tipoContaSelecionado = cmbTipoConta.SelectedItem?.ToString();

                Console.WriteLine($"=== APLICANDO FILTROS ===");
                Console.WriteLine($"Termo busca: '{termoBusca}'");
                Console.WriteLine($"Tipo transação: '{tipoSelecionado}'");
                Console.WriteLine($"Tipo conta: '{tipoContaSelecionado}'");
                Console.WriteLine($"Total transações antes do filtro: {_listaTransacoes.Count}");

                // Aplicar filtros
                _transacoesFiltradas = _listaTransacoes.Where(t =>
                {
                    // Filtro por termo de busca
                    var matchesSearch = string.IsNullOrEmpty(termoBusca) ||
                                       (t.Descricao?.ToLower().Contains(termoBusca) ?? false);

                    // Filtro por tipo de transação
                    var matchesType = tipoSelecionado == "Todas" ||
                                    (tipoSelecionado == "Depósitos" && t.Tipo == "deposito") ||
                                    (tipoSelecionado == "Saques" && t.Tipo == "saque") ||
                                    (tipoSelecionado == "Transferências" && t.Tipo == "transferencia");

                    // Filtro por tipo de conta
                    var matchesConta = true; // Padrão: mostrar todas

                    if (tipoContaSelecionado != "Todas as Contas")
                    {
                        if (t.Tipo == "transferencia")
                        {
                            // Para transferências, verificar se a conta selecionada está envolvida
                            var contaOrigem = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                            var contaDestino = _listaContas.FirstOrDefault(c => c.Id == t.ContaDestinoId);

                            if (tipoContaSelecionado == "Conta Corrente")
                            {
                                matchesConta = (contaOrigem?.Tipo == "corrente" || contaDestino?.Tipo == "corrente");
                            }
                            else if (tipoContaSelecionado == "Conta Poupança")
                            {
                                matchesConta = (contaOrigem?.Tipo == "poupanca" || contaDestino?.Tipo == "poupanca");
                            }
                        }
                        else
                        {
                            // Para outras transações, verificar a conta de origem
                            var conta = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                            if (conta != null)
                            {
                                if (tipoContaSelecionado == "Conta Corrente")
                                {
                                    matchesConta = (conta.Tipo == "corrente");
                                }
                                else if (tipoContaSelecionado == "Conta Poupança")
                                {
                                    matchesConta = (conta.Tipo == "poupanca");
                                }
                            }
                        }
                    }

                    return matchesSearch && matchesType && matchesConta;
                }).ToList();

                // CORREÇÃO: Se filtrar por tipo de conta específico, remover duplicatas de transferências
                // E ajustar os valores para mostrar a perspectiva correta da conta selecionada
                if (tipoContaSelecionado != "Todas as Contas")
                {
                    Console.WriteLine("Filtro específico ativo - removendo duplicatas e ajustando valores...");

                    // Para cada transferência, determinar qual transação mostrar baseado no filtro
                    var transferenciasFiltradas = new List<Transacao>();

                    // Agrupar transferências por ID
                    var gruposTransferencias = _transacoesFiltradas
                        .Where(t => t.Tipo == "transferencia")
                        .GroupBy(t => t.Id);

                    foreach (var grupo in gruposTransferencias)
                    {
                        var transacoes = grupo.ToList();

                        // Encontrar a transação que corresponde à conta selecionada
                        Transacao transacaoParaMostrar = null;

                        if (tipoContaSelecionado == "Conta Corrente")
                        {
                            // Procurar transação da conta corrente
                            transacaoParaMostrar = transacoes.FirstOrDefault(t =>
                            {
                                var contaOrigem = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                                var contaDestino = _listaContas.FirstOrDefault(c => c.Id == t.ContaDestinoId);
                                return (contaOrigem?.Tipo == "corrente" || contaDestino?.Tipo == "corrente");
                            });
                        }
                        else if (tipoContaSelecionado == "Conta Poupança")
                        {
                            // Procurar transação da conta poupança
                            transacaoParaMostrar = transacoes.FirstOrDefault(t =>
                            {
                                var contaOrigem = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                                var contaDestino = _listaContas.FirstOrDefault(c => c.Id == t.ContaDestinoId);
                                return (contaOrigem?.Tipo == "poupanca" || contaDestino?.Tipo == "poupanca");
                            });
                        }

                        if (transacaoParaMostrar != null)
                        {
                            // Ajustar o valor baseado na perspectiva da conta selecionada
                            var contaOrigem = _listaContas.FirstOrDefault(c => c.Id == transacaoParaMostrar.ContaOrigemId);
                            var contaDestino = _listaContas.FirstOrDefault(c => c.Id == transacaoParaMostrar.ContaDestinoId);

                            if (tipoContaSelecionado == "Conta Corrente")
                            {
                                if (contaOrigem?.Tipo == "corrente")
                                {
                                    // Conta corrente é origem (SAÍDA) - valor negativo
                                    transacaoParaMostrar.Valor = -Math.Abs(transacaoParaMostrar.Valor);
                                }
                                else if (contaDestino?.Tipo == "corrente")
                                {
                                    // Conta corrente é destino (ENTRADA) - valor positivo
                                    transacaoParaMostrar.Valor = Math.Abs(transacaoParaMostrar.Valor);
                                }
                            }
                            else if (tipoContaSelecionado == "Conta Poupança")
                            {
                                if (contaOrigem?.Tipo == "poupanca")
                                {
                                    // Conta poupança é origem (SAÍDA) - valor negativo
                                    transacaoParaMostrar.Valor = -Math.Abs(transacaoParaMostrar.Valor);
                                }
                                else if (contaDestino?.Tipo == "poupanca")
                                {
                                    // Conta poupança é destino (ENTRADA) - valor positivo
                                    transacaoParaMostrar.Valor = Math.Abs(transacaoParaMostrar.Valor);
                                }
                            }

                            transferenciasFiltradas.Add(transacaoParaMostrar);
                        }
                    }

                    // Adicionar outras transações (não transferências)
                    var outrasTransacoes = _transacoesFiltradas.Where(t => t.Tipo != "transferencia").ToList();
                    transferenciasFiltradas.AddRange(outrasTransacoes);

                    _transacoesFiltradas = transferenciasFiltradas;

                    Console.WriteLine($"Após ajuste de valores: {_transacoesFiltradas.Count} transações");
                }

                // Debug: Log dos filtros aplicados
                Console.WriteLine($"=== RESULTADO DOS FILTROS ===");
                Console.WriteLine($"Transações filtradas: {_transacoesFiltradas.Count} de {_listaTransacoes.Count}");

                if (_transacoesFiltradas.Count > 0)
                {
                    Console.WriteLine("Primeiras 3 transações filtradas:");
                    foreach (var t in _transacoesFiltradas.Take(3))
                    {
                        Console.WriteLine($"  - {t.Tipo}: {t.Valor:C} - {t.Descricao}");
                    }
                }

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
                    string descricao = t.Descricao;
                    string extrato = "N/A";

                    if (t.Tipo == "transferencia")
                    {
                        var contaOrigem = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                        var contaDestino = _listaContas.FirstOrDefault(c => c.Id == t.ContaDestinoId);

                        if (contaOrigem != null && contaDestino != null)
                        {
                            var tipoOrigem = contaOrigem.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança";
                            var tipoDestino = contaDestino.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança";

                            // Determinar se esta transação é vista da perspectiva da conta de origem ou destino
                            if (t.Valor < 0)
                            {
                                // Esta é a conta de origem (SAÍDA) - valor negativo
                                descricao = $"Transferência para {tipoDestino}";
                                extrato = $"{tipoOrigem} → {tipoDestino}";
                            }
                            else
                            {
                                // Esta é a conta de destino (ENTRADA) - valor positivo
                                descricao = $"Transferência de {tipoOrigem}";
                                extrato = $"{tipoOrigem} → {tipoDestino}";
                            }
                        }
                    }
                    else
                    {
                        // Para outras transações (depósitos, saques)
                        var conta = _listaContas.FirstOrDefault(c => c.Id == t.ContaOrigemId);
                        if (conta != null)
                        {
                            extrato = conta.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança";
                        }
                    }

                    return new
                    {
                        Tipo = ObterNomeTipoTransacao(t.Tipo),
                        Descricao = descricao,
                        Extrato = extrato,
                        DataTransacao = t.DataTransacao,
                        Valor = t.Valor, // Usar o valor já corrigido da transação
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

                        // Determinar se é entrada ou saída baseado no valor (positivo = entrada, negativo = saída)
                        var isEntrada = valor >= 0;

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
                AplicarFiltros(); // Aplicar filtros após recarregar dados
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

        private void CmbTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"=== EVENTO FILTRO CONTA DISPARADO ===");
            Console.WriteLine($"Item selecionado: {cmbTipoConta.SelectedItem}");
            Console.WriteLine($"Índice selecionado: {cmbTipoConta.SelectedIndex}");

            // Teste: verificar se o filtro está funcionando
            var tipoContaSelecionado = cmbTipoConta.SelectedItem?.ToString();
            Console.WriteLine($"Tipo de conta selecionado: '{tipoContaSelecionado}'");

            if (tipoContaSelecionado == "Conta Corrente")
            {
                Console.WriteLine("Filtrando por Conta Corrente...");
            }
            else if (tipoContaSelecionado == "Conta Poupança")
            {
                Console.WriteLine("Filtrando por Conta Poupança...");
            }
            else
            {
                Console.WriteLine("Mostrando todas as contas...");
            }

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
