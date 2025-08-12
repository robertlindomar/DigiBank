namespace DigiBank.views
{
    partial class Transacoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnNotificacao = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSaldoLiquido = new System.Windows.Forms.Panel();
            this.lblSaldoLiquido = new System.Windows.Forms.Label();
            this.lblTituloSaldoLiquido = new System.Windows.Forms.Label();
            this.panelTotalSaidas = new System.Windows.Forms.Panel();
            this.lblTotalSaidas = new System.Windows.Forms.Label();
            this.lblTituloTotalSaidas = new System.Windows.Forms.Label();
            this.panelTotalEntradas = new System.Windows.Forms.Panel();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.lblTituloTotalEntradas = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnMaisFiltros = new System.Windows.Forms.Button();
            this.cmbTipoTransacao = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTituloFiltros = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblContadorTransacoes = new System.Windows.Forms.Label();
            this.lblTituloTabela = new System.Windows.Forms.Label();
            this.dgvTransacoes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSaldoLiquido.SuspendLayout();
            this.panelTotalSaidas.SuspendLayout();
            this.panelTotalEntradas.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.btnNotificacao);
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnExportar.Location = new System.Drawing.Point(750, 32);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 40);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "📥 Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnNotificacao
            // 
            this.btnNotificacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotificacao.BackColor = System.Drawing.Color.White;
            this.btnNotificacao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnNotificacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotificacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnNotificacao.Location = new System.Drawing.Point(870, 32);
            this.btnNotificacao.Name = "btnNotificacao";
            this.btnNotificacao.Size = new System.Drawing.Size(40, 40);
            this.btnNotificacao.TabIndex = 2;
            this.btnNotificacao.Text = "🔔";
            this.btnNotificacao.UseVisualStyleBackColor = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(33, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(276, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Histórico completo de movimentações";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(33, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Transações";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel2.Controls.Add(this.panelSaldoLiquido);
            this.panel2.Controls.Add(this.panelTotalSaidas);
            this.panel2.Controls.Add(this.panelTotalEntradas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(32);
            this.panel2.Size = new System.Drawing.Size(950, 140);
            this.panel2.TabIndex = 1;
            // 
            // panelSaldoLiquido
            // 
            this.panelSaldoLiquido.BackColor = System.Drawing.Color.White;
            this.panelSaldoLiquido.Controls.Add(this.lblSaldoLiquido);
            this.panelSaldoLiquido.Controls.Add(this.lblTituloSaldoLiquido);
            this.panelSaldoLiquido.Location = new System.Drawing.Point(626, 32);
            this.panelSaldoLiquido.Name = "panelSaldoLiquido";
            this.panelSaldoLiquido.Size = new System.Drawing.Size(296, 76);
            this.panelSaldoLiquido.TabIndex = 2;
            // 
            // lblSaldoLiquido
            // 
            this.lblSaldoLiquido.AutoSize = true;
            this.lblSaldoLiquido.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoLiquido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblSaldoLiquido.Location = new System.Drawing.Point(24, 32);
            this.lblSaldoLiquido.Name = "lblSaldoLiquido";
            this.lblSaldoLiquido.Size = new System.Drawing.Size(168, 37);
            this.lblSaldoLiquido.TabIndex = 1;
            this.lblSaldoLiquido.Text = "R$ 1.108,60";
            // 
            // lblTituloSaldoLiquido
            // 
            this.lblTituloSaldoLiquido.AutoSize = true;
            this.lblTituloSaldoLiquido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSaldoLiquido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloSaldoLiquido.Location = new System.Drawing.Point(24, 12);
            this.lblTituloSaldoLiquido.Name = "lblTituloSaldoLiquido";
            this.lblTituloSaldoLiquido.Size = new System.Drawing.Size(91, 19);
            this.lblTituloSaldoLiquido.TabIndex = 0;
            this.lblTituloSaldoLiquido.Text = "Saldo Líquido";
            // 
            // panelTotalSaidas
            // 
            this.panelTotalSaidas.BackColor = System.Drawing.Color.White;
            this.panelTotalSaidas.Controls.Add(this.lblTotalSaidas);
            this.panelTotalSaidas.Controls.Add(this.lblTituloTotalSaidas);
            this.panelTotalSaidas.Location = new System.Drawing.Point(324, 32);
            this.panelTotalSaidas.Name = "panelTotalSaidas";
            this.panelTotalSaidas.Size = new System.Drawing.Size(296, 76);
            this.panelTotalSaidas.TabIndex = 1;
            // 
            // lblTotalSaidas
            // 
            this.lblTotalSaidas.AutoSize = true;
            this.lblTotalSaidas.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSaidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTotalSaidas.Location = new System.Drawing.Point(24, 32);
            this.lblTotalSaidas.Name = "lblTotalSaidas";
            this.lblTotalSaidas.Size = new System.Drawing.Size(145, 37);
            this.lblTotalSaidas.TabIndex = 1;
            this.lblTotalSaidas.Text = "R$ 591,40";
            // 
            // lblTituloTotalSaidas
            // 
            this.lblTituloTotalSaidas.AutoSize = true;
            this.lblTituloTotalSaidas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalSaidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTotalSaidas.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTotalSaidas.Name = "lblTituloTotalSaidas";
            this.lblTituloTotalSaidas.Size = new System.Drawing.Size(99, 19);
            this.lblTituloTotalSaidas.TabIndex = 0;
            this.lblTituloTotalSaidas.Text = "Total de Saídas";
            // 
            // panelTotalEntradas
            // 
            this.panelTotalEntradas.BackColor = System.Drawing.Color.White;
            this.panelTotalEntradas.Controls.Add(this.lblTotalEntradas);
            this.panelTotalEntradas.Controls.Add(this.lblTituloTotalEntradas);
            this.panelTotalEntradas.Location = new System.Drawing.Point(22, 32);
            this.panelTotalEntradas.Name = "panelTotalEntradas";
            this.panelTotalEntradas.Size = new System.Drawing.Size(296, 76);
            this.panelTotalEntradas.TabIndex = 0;
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.AutoSize = true;
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalEntradas.Location = new System.Drawing.Point(24, 32);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(168, 37);
            this.lblTotalEntradas.TabIndex = 1;
            this.lblTotalEntradas.Text = "R$ 1.700,00";
            // 
            // lblTituloTotalEntradas
            // 
            this.lblTituloTotalEntradas.AutoSize = true;
            this.lblTituloTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTotalEntradas.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTotalEntradas.Name = "lblTituloTotalEntradas";
            this.lblTituloTotalEntradas.Size = new System.Drawing.Size(114, 19);
            this.lblTituloTotalEntradas.TabIndex = 0;
            this.lblTituloTotalEntradas.Text = "Total de Entradas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.panelFiltros);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 240);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(32, 0, 32, 32);
            this.panel3.Size = new System.Drawing.Size(950, 460);
            this.panel3.TabIndex = 2;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnMaisFiltros);
            this.panelFiltros.Controls.Add(this.cmbTipoTransacao);
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.lblTituloFiltros);
            this.panelFiltros.Location = new System.Drawing.Point(32, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(886, 120);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnMaisFiltros
            // 
            this.btnMaisFiltros.BackColor = System.Drawing.Color.White;
            this.btnMaisFiltros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnMaisFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaisFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaisFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnMaisFiltros.Location = new System.Drawing.Point(742, 74);
            this.btnMaisFiltros.Name = "btnMaisFiltros";
            this.btnMaisFiltros.Size = new System.Drawing.Size(120, 32);
            this.btnMaisFiltros.TabIndex = 3;
            this.btnMaisFiltros.Text = "🔍 Mais Filtros";
            this.btnMaisFiltros.UseVisualStyleBackColor = false;
            // 
            // cmbTipoTransacao
            // 
            this.cmbTipoTransacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTransacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoTransacao.FormattingEnabled = true;
            this.cmbTipoTransacao.Items.AddRange(new object[] {
            "Todas",
            "Depósitos",
            "Saques",
            "Transferências"});
            this.cmbTipoTransacao.Location = new System.Drawing.Point(586, 79);
            this.cmbTipoTransacao.Name = "cmbTipoTransacao";
            this.cmbTipoTransacao.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoTransacao.TabIndex = 2;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.txtBuscar.Location = new System.Drawing.Point(24, 79);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(556, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Text = "🔍 Buscar transações...";
            // 
            // lblTituloFiltros
            // 
            this.lblTituloFiltros.AutoSize = true;
            this.lblTituloFiltros.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloFiltros.Location = new System.Drawing.Point(24, 24);
            this.lblTituloFiltros.Name = "lblTituloFiltros";
            this.lblTituloFiltros.Size = new System.Drawing.Size(67, 25);
            this.lblTituloFiltros.TabIndex = 0;
            this.lblTituloFiltros.Text = "Filtros";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblContadorTransacoes);
            this.panel4.Controls.Add(this.lblTituloTabela);
            this.panel4.Controls.Add(this.dgvTransacoes);
            this.panel4.Location = new System.Drawing.Point(32, 140);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 288);
            this.panel4.TabIndex = 0;
            // 
            // lblContadorTransacoes
            // 
            this.lblContadorTransacoes.AutoSize = true;
            this.lblContadorTransacoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorTransacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblContadorTransacoes.Location = new System.Drawing.Point(24, 52);
            this.lblContadorTransacoes.Name = "lblContadorTransacoes";
            this.lblContadorTransacoes.Size = new System.Drawing.Size(165, 19);
            this.lblContadorTransacoes.TabIndex = 2;
            this.lblContadorTransacoes.Text = "8 transações encontradas";
            // 
            // lblTituloTabela
            // 
            this.lblTituloTabela.AutoSize = true;
            this.lblTituloTabela.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloTabela.Location = new System.Drawing.Point(24, 24);
            this.lblTituloTabela.Name = "lblTituloTabela";
            this.lblTituloTabela.Size = new System.Drawing.Size(222, 25);
            this.lblTituloTabela.TabIndex = 1;
            this.lblTituloTabela.Text = "Histórico de Transações";
            // 
            // dgvTransacoes
            // 
            this.dgvTransacoes.AllowUserToAddRows = false;
            this.dgvTransacoes.AllowUserToDeleteRows = false;
            this.dgvTransacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransacoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacoes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvTransacoes.Location = new System.Drawing.Point(24, 80);
            this.dgvTransacoes.Name = "dgvTransacoes";
            this.dgvTransacoes.ReadOnly = true;
            this.dgvTransacoes.RowHeadersVisible = false;
            this.dgvTransacoes.RowTemplate.Height = 25;
            this.dgvTransacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransacoes.Size = new System.Drawing.Size(838, 184);
            this.dgvTransacoes.TabIndex = 0;
            // 
            // Transacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Transacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transações";
            this.Load += new System.EventHandler(this.Transacoes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelSaldoLiquido.ResumeLayout(false);
            this.panelSaldoLiquido.PerformLayout();
            this.panelTotalSaidas.ResumeLayout(false);
            this.panelTotalSaidas.PerformLayout();
            this.panelTotalEntradas.ResumeLayout(false);
            this.panelTotalEntradas.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNotificacao;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTotalEntradas;
        private System.Windows.Forms.Label lblTituloTotalEntradas;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Panel panelTotalSaidas;
        private System.Windows.Forms.Label lblTituloTotalSaidas;
        private System.Windows.Forms.Label lblTotalSaidas;
        private System.Windows.Forms.Panel panelSaldoLiquido;
        private System.Windows.Forms.Label lblTituloSaldoLiquido;
        private System.Windows.Forms.Label lblSaldoLiquido;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblTituloFiltros;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbTipoTransacao;
        private System.Windows.Forms.Button btnMaisFiltros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTituloTabela;
        private System.Windows.Forms.Label lblContadorTransacoes;
        private System.Windows.Forms.DataGridView dgvTransacoes;
    }
}
