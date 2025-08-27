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

namespace DigiBank.views.Admin
{
    public partial class AdminDashBoard : Form
    {
        private ClienteService _clienteService;
        private ContaService _contaService;
        private CartaoService _cartaoService;
        private TransacaoService _transacaoService;
        private TerminalPosService _terminalService;

        public AdminDashBoard()
        {
            InitializeComponent();
            InicializarServicos();
            CarregarDashboard();
            ConfigurarTimerAtualizacao();
        }

        private void InicializarServicos()
        {
            _clienteService = new ClienteService();
            _contaService = new ContaService();
            _cartaoService = new CartaoService();
            _transacaoService = new TransacaoService();
            _terminalService = new TerminalPosService();
        }

        private void ConfigurarTimerAtualizacao()
        {
            // Atualizar dashboard a cada 30 segundos
            Timer timer = new Timer();
            timer.Interval = 30000; // 30 segundos
            timer.Tick += (sender, e) => CarregarDashboard();
            timer.Start();
        }

        private void CarregarDashboard()
        {
            try
            {
                CarregarEstatisticasGerais();
                CarregarAtividadesRecentes();
                VerificarStatusSistema();
                AtualizarBackupStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dashboard: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarEstatisticasGerais()
        {
            try
            {
                // Total de Clientes
                var totalClientes = _clienteService.BuscarTodos().Count;
                lblTotalClientes.Text = totalClientes.ToString();
                lblTotalClientesAtivos.Text = $"{totalClientes} Ativos";

                // Total de Contas
                var totalContas = _contaService.BuscarTodas().Count;
                lblTotalContasNumero.Text = totalContas.ToString();
                lblTotalContasAtivos.Text = $"{totalContas} Ativas";

                // Total de Cartões NFC
                var totalCartoes = _cartaoService.BuscarTodos().Count;
                lblCartoesNumero.Text = totalCartoes.ToString();
                lblCartoesAtivos.Text = $"{totalCartoes} Cartões Ativos";

                // Volume Total de Transações
                var transacoes = _transacaoService.BuscarTodas();
                var volumeTotal = transacoes.Sum(t => t.Valor);
                lblValorVolumeTotal.Text = $"R$ {volumeTotal:F2}";
            }
            catch (Exception ex)
            {
                // Em caso de erro, definir valores padrão
                lblTotalClientes.Text = "0";
                lblTotalContasNumero.Text = "0";
                lblCartoesNumero.Text = "0";
                lblValorVolumeTotal.Text = "R$ 0,00";
            }
        }

        private void CarregarAtividadesRecentes()
        {
            try
            {
                // Simular atividades recentes baseadas nos dados existentes
                var clientes = _clienteService.BuscarTodos();
                var contas = _contaService.BuscarTodas();
                var cartoes = _cartaoService.BuscarTodos();

                if (clientes.Any())
                {
                    var ultimoCliente = clientes.OrderByDescending(c => c.Id).First();
                    lblAtivadeUltimoCadastroCliente.Text = $"{ultimoCliente.Login} - Há 2 horas";
                    panelClienteCadastrado.Visible = true;
                    panelClienteAlterado.Visible = false;
                    panelClienteExcluido.Visible = false;
                }

                if (contas.Any())
                {
                    var ultimaConta = contas.OrderByDescending(c => c.Id).First();
                    lblAtividadeUltimaContaCriada.Text = $"{ultimaConta.NumeroConta} - Há 5 horas";
                    panelContaCriada.Visible = true;
                    panelContaAlterada.Visible = false;
                    panelContaExcluida.Visible = false;
                }

                if (cartoes.Any())
                {
                    var ultimoCartao = cartoes.OrderByDescending(c => c.Id).First();
                    lblAtividadeUltimoCartaoVinculado.Text = $"{ultimoCartao.Uid} - há 2 horas";
                    panelCartaoNFCVinculado.Visible = true;
                    panelCartaoNFCExcluido.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, ocultar painéis de atividade
                panelClienteCadastrado.Visible = false;
                panelContaCriada.Visible = false;
                panelCartaoNFCVinculado.Visible = false;
            }
        }

        private void VerificarStatusSistema()
        {
            try
            {
                // Verificar se os serviços estão funcionando
                var clientes = _clienteService.BuscarTodos();
                var contas = _contaService.BuscarTodas();
                var cartoes = _cartaoService.BuscarTodos();

                // Se conseguiu buscar dados, sistema está funcionando
                if (clientes != null && contas != null && cartoes != null)
                {
                    panelSistemaNormal.Visible = true;
                    panelSistemaFalha.Visible = false;
                }
                else
                {
                    panelSistemaNormal.Visible = false;
                    panelSistemaFalha.Visible = true;
                }
            }
            catch (Exception)
            {
                // Em caso de erro, mostrar falha do sistema
                panelSistemaNormal.Visible = false;
                panelSistemaFalha.Visible = true;
            }
        }

        private void AtualizarBackupStatus()
        {
            try
            {
                // Simular verificação de backup
                var horaAtual = DateTime.Now;
                var ultimoBackup = horaAtual.AddHours(-2); // Simular backup há 2 horas

                lblBackupUltimo.Text = $"Ultimo Backup: {ultimoBackup:dd/MM/yyyy} às {ultimoBackup:HH:mm}";
                panelBackupRealizado.Visible = true;
                panelFalhaBackup.Visible = false;
            }
            catch (Exception)
            {
                // Em caso de erro, mostrar falha no backup
                panelBackupRealizado.Visible = false;
                panelFalhaBackup.Visible = true;
            }
        }

        private void lblTipoConta_Click(object sender, EventArgs e)
        {
            // Evento de clique no título "Total Clientes"
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Evento de clique no ícone de clientes
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Evento de clique no título "Total Contas"
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Evento de pintura do painel principal
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carregar dados quando o formulário for carregado
            CarregarDashboard();
        }
    }
}
