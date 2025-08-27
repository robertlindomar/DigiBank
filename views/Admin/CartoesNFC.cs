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
    public partial class CartoesNFC : Form
    {
        private CartaoService _cartaoService;
        private ContaService _contaService;
        private List<CartaoNfc> _cartoesOriginais;
        private List<CartaoNfc> _cartoesFiltrados;
        private bool _isPlaceholderVisible = true;

        public CartoesNFC()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarCartoes();
        }

        private void InicializarServicos()
        {
            _cartaoService = new CartaoService();
            _contaService = new ContaService();
            _cartoesOriginais = new List<CartaoNfc>();
            _cartoesFiltrados = new List<CartaoNfc>();
        }

        private void ConfigurarInterface()
        {
            // Configurar DataGridView
            dgvCartoes.AutoGenerateColumns = false;
            dgvCartoes.Columns.Clear();

            // Adicionar colunas
            dgvCartoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true
            });

            dgvCartoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Uid",
                HeaderText = "UID",
                Width = 150,
                ReadOnly = true
            });

            dgvCartoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apelido",
                HeaderText = "Apelido",
                Width = 150,
                ReadOnly = true
            });

            dgvCartoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContaId",
                HeaderText = "ID Conta",
                Width = 100,
                ReadOnly = true
            });

            dgvCartoes.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Ativo",
                HeaderText = "Ativo",
                Width = 80,
                ReadOnly = true
            });

            dgvCartoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataVinculacao",
                HeaderText = "Data Vinculação",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Configurar filtros
            cmbTipoClientes.Items.Clear();
            cmbTipoClientes.Items.AddRange(new object[] { "Todos", "Ativos", "Inativos" });
            cmbTipoClientes.SelectedIndex = 0;

            // Configurar placeholder da busca
            txtBuscarClientes.Text = "Buscar por UID ou apelido...";
            txtBuscarClientes.ForeColor = Color.Gray;
        }

        private void ConfigurarEventos()
        {
            btnNovoCartao.Click += BtnNovoCartao_Click;
            bntEditarCartao.Click += BntEditarCartao_Click;
            btnExcluirCartao.Click += BtnExcluirCartao_Click;

            // Eventos de busca e filtros
            txtBuscarClientes.Enter += TxtBuscarClientes_Enter;
            txtBuscarClientes.Leave += TxtBuscarClientes_Leave;
            txtBuscarClientes.TextChanged += TxtBuscarClientes_TextChanged;
            cmbTipoClientes.SelectedIndexChanged += CmbTipoClientes_SelectedIndexChanged;

            // Eventos do DataGridView
            dgvCartoes.SelectionChanged += DgvCartoes_SelectionChanged;
            dgvCartoes.DoubleClick += DgvCartoes_DoubleClick;
        }

        private void CarregarCartoes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _cartoesOriginais = _cartaoService.BuscarTodos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cartões: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AplicarFiltros()
        {
            try
            {
                var filtrados = _cartoesOriginais.AsQueryable();

                // Filtro por texto de busca
                if (!string.IsNullOrWhiteSpace(txtBuscarClientes.Text) && !_isPlaceholderVisible)
                {
                    var termoBusca = txtBuscarClientes.Text.ToLower();
                    filtrados = filtrados.Where(c =>
                        c.Uid.ToLower().Contains(termoBusca) ||
                        c.Apelido.ToLower().Contains(termoBusca));
                }

                // Filtro por status
                if (cmbTipoClientes.SelectedItem != null)
                {
                    switch (cmbTipoClientes.SelectedItem.ToString())
                    {
                        case "Ativos":
                            filtrados = filtrados.Where(c => c.Ativo);
                            break;
                        case "Inativos":
                            filtrados = filtrados.Where(c => !c.Ativo);
                            break;
                            // "Todos" não aplica filtro
                    }
                }

                _cartoesFiltrados = filtrados.ToList();
                AtualizarDataGridView();
                AtualizarContadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            dgvCartoes.DataSource = null;
            dgvCartoes.DataSource = _cartoesFiltrados;
        }

        private void AtualizarContadores()
        {
            lblSubtitulo.Text = $"Total de cartões: {_cartoesFiltrados.Count}";
        }

        private void BtnNovoCartao_Click(object sender, EventArgs e)
        {
            try
            {
                FormNovoCartao form = new FormNovoCartao();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cartão criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCartoes(); // Recarregar lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BntEditarCartao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCartoes.SelectedRows.Count > 0)
                {
                    var cartao = dgvCartoes.SelectedRows[0].DataBoundItem as CartaoNfc;
                    if (cartao != null)
                    {
                        FormNovoCartao form = new FormNovoCartao(cartao);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Cartão atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarCartoes(); // Recarregar lista
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um cartão para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirCartao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCartoes.SelectedRows.Count > 0)
                {
                    var cartao = dgvCartoes.SelectedRows[0].DataBoundItem as CartaoNfc;
                    if (cartao != null)
                    {
                        var resultado = MessageBox.Show(
                            $"Tem certeza que deseja excluir o cartão '{cartao.Apelido}'?\n\n" +
                            $"UID: {cartao.Uid}\n" +
                            $"ID: {cartao.Id}\n" +
                            $"Conta ID: {cartao.ContaId}\n\n" +
                            $"Esta ação não pode ser desfeita.",
                            "Confirmar Exclusão",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _cartaoService.DeletarCartao(cartao.Id);

                                MessageBox.Show($"Cartão '{cartao.Apelido}' excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarCartoes(); // Recarregar lista
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao excluir cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Selecione um cartão para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtBuscarClientes.Text = "Buscar por UID ou apelido...";
                txtBuscarClientes.ForeColor = Color.Gray;
                _isPlaceholderVisible = true;
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

        private void DgvCartoes_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgvCartoes.SelectedRows.Count > 0;
            bntEditarCartao.Enabled = temSelecao;
            btnExcluirCartao.Enabled = temSelecao;
        }

        private void DgvCartoes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCartoes.SelectedRows.Count > 0)
            {
                BntEditarCartao_Click(sender, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarCartoes();
        }
    }
}
