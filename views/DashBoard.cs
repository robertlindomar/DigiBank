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
        private readonly Cliente _clienteLogado;
        private readonly List<Conta> _listaContas;
        private readonly ContaController _contaController;
        private readonly TransacaoController _transacaoController;
        private readonly CartaoController _cartaoController;
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
            _clienteLogado = new Cliente();
            _listaContas = new List<Conta>();
            _contaController = new ContaController();
            _transacaoController = new TransacaoController();
            _cartaoController = new CartaoController();
        }

        public DashBoard(Cliente cliente)
        {
            InitializeComponent();
            _clienteLogado = cliente;
            _listaContas = new List<Conta>();
            _contaController = new ContaController();
            _transacaoController = new TransacaoController();
            _cartaoController = new CartaoController();

            CarregarDadosUsuario();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDadosUsuario()
        {
            try
            {
                Console.WriteLine("=== INICIANDO CARREGAMENTO DE DADOS ===");

                AtualizarLabelBemVindo();
                CarregarContas();
                ConfigurarInterface(); // Define _contaAtual
                ExibirSaldoInicial();

                // Carregar transações da conta inicial (sem duplicação)
                if (_contaAtual != null)
                {
                    Console.WriteLine($"Carregando transações da conta inicial: {_contaAtual.Tipo}");
                    CarregarTransacoesRecentes(_contaAtual.Tipo);
                }
                else
                {
                    Console.WriteLine("Nenhuma conta inicial definida, carregando todas as transações");
                    CarregarTransacoesRecentes(); // Sem parâmetro = todas as contas
                }

                AtualizarEstatisticas();

                Console.WriteLine("=== CARREGAMENTO DE DADOS CONCLUÍDO ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO no CarregarDadosUsuario: {ex.Message}");
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarLabelBemVindo()
        {
            if (lblSubtitulo != null)
            {
                lblSubtitulo.Text = $"Bem-vindo de volta, {_clienteLogado.Login}!";
            }
        }

        private void CarregarContas()
        {
            _listaContas.Clear();
            var contas = _contaController.BuscarPorClienteId(_clienteLogado.Id);

            if (contas != null)
            {
                _listaContas.AddRange(contas);

            }
            else
            {
                MessageBox.Show($"Nenhuma conta encontrada para o cliente {_clienteLogado.Id}");
            }
        }

        private void ConfigurarInterface()
        {
            var contaCorrente = ObterContaPorTipo(TIPO_CONTA_CORRENTE);
            var contaPoupanca = ObterContaPorTipo(TIPO_CONTA_POUPANCA);

            Console.WriteLine($"=== CONFIGURANDO INTERFACE ===");
            Console.WriteLine($"Conta Corrente encontrada: {contaCorrente?.Id} ({contaCorrente?.Tipo})");
            Console.WriteLine($"Conta Poupança encontrada: {contaPoupanca?.Id} ({contaPoupanca?.Tipo})");

            // Configurar botões
            ConfigurarBotaoConta(btnCorrente, contaCorrente, "Conta Corrente");
            ConfigurarBotaoConta(btnPoupanca, contaPoupanca, "Conta Poupança");

            // Definir conta inicial (prioridade: corrente > poupança)
            _contaAtual = contaCorrente ?? contaPoupanca;
            Console.WriteLine($"Conta inicial definida: {_contaAtual?.Id} ({_contaAtual?.Tipo})");
            Console.WriteLine("=== INTERFACE CONFIGURADA ===");
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

                // Debug: Log do saldo calculado
                Console.WriteLine($"Saldo calculado para {tipoDesejado}: {saldoTotal:C}");

                AtualizarLabelSaldo(saldoTotal);
                AtualizarLabelTipoConta(tipoDesejado);

                // Atualizar cor do saldo baseado no valor
                if (lblSaldo != null)
                {
                    lblSaldo.ForeColor = saldoTotal >= 0 ? Color.Green : Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir saldo: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularSaldoTotal(string tipoDesejado)
        {
            var contasFiltradas = _listaContas
                .Where(c => string.Equals(c.Tipo, tipoDesejado, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Debug: Log das contas filtradas
            Console.WriteLine($"Contas filtradas para tipo '{tipoDesejado}': {contasFiltradas.Count}");
            foreach (var conta in contasFiltradas)
            {
                Console.WriteLine($"  - Conta {conta.Id}: Tipo='{conta.Tipo}', Saldo={conta.Saldo:C}");
            }

            var saldoTotal = contasFiltradas.Sum(c => c.Saldo);
            Console.WriteLine($"Saldo total para '{tipoDesejado}': {saldoTotal:C}");

            return saldoTotal;
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
                // NÃO carregar transações aqui, pois elas são carregadas pelos botões específicos
                // CarregarTransacoesRecentes(); // REMOVIDO

                // Carregar cartões NFC (apenas 2 - limite máximo)
                CarregarCartoesNFC();

                // Atualizar estatísticas gerais
                AtualizarEstatisticasGerais();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarEstatisticasGerais()
        {
            try
            {
                // lblTotalCartoes deve permanecer como mensagem fixa "Cartões ativos"
                // Não atualizar aqui, pois é apenas um label informativo

                // NÃO atualizar o saldo aqui, pois ele já é atualizado pelos métodos específicos
                // de cada tipo de conta (btnCorrente_Click e btnPoupanca_Click)
            }
            catch (Exception ex)
            {
                // Log do erro sem interromper a interface
                Console.WriteLine($"Erro ao atualizar estatísticas gerais: {ex.Message}");
            }
        }

        private void CarregarTransacoesRecentes(string tipoConta = null)
        {
            try
            {
                Console.WriteLine($"=== CARREGANDO TRANSAÇÕES RECENTES ===");
                Console.WriteLine($"Tipo de conta solicitado: '{tipoConta ?? "TODAS"}'");

                panelListaTransacoes.Controls.Clear();

                // Buscar transações reais do banco
                var transacoesReais = new List<Transacao>();

                if (string.IsNullOrEmpty(tipoConta))
                {
                    Console.WriteLine("Modo: Todas as contas (sem duplicação)");
                    // Se não especificar tipo, buscar de todas as contas (comportamento original)
                    foreach (var conta in _listaContas)
                    {
                        var transacoesConta = _transacaoController.BuscarPorContaId(conta.Id);
                        if (transacoesConta != null)
                        {
                            transacoesReais.AddRange(transacoesConta);
                            Console.WriteLine($"Conta {conta.Id} ({conta.Tipo}): {transacoesConta.Count} transações");
                        }
                    }

                    // Para transferências, agrupar por ID e selecionar apenas uma (evitar duplicação)
                    var transacoesUnicas = transacoesReais
                        .GroupBy(t => t.Id)
                        .Select(g => g.First()) // Pegar apenas a primeira transação de cada grupo
                        .OrderByDescending(t => t.DataTransacao)
                        .Take(2)
                        .ToList();

                    Console.WriteLine($"Total transações únicas: {transacoesUnicas.Count}");
                    ExibirTransacoes(transacoesUnicas);
                }
                else
                {
                    Console.WriteLine($"Modo: Conta específica ({tipoConta})");
                    // Se especificar tipo, buscar apenas da conta selecionada
                    var contaSelecionada = _listaContas.FirstOrDefault(c =>
                        string.Equals(c.Tipo, tipoConta, StringComparison.OrdinalIgnoreCase));

                    if (contaSelecionada != null)
                    {
                        Console.WriteLine($"Conta selecionada: {contaSelecionada.Id} ({contaSelecionada.Tipo})");
                        var transacoesConta = _transacaoController.BuscarPorContaId(contaSelecionada.Id);
                        if (transacoesConta != null)
                        {
                            Console.WriteLine($"Transações encontradas na conta: {transacoesConta.Count}");
                            // Para conta específica, mostrar todas as transações (incluindo transferências com valores corretos)
                            var transacoesOrdenadas = transacoesConta
                                .OrderByDescending(t => t.DataTransacao)
                                .Take(2)
                                .ToList();

                            Console.WriteLine($"Transações para exibir: {transacoesOrdenadas.Count}");
                            ExibirTransacoes(transacoesOrdenadas, tipoConta);
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma transação encontrada na conta");
                            ExibirMensagemSemTransacoes();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Conta do tipo '{tipoConta}' não encontrada!");
                        ExibirMensagemSemTransacoes();
                    }
                }

                Console.WriteLine("=== TRANSAÇÕES CARREGADAS ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao carregar transações: {ex.Message}");
                MessageBox.Show($"Erro ao carregar transações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExibirTransacoes(List<Transacao> transacoes, string tipoConta = null)
        {
            if (!transacoes.Any())
            {
                ExibirMensagemSemTransacoes();
                return;
            }

            Console.WriteLine($"=== EXIBINDO TRANSAÇÕES ===");
            Console.WriteLine($"Tipo de conta para valores: '{tipoConta ?? "N/A"}'");
            Console.WriteLine($"Total de transações para exibir: {transacoes.Count}");

            // Determinar qual conta usar para calcular os valores das transferências
            Conta contaReferencia = null;
            if (!string.IsNullOrEmpty(tipoConta))
            {
                contaReferencia = _listaContas.FirstOrDefault(c =>
                    string.Equals(c.Tipo, tipoConta, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"Conta de referência: {contaReferencia?.Id} ({contaReferencia?.Tipo})");
            }

            foreach (var transacao in transacoes)
            {
                var tipoTransacao = ObterNomeTipoTransacao(transacao.Tipo);
                var dataFormatada = transacao.DataTransacao.ToString("dd/MM/yyyy HH:mm");

                // Para transferências, determinar se é entrada ou saída baseado na conta
                decimal valorExibicao = transacao.Valor;
                if (transacao.Tipo == "transferencia" && contaReferencia != null)
                {
                    if (transacao.ContaOrigemId == contaReferencia.Id)
                    {
                        // Esta conta é origem (SAÍDA) - valor negativo
                        valorExibicao = -Math.Abs(transacao.Valor);
                        Console.WriteLine($"TRANSFERÊNCIA SAÍDA: Conta {contaReferencia.Id} é origem - Valor original: {transacao.Valor:C} → Valor exibição: {valorExibicao:C}");
                    }
                    else if (transacao.ContaDestinoId == contaReferencia.Id)
                    {
                        // Esta conta é destino (ENTRADA) - valor positivo
                        valorExibicao = Math.Abs(transacao.Valor);
                        Console.WriteLine($"TRANSFERÊNCIA ENTRADA: Conta {contaReferencia.Id} é destino - Valor original: {transacao.Valor:C} → Valor exibição: {valorExibicao:C}");
                    }
                }

                var cor = valorExibicao >= 0 ? Color.Green : Color.Red;
                Console.WriteLine($"Exibindo: {tipoTransacao} - {dataFormatada} - {valorExibicao:C} - Cor: {(cor == Color.Green ? "Verde" : "Vermelho")}");
                CriarPanelTransacao(tipoTransacao, dataFormatada, valorExibicao, cor);
            }

            Console.WriteLine("=== TRANSAÇÕES EXIBIDAS ===");
        }

        private void ExibirMensagemSemTransacoes()
        {
            var lblSemTransacoes = new Label
            {
                Text = "Nenhuma transação encontrada",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            panelListaTransacoes.Controls.Add(lblSemTransacoes);
        }

        private void CarregarCartoesNFC()
        {
            try
            {
                panelListaCartoes.Controls.Clear();

                // Buscar cartões reais do banco
                var cartoesReais = new List<CartaoNfc>();

                // Buscar cartões de todas as contas do usuário
                foreach (var conta in _listaContas)
                {
                    var cartoesConta = _cartaoController.BuscarPorContaId(conta.Id);
                    if (cartoesConta != null)
                    {
                        cartoesReais.AddRange(cartoesConta);
                    }
                }

                // Limite máximo de 2 cartões por usuário
                const int LIMITE_CARTOES = 2;
                var cartoesExibidos = cartoesReais
                    .OrderByDescending(c => c.DataVinculacao)
                    .Take(LIMITE_CARTOES)
                    .ToList();

                // Se não houver cartões reais, mostrar mensagem
                if (!cartoesExibidos.Any())
                {
                    var lblSemCartoes = new Label
                    {
                        Text = "Nenhum cartão encontrado",
                        ForeColor = Color.Gray,
                        Font = new Font("Segoe UI", 9),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    panelListaCartoes.Controls.Add(lblSemCartoes);
                    return;
                }

                foreach (var cartao in cartoesExibidos)
                {
                    var conta = _listaContas.FirstOrDefault(c => c.Id == cartao.ContaId);
                    var nomeConta = conta != null ?
                        (conta.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança") :
                        "Conta";

                    CriarPanelCartao(cartao.Apelido, nomeConta, cartao.Uid, cartao.Ativo);
                }

                // Atualizar estatísticas dos cartões
                if (lblCartoesAtivos != null)
                {
                    lblCartoesAtivos.Text = cartoesExibidos.Count(c => c.Ativo).ToString();
                }

                if (progressBarCartoes != null)
                {
                    int percentual = cartoesExibidos.Count > 0 ? (cartoesExibidos.Count(c => c.Ativo) * 100) / cartoesExibidos.Count : 0;
                    progressBarCartoes.Value = percentual;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cartões: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarPanelTransacao(string tipo, string data, decimal valor, Color cor)
        {
            var panel = new Panel
            {
                BackColor = Color.FromArgb(249, 250, 251),
                Size = new Size(380, 60),
                Margin = new Padding(0, 0, 0, 8)
            };

            var lblTipo = new Label
            {
                Text = tipo,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(12, 8),
                AutoSize = true
            };

            var lblData = new Label
            {
                Text = data,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(12, 28),
                AutoSize = true
            };

            var lblValor = new Label
            {
                Text = valor.ToString("C"),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = cor,
                Location = new Point(280, 20),
                AutoSize = true
            };

            panel.Controls.Add(lblTipo);
            panel.Controls.Add(lblData);
            panel.Controls.Add(lblValor);
            panelListaTransacoes.Controls.Add(panel);
        }

        private string ObterNomeTipoTransacao(string tipo)
        {
            switch (tipo?.ToLower())
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
                    return tipo ?? "Transação";
            }
        }

        private void CriarPanelCartao(string nome, string conta, string uid, bool ativo)
        {
            var panel = new Panel
            {
                BackColor = Color.FromArgb(249, 250, 251),
                Size = new Size(380, 60),
                Margin = new Padding(0, 0, 0, 8)
            };

            var lblNome = new Label
            {
                Text = nome,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(12, 8),
                AutoSize = true
            };

            var lblConta = new Label
            {
                Text = conta,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(12, 28),
                AutoSize = true
            };

            var lblUID = new Label
            {
                Text = $"UID: {uid}",
                Font = new Font("Segoe UI", 7),
                ForeColor = Color.FromArgb(156, 163, 175),
                Location = new Point(12, 42),
                AutoSize = true
            };

            var lblStatus = new Label
            {
                Text = ativo ? "Ativo" : "Inativo",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = ativo ? Color.FromArgb(30, 64, 175) : Color.FromArgb(107, 114, 128),
                BackColor = ativo ? Color.FromArgb(219, 234, 254) : Color.FromArgb(243, 244, 246),
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
        #endregion

        #region Event Handlers
        private void Form2_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário
        }

        private void btnCorrente_Click(object sender, EventArgs e)
        {
            ExibirSaldoPorTipo(TIPO_CONTA_CORRENTE);

            // Carregar transações específicas da conta corrente
            CarregarTransacoesRecentes(TIPO_CONTA_CORRENTE);

            // Atualizar outras estatísticas
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

            // Carregar transações específicas da conta poupança
            CarregarTransacoesRecentes(TIPO_CONTA_POUPANCA);

            // Atualizar outras estatísticas
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
                    var telaTransacoes = new Transacoes(_clienteLogado);
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
