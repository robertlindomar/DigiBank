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
    public partial class TerminaisPOS : Form
    {
        private TerminalPosService _terminalService;
        private ContaService _contaService;
        private List<TerminalPos> _terminaisOriginais;
        private List<TerminalPos> _terminaisFiltrados;
        private bool _isPlaceholderVisible = true;

        public TerminaisPOS()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarTerminais();
        }

        private void InicializarServicos()
        {
            _terminalService = new TerminalPosService();
            _contaService = new ContaService();
            _terminaisOriginais = new List<TerminalPos>();
            _terminaisFiltrados = new List<TerminalPos>();
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
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 150,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeLoja",
                HeaderText = "Nome da Loja",
                Width = 200,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Localizacao",
                HeaderText = "Localização",
                Width = 150,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Uid",
                HeaderText = "UID",
                Width = 120,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContaId",
                HeaderText = "ID da Conta",
                Width = 100,
                ReadOnly = true
            });

            dgvContas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Ativo",
                HeaderText = "Ativo",
                Width = 80,
                ReadOnly = true
            });

            // Configurar comboboxes
            ConfigurarComboboxes();
            cmbTipoClientes.SelectedIndex = 0;
            cmbTipoClienteAtvInt.SelectedIndex = 0;

            // Configurar placeholders
            ConfigurarPlaceholder();

            // Configurar botões
            bntEditarTerminal.Enabled = false;
            btnExcluirTerminal.Enabled = false;
        }

        private void ConfigurarComboboxes()
        {
            // Limpar e configurar cmbTipoClientes (status do terminal)
            cmbTipoClientes.Items.Clear();
            cmbTipoClientes.Items.AddRange(new object[] { "Todos", "Ativos", "Inativos" });

            // Limpar e configurar cmbTipoClienteAtvInt (tipos de conta)
            cmbTipoClienteAtvInt.Items.Clear();
            cmbTipoClienteAtvInt.Items.AddRange(new object[] { "Todas as Contas", "Conta Corrente", "Conta Poupança" });
        }

        private void ConfigurarPlaceholder()
        {
            txtBuscarClientes.ForeColor = Color.Gray;
            txtBuscarClientes.Text = "🔍 Buscar por nome, loja, localização ou UID...";
            _isPlaceholderVisible = true;
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnNovoTerminal.Click += BtnNovoTerminal_Click;
            bntEditarTerminal.Click += BntEditarTerminal_Click;
            btnExcluirTerminal.Click += BtnExcluirTerminal_Click;

            // Eventos de filtros
            txtBuscarClientes.Enter += TxtBuscarClientes_Enter;
            txtBuscarClientes.Leave += TxtBuscarClientes_Leave;
            txtBuscarClientes.TextChanged += TxtBuscarClientes_TextChanged;

            // Eventos do DataGridView
            dgvContas.SelectionChanged += DgvContas_SelectionChanged;
            dgvContas.CellDoubleClick += DgvContas_CellDoubleClick;

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
                var statusTerminal = cmbTipoClientes.SelectedItem?.ToString();
                var tipoConta = cmbTipoClienteAtvInt.SelectedItem?.ToString();

                _terminaisFiltrados = _terminaisOriginais.Where(t =>
                {
                    // Filtro de texto
                    bool matchTexto = string.IsNullOrEmpty(textoBusca) ||
                                    t.Nome?.ToLower().Contains(textoBusca) == true ||
                                    t.NomeLoja?.ToLower().Contains(textoBusca) == true ||
                                    t.Localizacao?.ToLower().Contains(textoBusca) == true ||
                                    t.Uid?.ToLower().Contains(textoBusca) == true;

                    // Filtro por status do terminal
                    bool matchStatus = statusTerminal == "Todos" ||
                                     (statusTerminal == "Ativos" && t.Ativo) ||
                                     (statusTerminal == "Inativos" && !t.Ativo);

                    // Filtro por tipo de conta (será implementado quando tivermos acesso às contas)
                    bool matchConta = tipoConta == "Todas as Contas"; // Por enquanto sempre true

                    return matchTexto && matchStatus && matchConta;
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
            dgvContas.DataSource = _terminaisFiltrados;
            AtualizarContadores();
        }

        private void AtualizarContadores()
        {
            var totalTerminais = _terminaisFiltrados.Count;
            var totalGeral = _terminaisOriginais.Count;

            if (totalTerminais != totalGeral)
            {
                lblSubtitulo.Text = $"Gerencie os terminais de pagamento - {totalTerminais} de {totalGeral} terminais";
            }
            else
            {
                lblSubtitulo.Text = $"Gerencie os terminais de pagamento - {totalGeral} terminais";
            }
        }

        private void CarregarTerminais()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _terminaisOriginais = _terminalService.BuscarTodos();
                _terminaisFiltrados = _terminaisOriginais.ToList();
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar terminais: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnNovoTerminal_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormNovoTerminal();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Terminal criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarTerminais(); // Recarregar lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo terminal: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BntEditarTerminal_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContas.SelectedRows.Count > 0)
                {
                    var terminal = dgvContas.SelectedRows[0].DataBoundItem as TerminalPos;
                    if (terminal != null)
                    {
                        var form = new FormNovoTerminal(terminal);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Terminal atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarTerminais(); // Recarregar lista
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um terminal para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar terminal: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirTerminal_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContas.SelectedRows.Count > 0)
                {
                    var terminal = dgvContas.SelectedRows[0].DataBoundItem as TerminalPos;
                    if (terminal != null)
                    {
                        var resultado = MessageBox.Show(
                            $"Tem certeza que deseja excluir o terminal '{terminal.Nome}'?\n\n" +
                            $"ID: {terminal.Id}\n" +
                            $"Loja: {terminal.NomeLoja}\n" +
                            $"UID: {terminal.Uid}\n\n" +
                            $"Esta ação não pode ser desfeita.",
                            "Confirmar Exclusão",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;

                                // Executar a exclusão
                                _terminalService.DeletarTerminal(terminal.Id);

                                MessageBox.Show($"Terminal '{terminal.Nome}' excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarTerminais(); // Recarregar lista
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao excluir terminal: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Selecione um terminal para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir terminal: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvContas_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgvContas.SelectedRows.Count > 0;
            bntEditarTerminal.Enabled = temSelecao;
            btnExcluirTerminal.Enabled = temSelecao;
        }

        private void DgvContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BntEditarTerminal_Click(sender, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carregar dados quando o formulário for carregado
            CarregarTerminais();
        }
    }
}
