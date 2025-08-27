namespace DigiBank.views.Admin
{
    partial class TerminaisPOS
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
            this.btnNovoTerminal = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.cmbTipoClienteAtvInt = new System.Windows.Forms.ComboBox();
            this.cmbTipoClientes = new System.Windows.Forms.ComboBox();
            this.txtBuscarClientes = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bntEditarTerminal = new System.Windows.Forms.Button();
            this.btnExcluirTerminal = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNovoTerminal);
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 100);
            this.panel1.TabIndex = 8;
            // 
            // btnNovoTerminal
            // 
            this.btnNovoTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoTerminal.BackColor = System.Drawing.Color.Red;
            this.btnNovoTerminal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnNovoTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoTerminal.ForeColor = System.Drawing.Color.White;
            this.btnNovoTerminal.Location = new System.Drawing.Point(802, 34);
            this.btnNovoTerminal.Name = "btnNovoTerminal";
            this.btnNovoTerminal.Size = new System.Drawing.Size(116, 40);
            this.btnNovoTerminal.TabIndex = 4;
            this.btnNovoTerminal.Text = "+ Novo Terminal";
            this.btnNovoTerminal.UseVisualStyleBackColor = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(33, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(264, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gerencie os terminais de pagamento";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(234, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Terminais POS";
            // 
            // dgvContas
            // 
            this.dgvContas.AllowUserToAddRows = false;
            this.dgvContas.AllowUserToDeleteRows = false;
            this.dgvContas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContas.BackgroundColor = System.Drawing.Color.White;
            this.dgvContas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvContas.Location = new System.Drawing.Point(24, 63);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.ReadOnly = true;
            this.dgvContas.RowHeadersVisible = false;
            this.dgvContas.RowTemplate.Height = 25;
            this.dgvContas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContas.Size = new System.Drawing.Size(838, 432);
            this.dgvContas.TabIndex = 0;
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
            this.panel4.Controls.Add(this.bntEditarTerminal);
            this.panel4.Controls.Add(this.btnExcluirTerminal);
            this.panel4.Controls.Add(this.dgvContas);
            this.panel4.Location = new System.Drawing.Point(32, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 563);
            this.panel4.TabIndex = 0;
            // 
            // bntEditarTerminal
            // 
            this.bntEditarTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntEditarTerminal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bntEditarTerminal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.bntEditarTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntEditarTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntEditarTerminal.ForeColor = System.Drawing.Color.White;
            this.bntEditarTerminal.Location = new System.Drawing.Point(664, 520);
            this.bntEditarTerminal.Name = "bntEditarTerminal";
            this.bntEditarTerminal.Size = new System.Drawing.Size(100, 40);
            this.bntEditarTerminal.TabIndex = 6;
            this.bntEditarTerminal.Text = "Editar";
            this.bntEditarTerminal.UseVisualStyleBackColor = false;
            // 
            // btnExcluirTerminal
            // 
            this.btnExcluirTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirTerminal.BackColor = System.Drawing.Color.IndianRed;
            this.btnExcluirTerminal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnExcluirTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirTerminal.ForeColor = System.Drawing.Color.White;
            this.btnExcluirTerminal.Location = new System.Drawing.Point(770, 520);
            this.btnExcluirTerminal.Name = "btnExcluirTerminal";
            this.btnExcluirTerminal.Size = new System.Drawing.Size(100, 40);
            this.btnExcluirTerminal.TabIndex = 5;
            this.btnExcluirTerminal.Text = "Excluir";
            this.btnExcluirTerminal.UseVisualStyleBackColor = false;
            // 
            // TerminaisPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "TerminaisPOS";
            this.Text = "TerminaisPOS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNovoTerminal;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.ComboBox cmbTipoClienteAtvInt;
        private System.Windows.Forms.ComboBox cmbTipoClientes;
        private System.Windows.Forms.TextBox txtBuscarClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bntEditarTerminal;
        private System.Windows.Forms.Button btnExcluirTerminal;
    }
}