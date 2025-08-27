namespace DigiBank.views.Admin
{
    partial class CartoesNFC
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
            this.dgvCartoes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNovoCartao = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbTipoClienteAtvInt = new System.Windows.Forms.ComboBox();
            this.cmbTipoClientes = new System.Windows.Forms.ComboBox();
            this.txtBuscarClientes = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bntEditarCartao = new System.Windows.Forms.Button();
            this.btnExcluirCartao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCartoes
            // 
            this.dgvCartoes.AllowUserToAddRows = false;
            this.dgvCartoes.AllowUserToDeleteRows = false;
            this.dgvCartoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCartoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvCartoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCartoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartoes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvCartoes.Location = new System.Drawing.Point(24, 63);
            this.dgvCartoes.Name = "dgvCartoes";
            this.dgvCartoes.ReadOnly = true;
            this.dgvCartoes.RowHeadersVisible = false;
            this.dgvCartoes.RowTemplate.Height = 25;
            this.dgvCartoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartoes.Size = new System.Drawing.Size(838, 432);
            this.dgvCartoes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNovoCartao);
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 100);
            this.panel1.TabIndex = 8;
            // 
            // btnNovoCartao
            // 
            this.btnNovoCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoCartao.BackColor = System.Drawing.Color.Red;
            this.btnNovoCartao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnNovoCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCartao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoCartao.ForeColor = System.Drawing.Color.White;
            this.btnNovoCartao.Location = new System.Drawing.Point(818, 34);
            this.btnNovoCartao.Name = "btnNovoCartao";
            this.btnNovoCartao.Size = new System.Drawing.Size(100, 40);
            this.btnNovoCartao.TabIndex = 4;
            this.btnNovoCartao.Text = "+ Novo Cartão";
            this.btnNovoCartao.UseVisualStyleBackColor = false;
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
            this.lblSubtitulo.Text = "Administre os Cartões NFC do sistema";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(357, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gerenciar Cartões NFC";
            // 
            // cmbTipoClienteAtvInt
            // 
            this.cmbTipoClienteAtvInt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoClienteAtvInt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoClienteAtvInt.FormattingEnabled = true;
            this.cmbTipoClienteAtvInt.Items.AddRange(new object[] {
            "Todas as Contas",
            "Conta Corrente",
            "Conta Poupança"});
            this.cmbTipoClienteAtvInt.Location = new System.Drawing.Point(557, 19);
            this.cmbTipoClienteAtvInt.Name = "cmbTipoClienteAtvInt";
            this.cmbTipoClienteAtvInt.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoClienteAtvInt.TabIndex = 1;
            // 
            // cmbTipoClientes
            // 
            this.cmbTipoClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoClientes.FormattingEnabled = true;
            this.cmbTipoClientes.Items.AddRange(new object[] {
            "Todas",
            "Depósitos",
            "Saques",
            "Transferências"});
            this.cmbTipoClientes.Location = new System.Drawing.Point(713, 19);
            this.cmbTipoClientes.Name = "cmbTipoClientes";
            this.cmbTipoClientes.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoClientes.TabIndex = 2;
            // 
            // txtBuscarClientes
            // 
            this.txtBuscarClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.txtBuscarClientes.Location = new System.Drawing.Point(19, 19);
            this.txtBuscarClientes.Name = "txtBuscarClientes";
            this.txtBuscarClientes.Size = new System.Drawing.Size(520, 23);
            this.txtBuscarClientes.TabIndex = 3;
            this.txtBuscarClientes.Text = "🔍 Buscar Por nome, Cpf ou Login...";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.panelFiltros);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(32, 0, 32, 32);
            this.panel3.Size = new System.Drawing.Size(934, 661);
            this.panel3.TabIndex = 9;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.cmbTipoClienteAtvInt);
            this.panelFiltros.Controls.Add(this.cmbTipoClientes);
            this.panelFiltros.Controls.Add(this.txtBuscarClientes);
            this.panelFiltros.Location = new System.Drawing.Point(32, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(886, 57);
            this.panelFiltros.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.bntEditarCartao);
            this.panel4.Controls.Add(this.btnExcluirCartao);
            this.panel4.Controls.Add(this.dgvCartoes);
            this.panel4.Location = new System.Drawing.Point(32, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 563);
            this.panel4.TabIndex = 0;
            // 
            // bntEditarCartao
            // 
            this.bntEditarCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntEditarCartao.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bntEditarCartao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.bntEditarCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntEditarCartao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntEditarCartao.ForeColor = System.Drawing.Color.White;
            this.bntEditarCartao.Location = new System.Drawing.Point(664, 520);
            this.bntEditarCartao.Name = "bntEditarCartao";
            this.bntEditarCartao.Size = new System.Drawing.Size(100, 40);
            this.bntEditarCartao.TabIndex = 6;
            this.bntEditarCartao.Text = "Editar";
            this.bntEditarCartao.UseVisualStyleBackColor = false;
            // 
            // btnExcluirCartao
            // 
            this.btnExcluirCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirCartao.BackColor = System.Drawing.Color.IndianRed;
            this.btnExcluirCartao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnExcluirCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirCartao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirCartao.ForeColor = System.Drawing.Color.White;
            this.btnExcluirCartao.Location = new System.Drawing.Point(770, 520);
            this.btnExcluirCartao.Name = "btnExcluirCartao";
            this.btnExcluirCartao.Size = new System.Drawing.Size(100, 40);
            this.btnExcluirCartao.TabIndex = 5;
            this.btnExcluirCartao.Text = "Excluir";
            this.btnExcluirCartao.UseVisualStyleBackColor = false;
            // 
            // CartoesNFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "CartoesNFC";
            this.Text = "CartõesNFC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCartoes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNovoCartao;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbTipoClienteAtvInt;
        private System.Windows.Forms.ComboBox cmbTipoClientes;
        private System.Windows.Forms.TextBox txtBuscarClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bntEditarCartao;
        private System.Windows.Forms.Button btnExcluirCartao;
    }
}