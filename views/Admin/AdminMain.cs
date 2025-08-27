using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.views.Admin
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
            ConfigurarEventosBotoes();
            ConfigurarEventoFechamento();
        }

        private void ConfigurarEventosBotoes()
        {
            // Configurar eventos de clique para todos os botões
            btnDashboard.Click += btnDashboard_Click;
            btnClientes.Click += btnClientes_Click;
            btnContas.Click += btnContas_Click;
            btnCartoes.Click += btnCartoes_Click;
            btnTransacoes.Click += btnTransacoes_Click;
            bntTerminais.Click += bntTerminais_Click;
            bntRelatorios.Click += bntRelatorios_Click;
            btnConfiguracoes.Click += btnConfiguracoes_Click;
            btnSair.Click += btnSair_Click;

            // Carregar dashboard por padrão
            btnDashboard_Click(null, null);
        }

        private void ConfigurarEventoFechamento()
        {
            // Configurar evento para quando a janela for fechada
            this.FormClosed += AdminMain_FormClosed;
        }

        private void AdminMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Quando a janela do admin for fechada, retornar para a tela de login
            // Procurar pela tela de login e mostrá-la
            foreach (Form form in Application.OpenForms)
            {
                if (form is Login)
                {
                    form.Show();
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnDashboard);

            panelPrincipal.Controls.Clear();

            AdminDashBoard telaDashboard = new AdminDashBoard()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(telaDashboard);
            telaDashboard.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnClientes);

            panelPrincipal.Controls.Clear();

            Clientes tela = new Clientes()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnContas_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnContas);

            panelPrincipal.Controls.Clear();

            Contas tela = new Contas()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnCartoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnCartoes);

            panelPrincipal.Controls.Clear();

            CartoesNFC tela = new CartoesNFC()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnTransacoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnTransacoes);

            panelPrincipal.Controls.Clear();

            Transacoes tela = new Transacoes()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void bntTerminais_Click(object sender, EventArgs e)
        {
            SelecionarBotao(bntTerminais);

            panelPrincipal.Controls.Clear();

            TerminaisPOS tela = new TerminaisPOS()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void bntRelatorios_Click(object sender, EventArgs e)
        {
            SelecionarBotao(bntRelatorios);

            panelPrincipal.Controls.Clear();

            Relatorios tela = new Relatorios()
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelPrincipal.Controls.Add(tela);
            tela.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SelecionarBotao(btnConfiguracoes);

            panelPrincipal.Controls.Clear();

            // Aqui você pode implementar a tela de configurações quando estiver disponível
            // Por enquanto, apenas limpa o painel principal
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Tem certeza que deseja sair do sistema?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Fechar a janela do admin (isso disparará o evento FormClosed)
                this.Close();
            }
        }

        private void ResetarEstiloBotoes()
        {
            // Lista com todos os botões do menu
            List<Button> botoesMenu = new List<Button>
            {
                btnDashboard,
                btnClientes,
                btnContas,
                btnCartoes,
                btnTransacoes,
                bntTerminais,
                bntRelatorios,
                btnConfiguracoes,
                btnSair
            };

            foreach (var botao in botoesMenu)
            {
                botao.BackColor = Color.White;
                botao.ForeColor = Color.FromArgb(107, 114, 128);
                botao.FlatAppearance.BorderSize = 0;
            }
        }

        private void SelecionarBotao(Button botao)
        {
            // Resetar todos
            ResetarEstiloBotoes();

            // Estilo de selecionado
            botao.BackColor = Color.FromArgb(239, 246, 255);
            botao.ForeColor = Color.FromArgb(37, 99, 235);
        }
    }
}
