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
    public partial class Clientes : Form
    {
        private ClienteService _clienteService;
        private List<Cliente> _clientesOriginais;
        private List<Cliente> _clientesFiltrados;
        private bool _isPlaceholderVisible = true;

        public Clientes()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarClientes();
        }

        private void InicializarServicos()
        {
            _clienteService = new ClienteService();
            _clientesOriginais = new List<Cliente>();
            _clientesFiltrados = new List<Cliente>();
        }

        private void ConfigurarInterface()
        {
            // Configurar DataGridView
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            // Adicionar colunas
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 200,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login",
                HeaderText = "Login",
                Width = 150,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cpf",
                HeaderText = "CPF",
                Width = 120,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 100,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Ativo",
                HeaderText = "Ativo",
                Width = 80,
                ReadOnly = true
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataCriacao",
                HeaderText = "Data Criação",
                Width = 120,
                ReadOnly = true
            });

            // Configurar comboboxes
            ConfigurarComboboxes();
            cmbTipoClientes.SelectedIndex = 0;
            cmbTipoClienteAtvInt.SelectedIndex = 0;

            // Configurar placeholders
            ConfigurarPlaceholder();
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnNovoCliente.Click += BtnNovoCliente_Click;
            bntEditarCliente.Click += BntEditarCliente_Click;
            btnExcluirCliente.Click += BtnExcluirCliente_Click;

            // Eventos de filtros
            txtBuscarClientes.Enter += TxtBuscarClientes_Enter;
            txtBuscarClientes.Leave += TxtBuscarClientes_Leave;
            txtBuscarClientes.TextChanged += TxtBuscarClientes_TextChanged;

            // Eventos do DataGridView
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
            dgvClientes.CellDoubleClick += DgvClientes_CellDoubleClick;

            // Eventos dos comboboxes
            cmbTipoClientes.SelectedIndexChanged += CmbTipoClientes_SelectedIndexChanged;
            cmbTipoClienteAtvInt.SelectedIndexChanged += CmbTipoClienteAtvInt_SelectedIndexChanged;
        }

        private void ConfigurarComboboxes()
        {
            // Limpar e configurar cmbTipoClientes
            cmbTipoClientes.Items.Clear();
            cmbTipoClientes.Items.AddRange(new object[] { "Todas", "Admin", "Clientes" });

            // Limpar e configurar cmbTipoClienteAtvInt
            cmbTipoClienteAtvInt.Items.Clear();
            cmbTipoClienteAtvInt.Items.AddRange(new object[] { "Todas as Contas", "Conta Corrente", "Conta Poupança" });
        }

        private void ConfigurarPlaceholder()
        {
            txtBuscarClientes.ForeColor = Color.Gray;
            txtBuscarClientes.Text = "🔍 Buscar Por nome, Cpf ou Login...";
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
                var tipoCliente = cmbTipoClientes.SelectedItem?.ToString();
                var tipoConta = cmbTipoClienteAtvInt.SelectedItem?.ToString();

                _clientesFiltrados = _clientesOriginais.Where(c =>
                {
                    // Filtro de texto
                    bool matchTexto = string.IsNullOrEmpty(textoBusca) ||
                                    c.Nome?.ToLower().Contains(textoBusca) == true ||
                                    c.Login?.ToLower().Contains(textoBusca) == true ||
                                    c.Cpf?.Contains(textoBusca) == true;

                    // Filtro por tipo de cliente (admin/cliente)
                    bool matchTipo = tipoCliente == "Todas" ||
                                   (tipoCliente == "Admin" && c.Tipo == "admin") ||
                                   (tipoCliente == "Clientes" && c.Tipo == "cliente");

                    // Filtro por status ativo
                    bool matchStatus = tipoConta == "Todas as Contas" ||
                                     (tipoConta == "Conta Corrente" && c.Ativo) ||
                                     (tipoConta == "Conta Poupança" && c.Ativo);

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
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _clientesFiltrados;
            AtualizarContadores();
        }

        private void AtualizarContadores()
        {
            var totalClientes = _clientesFiltrados.Count;
            var totalGeral = _clientesOriginais.Count;

            if (totalClientes != totalGeral)
            {
                lblSubtitulo.Text = $"Administre os clientes do sistema - {totalClientes} de {totalGeral} clientes";
            }
            else
            {
                lblSubtitulo.Text = $"Administre os clientes do sistema - {totalGeral} clientes";
            }
        }

        private void CarregarClientes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _clientesOriginais = _clienteService.BuscarTodos();
                _clientesFiltrados = _clientesOriginais.ToList();
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FormNovoCliente form = new FormNovoCliente();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarClientes(); // Recarregar lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BntEditarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    var cliente = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
                    if (cliente != null)
                    {
                        FormNovoCliente form = new FormNovoCliente(cliente);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarClientes(); // Recarregar lista
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    var cliente = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
                    if (cliente != null)
                    {
                        // Verificar se o cliente tem contas ou cartões
                        if (cliente.Contas?.Count > 0 || cliente.Cartoes?.Count > 0)
                        {
                            MessageBox.Show(
                                $"Não é possível excluir o cliente '{cliente.Nome}' pois ele possui:\n" +
                                $"• {cliente.Contas?.Count ?? 0} conta(s)\n" +
                                $"• {cliente.Cartoes?.Count ?? 0} cartão(ões)\n\n" +
                                $"Primeiro remova todas as contas e cartões associados.",
                                "Cliente com Dependências",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        var resultado = MessageBox.Show(
                            $"Tem certeza que deseja excluir o cliente '{cliente.Nome}'?\n\n" +
                            $"ID: {cliente.Id}\n" +
                            $"CPF: {cliente.Cpf}\n" +
                            $"Login: {cliente.Login}\n\n" +
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
                                _clienteService.DeletarCliente(cliente.Id);

                                MessageBox.Show($"Cliente '{cliente.Nome}' excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarClientes(); // Recarregar lista
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgvClientes.SelectedRows.Count > 0;
            bntEditarCliente.Enabled = temSelecao;
            btnExcluirCliente.Enabled = temSelecao;
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BntEditarCliente_Click(sender, e);
            }
        }

        // Eventos existentes (mantidos para compatibilidade)
        private void cmbTipoTransacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento já implementado acima
        }

        private void lblTipoTransacao_Click(object sender, EventArgs e)
        {
            // Evento de clique no label
        }

        private void lblTipoConta_Click(object sender, EventArgs e)
        {
            // Evento de clique no label
        }

        private void cmbTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento já implementado acima
        }

        private void btnMaisFiltros_Click(object sender, EventArgs e)
        {
            // Implementar filtros avançados se necessário
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Evento já implementado acima
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Evento de clique no título
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Carregar dados quando o formulário for carregado
            CarregarClientes();
        }
    }
}
