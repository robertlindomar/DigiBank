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
    public partial class FormNovoCartao : Form
    {
        private CartaoService _cartaoService;
        private ContaService _contaService;
        private bool _isEditMode = false;
        private CartaoNfc _cartaoEditando = null;
        private List<Conta> _contasDisponiveis;

        public FormNovoCartao()
        {
            InitializeComponent();
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarContas();
        }

        public FormNovoCartao(CartaoNfc cartaoParaEditar)
        {
            InitializeComponent();
            _isEditMode = true;
            _cartaoEditando = cartaoParaEditar;
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarContas();
            CarregarDadosCartao();
        }

        private void InicializarServicos()
        {
            _cartaoService = new CartaoService();
            _contaService = new ContaService();
            _contasDisponiveis = new List<Conta>();
        }

        private void ConfigurarInterface()
        {
            // Configurar título e botões baseado no modo
            if (_isEditMode)
            {
                this.Text = "Editar Cartão NFC";
                lblTitulo.Text = "Editar Cartão NFC";
                btnSalvar.Text = "Atualizar";
                btnCancelar.Text = "Cancelar";
            }
            else
            {
                this.Text = "Novo Cartão NFC";
                lblTitulo.Text = "Novo Cartão NFC";
                btnSalvar.Text = "Cadastrar";
                btnCancelar.Text = "Cancelar";

                // Gerar UID automaticamente
                GerarUid();
            }

            // Configurar checkbox de ativo
            chkAtivo.Checked = true;

            // Configurar validações
            txtUid.MaxLength = 50;
            txtApelido.MaxLength = 100;
            txtPin.MaxLength = 6;
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.FormClosing += FormNovoCartao_FormClosing;

            // Eventos de validação
            txtUid.TextChanged += ValidarCampos;
            txtApelido.TextChanged += ValidarCampos;
            txtPin.TextChanged += ValidarCampos;
            cmbConta.SelectedIndexChanged += ValidarCampos;
        }

        private void CarregarContas()
        {
            try
            {
                _contasDisponiveis = _contaService.BuscarTodas().Where(c => c.Ativa).ToList();

                cmbConta.Items.Clear();
                cmbConta.Items.AddRange(_contasDisponiveis.Select(c => $"{c.NumeroConta} - {c.Cliente?.Nome ?? "Cliente não encontrado"}").ToArray());

                if (cmbConta.Items.Count > 0)
                {
                    cmbConta.SelectedIndex = 0;
                    btnSalvar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Não há contas ativas disponíveis para vincular cartões.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSalvar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalvar.Enabled = false;
            }
        }

        private void GerarUid()
        {
            try
            {
                // Gerar UID único baseado em timestamp e random
                var timestamp = DateTime.Now.Ticks % 1000000000;
                var random = new Random();
                var randomPart = random.Next(1000, 9999);

                var uid = $"NFC{timestamp:D9}{randomPart:D4}";

                txtUid.Text = uid;
                txtUid.Enabled = false;
                txtUid.BackColor = Color.LightGray;
                txtUid.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar UID: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDadosCartao()
        {
            if (_cartaoEditando != null)
            {
                try
                {
                    txtUid.Text = _cartaoEditando.Uid;
                    txtApelido.Text = _cartaoEditando.Apelido;
                    txtPin.Text = "******"; // Não mostrar PIN atual
                    chkAtivo.Checked = _cartaoEditando.Ativo;

                    // Selecionar a conta correta
                    var contaIndex = _contasDisponiveis.FindIndex(c => c.Id == _cartaoEditando.ContaId);
                    if (contaIndex >= 0)
                    {
                        cmbConta.SelectedIndex = contaIndex;
                    }
                    else
                    {
                        MessageBox.Show("Conta associada ao cartão não foi encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Desabilitar edição de campos que não devem ser alterados
                    txtUid.Enabled = false;
                    txtUid.BackColor = Color.LightGray;
                    txtUid.ReadOnly = true;
                    cmbConta.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados do cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Erro: Cartão para edição não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            bool camposValidos = !string.IsNullOrWhiteSpace(txtUid.Text) &&
                                !string.IsNullOrWhiteSpace(txtApelido.Text) &&
                                !string.IsNullOrWhiteSpace(txtPin.Text) &&
                                cmbConta.SelectedItem != null &&
                                _contasDisponiveis.Count > 0;

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
                        AtualizarCartao();
                    }
                    else
                    {
                        CriarNovoCartao();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidarFormulario()
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtUid.Text))
            {
                MessageBox.Show("UID do cartão é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUid.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApelido.Text))
            {
                MessageBox.Show("Apelido do cartão é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApelido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPin.Text))
            {
                MessageBox.Show("PIN do cartão é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPin.Focus();
                return false;
            }

            if (txtPin.Text.Length < 4)
            {
                MessageBox.Show("PIN deve ter pelo menos 4 dígitos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPin.Focus();
                return false;
            }

            if (cmbConta.SelectedItem == null)
            {
                MessageBox.Show("Conta é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbConta.Focus();
                return false;
            }

            if (_contasDisponiveis.Count == 0)
            {
                MessageBox.Show("Não há contas disponíveis para vincular cartões.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CriarNovoCartao()
        {
            try
            {
                var contaSelecionada = _contasDisponiveis[cmbConta.SelectedIndex];

                var novoCartao = new CartaoNfc
                {
                    Uid = txtUid.Text.Trim(),
                    Apelido = txtApelido.Text.Trim(),
                    PinHash = BCrypt.Net.BCrypt.HashPassword(txtPin.Text.Trim()),
                    ContaId = contaSelecionada.Id,
                    Ativo = chkAtivo.Checked,
                    DataVinculacao = DateTime.Now
                };

                int id = _cartaoService.CriarCartao(novoCartao);

                MessageBox.Show(
                    $"Cartão '{novoCartao.Apelido}' criado com sucesso!\nID: {id}",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarCartao()
        {
            if (_cartaoEditando != null)
            {
                try
                {
                    _cartaoEditando.Apelido = txtApelido.Text.Trim();
                    _cartaoEditando.Ativo = chkAtivo.Checked;

                    // Atualizar PIN apenas se foi alterado
                    if (txtPin.Text != "******")
                    {
                        _cartaoEditando.PinHash = BCrypt.Net.BCrypt.HashPassword(txtPin.Text.Trim());
                    }

                    _cartaoService.AtualizarCartao(_cartaoEditando);

                    MessageBox.Show(
                        $"Cartão '{_cartaoEditando.Apelido}' atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar cartão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Erro: Cartão para edição não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormNovoCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
