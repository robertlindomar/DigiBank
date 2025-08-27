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
    public partial class FormNovaConta : Form
    {
        private ContaService _contaService;
        private ClienteService _clienteService;
        private bool _isEditMode = false;
        private Conta _contaEditando = null;
        private List<Cliente> _clientesDisponiveis;

        public FormNovaConta()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarClientes();
        }

        public FormNovaConta(Conta contaParaEditar)
        {
            InitializeComponent();
            _isEditMode = true;
            _contaEditando = contaParaEditar;
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarClientes();
            CarregarDadosConta();
        }

        private void InicializarServicos()
        {
            _contaService = new ContaService();
            _clienteService = new ClienteService();
            _clientesDisponiveis = new List<Cliente>();
        }

        private void ConfigurarInterface()
        {
            // Configurar título e botões baseado no modo
            if (_isEditMode)
            {
                this.Text = "Editar Conta";
                lblTitulo.Text = "Editar Conta";
                btnSalvar.Text = "Atualizar";
                btnCancelar.Text = "Cancelar";
            }
            else
            {
                this.Text = "Nova Conta";
                lblTitulo.Text = "Nova Conta";
                btnSalvar.Text = "Cadastrar";
                btnCancelar.Text = "Cancelar";

                // Gerar número da conta automaticamente
                GerarNumeroConta();
            }

            // Configurar combobox de tipo
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[] { "corrente", "poupanca" });
            cmbTipo.SelectedIndex = 0;

            // Configurar checkbox de ativa
            chkAtiva.Checked = true;

            // Configurar validações
            txtNumeroConta.MaxLength = 20;
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.FormClosing += FormNovaConta_FormClosing;

            // Eventos de validação
            txtNumeroConta.TextChanged += ValidarCampos;
            cmbTipo.SelectedIndexChanged += ValidarCampos;
            cmbCliente.SelectedIndexChanged += ValidarCampos;
        }

        private void CarregarClientes()
        {
            try
            {
                _clientesDisponiveis = _clienteService.BuscarTodos().Where(c => c.Ativo).ToList();

                cmbCliente.Items.Clear();
                cmbCliente.Items.AddRange(_clientesDisponiveis.Select(c => $"{c.Nome} ({c.Cpf})").ToArray());

                if (cmbCliente.Items.Count > 0)
                {
                    cmbCliente.SelectedIndex = 0;
                    btnSalvar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Não há clientes ativos disponíveis para criar contas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSalvar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalvar.Enabled = false;
            }
        }

        private void GerarNumeroConta()
        {
            try
            {
                string numeroConta;
                Random random = new Random();
                int tentativas = 0;
                const int maxTentativas = 100; // Evitar loop infinito

                do
                {
                    // Gerar número da conta no formato "0001-1"
                    int parte1 = random.Next(1, 10000); // 1 a 9999
                    int parte2 = random.Next(1, 10);    // 1 a 9

                    numeroConta = $"{parte1:D4}-{parte2}";
                    tentativas++;

                    // Verificar se já existe
                    if (tentativas >= maxTentativas)
                    {
                        MessageBox.Show("Não foi possível gerar um número de conta único após várias tentativas. Tente novamente.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                } while (_contaService.BuscarPorNumeroConta(numeroConta) != null);

                txtNumeroConta.Text = numeroConta;
                txtNumeroConta.Enabled = false; // Desabilitar edição do número da conta
                txtNumeroConta.BackColor = Color.LightGray; // Visual indicando que é somente leitura
                txtNumeroConta.ReadOnly = true; // Garantir que é somente leitura
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar número da conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDadosConta()
        {
            if (_contaEditando != null)
            {
                try
                {
                    txtNumeroConta.Text = _contaEditando.NumeroConta;
                    cmbTipo.SelectedItem = _contaEditando.Tipo;
                    chkAtiva.Checked = _contaEditando.Ativa;

                    // Selecionar o cliente correto
                    var clienteIndex = _clientesDisponiveis.FindIndex(c => c.Id == _contaEditando.ClienteId);
                    if (clienteIndex >= 0)
                    {
                        cmbCliente.SelectedIndex = clienteIndex;
                    }
                    else
                    {
                        MessageBox.Show("Cliente associado à conta não foi encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Desabilitar edição de campos que não devem ser alterados
                    txtNumeroConta.Enabled = false;
                    txtNumeroConta.BackColor = Color.LightGray;
                    txtNumeroConta.ReadOnly = true;
                    cmbCliente.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados da conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Erro: Conta para edição não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            bool camposValidos = cmbTipo.SelectedItem != null &&
                                cmbCliente.SelectedItem != null &&
                                _clientesDisponiveis.Count > 0 &&
                                !string.IsNullOrWhiteSpace(txtNumeroConta.Text);

            btnSalvar.Enabled = camposValidos;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarFormulario())
                {
                    Cursor = Cursors.WaitCursor;

                    if (_isEditMode)
                    {
                        AtualizarConta();
                    }
                    else
                    {
                        CriarNovaConta();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidarFormulario()
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtNumeroConta.Text))
            {
                MessageBox.Show("Número da conta é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroConta.Focus();
                return false;
            }

            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Tipo de conta é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipo.Focus();
                return false;
            }

            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Cliente é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return false;
            }

            if (_clientesDisponiveis.Count == 0)
            {
                MessageBox.Show("Não há clientes disponíveis para criar contas.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CriarNovaConta()
        {
            try
            {
                var clienteSelecionado = _clientesDisponiveis[cmbCliente.SelectedIndex];

                var novaConta = new Conta
                {
                    NumeroConta = txtNumeroConta.Text.Trim(),
                    Tipo = cmbTipo.SelectedItem.ToString(),
                    ClienteId = clienteSelecionado.Id,
                    Ativa = chkAtiva.Checked,
                    DataAbertura = DateTime.Now,
                    Saldo = 0.00m
                };

                int id = _contaService.CriarConta(novaConta);

                MessageBox.Show(
                    $"Conta '{novaConta.NumeroConta}' criada com sucesso!\nID: {id}",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarConta()
        {
            if (_contaEditando != null)
            {
                try
                {
                    _contaEditando.Tipo = cmbTipo.SelectedItem.ToString();
                    _contaEditando.Ativa = chkAtiva.Checked;

                    _contaService.AtualizarConta(_contaEditando);

                    MessageBox.Show(
                        $"Conta '{_contaEditando.NumeroConta}' atualizada com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Erro: Conta para edição não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Tem certeza que deseja cancelar?\nTodas as alterações serão perdidas.",
                "Confirmar Cancelamento",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FormNovaConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
