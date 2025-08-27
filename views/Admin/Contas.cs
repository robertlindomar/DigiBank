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
    public partial class Contas : Form
    {
        private ContaService _contaService;
        private ClienteService _clienteService;
        private List<Conta> _contasOriginais;
        private List<Conta> _contasFiltradas;
        private bool _isPlaceholderVisible = true;

        public Contas()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarContas();
        }

        private void InicializarServicos()
        {
            _contaService = new ContaService();
            _clienteService = new ClienteService();
            _contasOriginais = new List<Conta>();
            _contasFiltradas = new List<Conta>();
        }

        private void ConfigurarInterface()
        {
            // Configurar DataGridView
            dgvContas.AutoGenerateColumns = false;
            dgvContas.Columns.Clear();

            // Adicionar colunas
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumeroConta",
                HeaderText = "Número da Conta",
                Width = 150,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 120,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Saldo",
                HeaderText = "Saldo",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvContas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Ativa",
                HeaderText = "Ativa",
                Width = 80,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataAbertura",
                HeaderText = "Data Abertura",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cliente.Nome",
                HeaderText = "Cliente",
                Width = 200,
                ReadOnly = true
            });

            // Configurar comboboxes
            ConfigurarComboboxes();
            cmbTipoClienteAtvInt.SelectedIndex = 0;
            cmbTipoClientes.SelectedIndex = 0;

            // Configurar placeholders
            ConfigurarPlaceholder();
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnNovaConta.Click += BtnNovaConta_Click;
            bntEditarConta.Click += BntEditarConta_Click;
            btnExcluirConta.Click += BtnExcluirConta_Click;

            // Eventos de filtros
            txtBuscarClientes.Enter += TxtBuscarClientes_Enter;
            txtBuscarClientes.Leave += TxtBuscarClientes_Leave;
            txtBuscarClientes.TextChanged += TxtBuscarClientes_TextChanged;

            // Eventos do DataGridView
            dgvContas.SelectionChanged += DgvContas_SelectionChanged;
            dgvContas.CellDoubleClick += DgvContas_CellDoubleClick;

            // Eventos dos comboboxes
            cmbTipoClienteAtvInt.SelectedIndexChanged += CmbTipoClienteAtvInt_SelectedIndexChanged;
            cmbTipoClientes.SelectedIndexChanged += CmbTipoClientes_SelectedIndexChanged;
        }

        private void ConfigurarComboboxes()
        {
            // Limpar e configurar cmbTipoClienteAtvInt (tipo de conta)
            cmbTipoClienteAtvInt.Items.Clear();
            cmbTipoClienteAtvInt.Items.AddRange(new object[] { "Todas as Contas", "Conta Corrente", "Conta Poupança" });

            // Limpar e configurar cmbTipoClientes (status da conta)
            cmbTipoClientes.Items.Clear();
            cmbTipoClientes.Items.AddRange(new object[] { "Todas", "Ativas", "Inativas" });
        }

        private void ConfigurarPlaceholder()
        {
            txtBuscarClientes.ForeColor = Color.Gray;
            txtBuscarClientes.Text = "🔍 Buscar por número da conta, cliente ou tipo...";
            _isPlaceholderVisible = true;
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

        private void CmbTipoClienteAtvInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CmbTipoClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            try
            {
                var textoBusca = _isPlaceholderVisible ? "" : txtBuscarClientes.Text.Trim().ToLower();
                var tipoConta = cmbTipoClienteAtvInt.SelectedItem?.ToString();
                var statusConta = cmbTipoClientes.SelectedItem?.ToString();

                _contasFiltradas = _contasOriginais.Where(c =>
                {
                    // Filtro de texto
                    bool matchTexto = string.IsNullOrEmpty(textoBusca) ||
                                    c.NumeroConta?.ToLower().Contains(textoBusca) == true ||
                                    c.Cliente?.Nome?.ToLower().Contains(textoBusca) == true ||
                                    c.Tipo?.ToLower().Contains(textoBusca) == true;

                    // Filtro por tipo de conta
                    bool matchTipo = tipoConta == "Todas as Contas" ||
                                   (tipoConta == "Conta Corrente" && c.Tipo == "corrente") ||
                                   (tipoConta == "Conta Poupança" && c.Tipo == "poupanca");

                    // Filtro por status da conta
                    bool matchStatus = statusConta == "Todas" ||
                                     (statusConta == "Ativas" && c.Ativa) ||
                                     (statusConta == "Inativas" && !c.Ativa);

                    return matchTexto && matchTipo && matchStatus;
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
            dgvContas.DataSource = null;
            dgvContas.DataSource = _contasFiltradas;
            AtualizarContadores();
        }

        private void AtualizarContadores()
        {
            var totalContas = _contasFiltradas.Count;
            var totalGeral = _contasOriginais.Count;

            if (totalContas != totalGeral)
            {
                lblSubtitulo.Text = $"Administre as contas do sistema - {totalContas} de {totalGeral} contas";
            }
            else
            {
                lblSubtitulo.Text = $"Administre as contas do sistema - {totalGeral} contas";
            }
        }

        private void CarregarContas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _contasOriginais = _contaService.BuscarTodas();
                _contasFiltradas = _contasOriginais.ToList();
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnNovaConta_Click(object sender, EventArgs e)
        {
            try
            {
                FormNovaConta form = new FormNovaConta();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Conta criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarContas(); // Recarregar lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar nova conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BntEditarConta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContas.SelectedRows.Count > 0)
                {
                    var conta = dgvContas.SelectedRows[0].DataBoundItem as Conta;
                    if (conta != null)
                    {
                        FormNovaConta form = new FormNovaConta(conta);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Conta atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarContas(); // Recarregar lista
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma conta para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirConta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContas.SelectedRows.Count > 0)
                {
                    var conta = dgvContas.SelectedRows[0].DataBoundItem as Conta;
                    if (conta != null)
                    {
                        // Verificar se a conta tem saldo
                        if (conta.Saldo > 0)
                        {
                            MessageBox.Show(
                                $"Não é possível excluir a conta '{conta.NumeroConta}' pois ela possui saldo de {conta.Saldo:C2}.\n\n" +
                                $"Primeiro transfira ou saque todo o saldo da conta.",
                                "Conta com Saldo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        var resultado = MessageBox.Show(
                            $"Tem certeza que deseja excluir a conta '{conta.NumeroConta}'?\n\n" +
                            $"ID: {conta.Id}\n" +
                            $"Tipo: {conta.Tipo}\n" +
                            $"Cliente: {conta.Cliente?.Nome}\n\n" +
                            $"Esta ação não pode ser desfeita.",
                            "Confirmar Exclusão",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;

                                // Executar a exclusão real
                                _contaService.DeletarConta(conta.Id);

                                MessageBox.Show($"Conta '{conta.NumeroConta}' excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarContas(); // Recarregar lista
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao excluir conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma conta para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvContas_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgvContas.SelectedRows.Count > 0;
            bntEditarConta.Enabled = temSelecao;
            btnExcluirConta.Enabled = temSelecao;
        }

        private void DgvContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BntEditarConta_Click(sender, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carregar dados quando o formulário for carregado
            CarregarContas();
        }

        // Eventos existentes (mantidos para compatibilidade)
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
    }
}
