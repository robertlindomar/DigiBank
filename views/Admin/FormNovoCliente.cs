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
    public partial class FormNovoCliente : Form
    {
        private ClienteService _clienteService;
        private bool _isEditMode = false;
        private Cliente _clienteEditando = null;

        public FormNovoCliente()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
        }

        public FormNovoCliente(Cliente clienteParaEditar)
        {
            InitializeComponent();
            _isEditMode = true;
            _clienteEditando = clienteParaEditar;
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarDadosCliente();
        }

        private void InicializarServicos()
        {
            _clienteService = new ClienteService();
        }

        private void ConfigurarInterface()
        {
            // Configurar título e botões baseado no modo
            if (_isEditMode)
            {
                this.Text = "Editar Cliente";
                lblTitulo.Text = "Editar Cliente";
                btnSalvar.Text = "Atualizar";
                btnCancelar.Text = "Cancelar";
            }
            else
            {
                this.Text = "Novo Cliente";
                lblTitulo.Text = "Novo Cliente";
                btnSalvar.Text = "Cadastrar";
                btnCancelar.Text = "Cancelar";
            }

            // Configurar combobox de tipo
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[] { "cliente", "admin" });
            cmbTipo.SelectedIndex = 0;

            // Configurar checkbox de ativo
            chkAtivo.Checked = true;



            // Configurar máscaras
            txtCPF.Mask = "000.000.000-00";
            txtCPF.PromptChar = '_';
            txtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCPF.BeepOnError = true;
            txtCPF.SkipLiterals = true;

            // Configurar validações
            txtNome.MaxLength = 100;
            txtLogin.MaxLength = 50;
            txtSenha.MaxLength = 50;
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.FormClosing += FormNovoCliente_FormClosing;

            // Eventos de validação
            txtNome.TextChanged += ValidarCampos;
            txtCPF.TextChanged += ValidarCampos;
            txtLogin.TextChanged += ValidarCampos;
            txtSenha.TextChanged += ValidarCampos;
        }

        private void CarregarDadosCliente()
        {
            if (_clienteEditando != null)
            {
                txtNome.Text = _clienteEditando.Nome;
                txtCPF.Text = _clienteEditando.Cpf;
                txtLogin.Text = _clienteEditando.Login;
                txtSenha.Text = _clienteEditando.Senha;

                cmbTipo.SelectedItem = _clienteEditando.Tipo;
                chkAtivo.Checked = _clienteEditando.Ativo;

                // Desabilitar edição de campos que não devem ser alterados
                txtCPF.Enabled = false;
                txtLogin.Enabled = false;
            }
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            bool camposValidos = !string.IsNullOrWhiteSpace(txtNome.Text) &&
                                ValidarCPF(txtCPF.Text) &&
                                !string.IsNullOrWhiteSpace(txtLogin.Text) &&
                                !string.IsNullOrWhiteSpace(txtSenha.Text);

            btnSalvar.Enabled = camposValidos;
        }

        private bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            string cpfLimpo = cpf.Replace(".", "").Replace("-", "").Replace("_", "");
            return cpfLimpo.Length == 11 && cpfLimpo.All(char.IsDigit);
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
                        AtualizarCliente();
                    }
                    else
                    {
                        CriarNovoCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidarFormulario()
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("CPF é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Login é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Senha é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            // Validação de CPF (formato básico)
            string cpfLimpo = txtCPF.Text.Replace(".", "").Replace("-", "").Replace("_", "");
            if (cpfLimpo.Length != 11 || !cpfLimpo.All(char.IsDigit))
            {
                MessageBox.Show("CPF deve ter 11 dígitos numéricos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return false;
            }

            // Validação de senha (mínimo 6 caracteres)
            if (txtSenha.Text.Length < 6)
            {
                MessageBox.Show("Senha deve ter pelo menos 6 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            return true;
        }

        private void CriarNovoCliente()
        {
            var novoCliente = new Cliente
            {
                Nome = txtNome.Text.Trim(),
                Cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Replace("_", ""),
                Login = txtLogin.Text.Trim(),
                Senha = txtSenha.Text,
                Tipo = cmbTipo.SelectedItem.ToString(),
                Ativo = chkAtivo.Checked,
                DataCriacao = DateTime.Now
            };

            int id = _clienteService.CadastrarCliente(novoCliente);

            MessageBox.Show(
                $"Cliente '{novoCliente.Nome}' cadastrado com sucesso!\nID: {id}",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AtualizarCliente()
        {
            if (_clienteEditando != null)
            {
                _clienteEditando.Nome = txtNome.Text.Trim();
                _clienteEditando.Senha = txtSenha.Text;
                _clienteEditando.Tipo = cmbTipo.SelectedItem.ToString();
                _clienteEditando.Ativo = chkAtivo.Checked;

                _clienteService.AtualizarCliente(_clienteEditando);

                MessageBox.Show(
                    $"Cliente '{_clienteEditando.Nome}' atualizado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void FormNovoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        // Eventos dos controles (serão implementados no Designer)
        private void txtNome_TextChanged(object sender, EventArgs e) { }
        private void txtCPF_TextChanged(object sender, EventArgs e) { }
        private void txtLogin_TextChanged(object sender, EventArgs e) { }
        private void txtSenha_TextChanged(object sender, EventArgs e) { }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkAtivo_CheckedChanged(object sender, EventArgs e) { }
    }
}
