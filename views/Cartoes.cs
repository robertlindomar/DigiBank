using DigiBank.controllers;
using DigiBank.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiBank.views
{
    public partial class Cartoes : Form
    {
        #region Campos Privados
        private readonly Usuario _usuarioLogado;
        private readonly CartaoController _cartaoController;
        private readonly ContaController _contaController;
        private List<CartaoNfc> _listaCartoes;
        private List<Conta> _listaContas;
        #endregion

        #region Construtores
        public Cartoes()
        {
            InitializeComponent();
            _usuarioLogado = new Usuario();
            _cartaoController = new CartaoController();
            _contaController = new ContaController();
            _listaCartoes = new List<CartaoNfc>();
            _listaContas = new List<Conta>();
        }

        public Cartoes(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogado = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _cartaoController = new CartaoController();
            _contaController = new ContaController();
            _listaCartoes = new List<CartaoNfc>();
            _listaContas = new List<Conta>();

            CarregarDados();
        }
        #endregion

        #region Métodos Privados
        private void CarregarDados()
        {
            try
            {
                CarregarContas();
                CarregarCartoes();
                AtualizarEstatisticas();
                ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarContas()
        {
            _listaContas.Clear();
            var contas = _contaController.BuscarPorClienteId(_usuarioLogado.ClienteId);

            if (contas != null)
            {
                _listaContas.AddRange(contas);
            }
        }

        private void CarregarCartoes()
        {
            _listaCartoes.Clear();

            // TODO: Buscar cartões do banco
            // Por enquanto, criar cartões de exemplo
            CriarCartoesExemplo();
        }

        private void CriarCartoesExemplo()
        {
            var cartoesExemplo = new List<CartaoNfc>
            {
                new CartaoNfc
                {
                    Id = 1,
                    Apelido = "Cartão Principal",
                    Uid = "A1B2C3D4E5F6",
                    Ativo = true,
                    ContaId = 1,
                    DataVinculacao = DateTime.Parse("2024-01-10")
                },
                new CartaoNfc
                {
                    Id = 2,
                    Apelido = "Cartão Backup",
                    Uid = "G7H8I9J0K1L2",
                    Ativo = false,
                    ContaId = 2,
                    DataVinculacao = DateTime.Parse("2024-01-05")
                },
                new CartaoNfc
                {
                    Id = 3,
                    Apelido = "Cartão Família",
                    Uid = "M3N4O5P6Q7R8",
                    Ativo = true,
                    ContaId = 1,
                    DataVinculacao = DateTime.Parse("2024-01-08")
                }
            };

            _listaCartoes.AddRange(cartoesExemplo);
        }

        private void ConfigurarDataGridView()
        {
            dgvCartoes.AutoGenerateColumns = false;
            dgvCartoes.AllowUserToAddRows = false;
            dgvCartoes.AllowUserToDeleteRows = false;
            dgvCartoes.ReadOnly = true;
            dgvCartoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCartoes.RowHeadersVisible = false;
            dgvCartoes.BackgroundColor = Color.White;
            dgvCartoes.BorderStyle = BorderStyle.None;
            dgvCartoes.GridColor = Color.FromArgb(229, 231, 235);

            // Configurar colunas
            dgvCartoes.Columns.Clear();

            // Coluna Nome
            var colNome = new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Apelido",
                DataPropertyName = "Nome",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39)
                }
            };

            // Coluna UID
            var colUID = new DataGridViewTextBoxColumn
            {
                Name = "UID",
                HeaderText = "UID",
                DataPropertyName = "UID",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Consolas", 8),
                    ForeColor = Color.FromArgb(107, 114, 128)
                }
            };

            // Coluna Conta
            var colConta = new DataGridViewTextBoxColumn
            {
                Name = "Conta",
                HeaderText = "Conta",
                DataPropertyName = "ContaId",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(107, 114, 128)
                }
            };

            // Coluna Data Criação
            var colDataCriacao = new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Vinculado em",
                DataPropertyName = "DataCriacao",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Format = "dd/MM/yyyy"
                }
            };

            // Coluna Último Uso
            var colUltimoUso = new DataGridViewTextBoxColumn
            {
                Name = "UltimoUso",
                HeaderText = "Último uso",
                DataPropertyName = "UltimoUso",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(107, 114, 128)
                }
            };

            // Coluna Status
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvCartoes.Columns.AddRange(new DataGridViewColumn[]
            {
                colNome, colUID, colConta, colDataCriacao, colUltimoUso, colStatus
            });

            // Configurar estilo do cabeçalho
            dgvCartoes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvCartoes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            dgvCartoes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCartoes.ColumnHeadersHeight = 40;
            dgvCartoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void AtualizarEstatisticas()
        {
            try
            {
                var totalCartoes = _listaCartoes.Count;
                var cartoesAtivos = _listaCartoes.Count(c => c.Ativo);
                var cartoesInativos = totalCartoes - cartoesAtivos;

                // Atualizar labels
                lblTotalCartoes.Text = totalCartoes.ToString();
                lblCartoesAtivos.Text = cartoesAtivos.ToString();
                lblCartoesInativos.Text = cartoesInativos.ToString();

                // Atualizar progress bar
                if (totalCartoes > 0)
                {
                    int percentual = (cartoesAtivos * 100) / totalCartoes;
                    progressBarCartoes.Value = percentual;
                }

                // Atualizar DataGridView
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar estatísticas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridView()
        {
            try
            {
                // Criar lista de objetos anônimos para o DataGridView
                var dadosParaGrid = _listaCartoes.Select(c =>
{
    var conta = _listaContas.FirstOrDefault(cont => cont.Id == c.ContaId);
    var nomeConta = conta != null ?
        (conta.Tipo == "corrente" ? "Conta Corrente" : "Conta Poupança") :
        "Conta";

    return new
    {
        Nome = c.Apelido,
        UID = c.Uid,
        ContaId = nomeConta,
        DataCriacao = c.DataVinculacao,
        UltimoUso = "Nunca usado", // Como não existe no modelo, vamos usar um valor padrão
        Status = c.Ativo ? "Ativo" : "Inativo"
    };
}).ToList();

                dgvCartoes.DataSource = dadosParaGrid;

                // Aplicar formatação de cores
                foreach (DataGridViewRow row in dgvCartoes.Rows)
                {
                    if (row.DataBoundItem != null)
                    {
                        var status = row.Cells["Status"].Value?.ToString();

                        // Colorir status
                        if (status == "Ativo")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(22, 163, 74);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(220, 252, 231);
                        }
                        else
                        {
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(107, 114, 128);
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(243, 244, 246);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar DataGridView: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers
        private void Cartoes_Load(object sender, EventArgs e)
        {
            // Evento de carregamento do formulário
        }

        private void btnAdicionarCartao_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implementar modal de adicionar cartão
                MessageBox.Show("Funcionalidade de adicionar cartão será implementada em breve!", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cartão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você não tem novas notificações!", "Notificações",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
