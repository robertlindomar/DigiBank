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
    public partial class FormNovoTerminal : Form
    {
        private TerminalPosService _terminalService;
        private ContaService _contaService;
        private ClienteService _clienteService;
        private TerminalPos _terminalEditando;
        private bool _modoEdicao;
        private List<Cliente> _clientesDisponiveis;
        private List<Conta> _contasDisponiveis;

        public FormNovoTerminal()
        {
            InitializeComponent();
            _modoEdicao = false;
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarContas();
        }

        public FormNovoTerminal(TerminalPos terminal)
        {
            InitializeComponent();
            _terminalEditando = terminal;
            _modoEdicao = true;
            InicializarServicos();
            ConfigurarInterface();
            ConfigurarEventos();
            CarregarContas();
            PreencherDadosParaEdicao();
        }

        private void InicializarServicos()
        {
            _terminalService = new TerminalPosService();
            _contaService = new ContaService();
            _clienteService = new ClienteService();
            _clientesDisponiveis = new List<Cliente>();
            _contasDisponiveis = new List<Conta>();
        }

        private void ConfigurarInterface()
        {
            // Configurar título da janela
            this.Text = _modoEdicao ? "Editar Terminal POS" : "Novo Terminal POS";
            lblTitulo.Text = _modoEdicao ? "Editar Terminal POS" : "Novo Terminal POS";

            // Configurar combobox de contas
            cmbConta.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar checkbox de status
            chkAtivo.Checked = true;

            // Configurar campos obrigatórios (serão validados via eventos)
            // txtNome, txtNomeLoja, txtLocalizacao, txtUid, cmbConta são obrigatórios

            // Configurar botões
            btnSalvar.Text = _modoEdicao ? "Atualizar" : "Criar";
            btnCancelar.Text = "Cancelar";

            // Configurar placeholders personalizados
            ConfigurarPlaceholders();

            // Configurar validações
            ConfigurarValidacoes();
        }

        private void ConfigurarPlaceholders()
        {
            // Configurar placeholders personalizados para .NET Framework 4.8
            ConfigurarPlaceholder(txtNomeLoja, "Digite o nome da loja");
            ConfigurarPlaceholder(txtLocalizacao, "Digite a localização do terminal");
            ConfigurarPlaceholder(txtUid, "Digite o UID único do terminal");
        }

        private void ConfigurarPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Tag = placeholder; // Armazenar o placeholder no Tag

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void ConfigurarValidacoes()
        {
            // Validação de campos obrigatórios
            txtNomeLoja.Validating += (s, e) => ValidarCampoObrigatorio(txtNomeLoja, e);
            txtLocalizacao.Validating += (s, e) => ValidarCampoObrigatorio(txtLocalizacao, e);
            txtUid.Validating += (s, e) => ValidarCampoObrigatorio(txtUid, e);
            cmbConta.Validating += (s, e) => ValidarCampoObrigatorio(cmbConta, e);

            // Validação de comprimento mínimo
            txtNomeLoja.Validating += (s, e) => ValidarComprimentoMinimo(txtNomeLoja, e, 3, "Nome da loja");
            txtLocalizacao.Validating += (s, e) => ValidarComprimentoMinimo(txtLocalizacao, e, 3, "Localização");
            txtUid.Validating += (s, e) => ValidarComprimentoMinimo(txtUid, e, 5, "UID");
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.FormClosing += FormNovoTerminal_FormClosing;
        }

        private void CarregarContas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Carregar clientes ativos que têm contas
                _clientesDisponiveis = _clienteService.BuscarTodos().Where(c => c.Ativo).ToList();
                _contasDisponiveis = _contaService.BuscarTodas();

                cmbConta.Items.Clear();
                cmbConta.Items.Add(new ComboBoxItem { Text = "Selecione um cliente", Value = 0 });

                // Agrupar contas por cliente para mostrar de forma organizada
                foreach (var cliente in _clientesDisponiveis)
                {
                    var contasDoCliente = _contasDisponiveis.Where(c => c.ClienteId == cliente.Id && c.Ativa).ToList();

                    foreach (var conta in contasDoCliente)
                    {
                        cmbConta.Items.Add(new ComboBoxItem
                        {
                            Text = $"{cliente.Nome} - Conta {conta.NumeroConta} ({conta.Tipo}) - R$ {conta.Saldo:F2}",
                            Value = conta.Id
                        });
                    }
                }

                if (_modoEdicao && _terminalEditando != null)
                {
                    // Selecionar a conta atual do terminal
                    for (int i = 0; i < cmbConta.Items.Count; i++)
                    {
                        var item = cmbConta.Items[i] as ComboBoxItem;
                        if (item != null && item.Value == _terminalEditando.ContaId)
                        {
                            cmbConta.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbConta.SelectedIndex = 0;
                }
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

        private void PreencherDadosParaEdicao()
        {
            if (_terminalEditando != null)
            {
                // Preencher campos com dados do terminal, mas apenas se não estiverem vazios
                if (!string.IsNullOrWhiteSpace(_terminalEditando.NomeLoja))
                {
                    txtNomeLoja.Text = _terminalEditando.NomeLoja;
                    txtNomeLoja.ForeColor = Color.Black;
                }

                if (!string.IsNullOrWhiteSpace(_terminalEditando.Localizacao))
                {
                    txtLocalizacao.Text = _terminalEditando.Localizacao;
                    txtLocalizacao.ForeColor = Color.Black;
                }

                if (!string.IsNullOrWhiteSpace(_terminalEditando.Uid))
                {
                    txtUid.Text = _terminalEditando.Uid;
                    txtUid.ForeColor = Color.Black;
                }

                chkAtivo.Checked = _terminalEditando.Ativo;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                Cursor = Cursors.WaitCursor;

                var contaId = ObterContaIdSelecionada();
                var conta = _contasDisponiveis.FirstOrDefault(c => c.Id == contaId);
                if (conta == null)
                {
                    MessageBox.Show("Conta selecionada não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cliente = _clientesDisponiveis.FirstOrDefault(c => c.Id == conta.ClienteId);
                if (cliente == null)
                {
                    MessageBox.Show("Cliente da conta selecionada não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var terminal = new TerminalPos
                {
                    Nome = $"Terminal {cliente.Nome}",
                    NomeLoja = txtNomeLoja.Text.Trim(),
                    Localizacao = txtLocalizacao.Text.Trim(),
                    Uid = txtUid.Text.Trim(),
                    ContaId = contaId,
                    Ativo = chkAtivo.Checked
                };

                if (_modoEdicao)
                {
                    terminal.Id = _terminalEditando.Id;
                    _terminalService.AtualizarTerminal(terminal);
                    MessageBox.Show("Terminal atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int novoId = _terminalService.CriarTerminal(terminal);
                    MessageBox.Show($"Terminal criado com sucesso! ID: {novoId}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar terminal: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormNovoTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private bool ValidarFormulario()
        {
            // Validar campos obrigatórios (verificar se não são placeholders)
            if (string.IsNullOrWhiteSpace(txtNomeLoja.Text.Trim()) || txtNomeLoja.Text.Trim() == txtNomeLoja.Tag?.ToString())
            {
                MessageBox.Show("Nome da loja é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeLoja.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocalizacao.Text.Trim()) || txtLocalizacao.Text.Trim() == txtLocalizacao.Tag?.ToString())
            {
                MessageBox.Show("Localização é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocalizacao.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUid.Text.Trim()) || txtUid.Text.Trim() == txtUid.Tag?.ToString())
            {
                MessageBox.Show("UID é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUid.Focus();
                return false;
            }

            if (cmbConta.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um cliente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbConta.Focus();
                return false;
            }

            // Validar comprimentos mínimos
            if (txtNomeLoja.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nome da loja deve ter pelo menos 3 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeLoja.Focus();
                return false;
            }

            if (txtLocalizacao.Text.Trim().Length < 3)
            {
                MessageBox.Show("Localização deve ter pelo menos 3 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocalizacao.Focus();
                return false;
            }

            if (txtUid.Text.Trim().Length < 5)
            {
                MessageBox.Show("UID deve ter pelo menos 5 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUid.Focus();
                return false;
            }

            return true;
        }

        private int ObterContaIdSelecionada()
        {
            var itemSelecionado = cmbConta.SelectedItem as ComboBoxItem;
            if (itemSelecionado == null || itemSelecionado.Value == 0)
            {
                throw new InvalidOperationException("Nenhum cliente selecionado.");
            }
            return itemSelecionado.Value;
        }

        private void ValidarCampoObrigatorio(Control control, CancelEventArgs e)
        {
            if (control is TextBox textBox && (string.IsNullOrWhiteSpace(textBox.Text.Trim()) || textBox.Text.Trim() == textBox.Tag?.ToString()))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Campo obrigatório");
            }
            else if (control is ComboBox comboBox && comboBox.SelectedIndex <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Selecione um cliente");
            }
            else
            {
                errorProvider.SetError(control, "");
            }
        }

        private void ValidarComprimentoMinimo(TextBox textBox, CancelEventArgs e, int comprimentoMinimo, string nomeCampo)
        {
            // Não validar se for placeholder
            if (textBox.Text.Trim() == textBox.Tag?.ToString())
                return;

            if (textBox.Text.Trim().Length < comprimentoMinimo)
            {
                e.Cancel = true;
                errorProvider.SetError(textBox, $"{nomeCampo} deve ter pelo menos {comprimentoMinimo} caracteres");
            }
            else
            {
                errorProvider.SetError(textBox, "");
            }
        }
    }

    // Classe auxiliar para combobox
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
