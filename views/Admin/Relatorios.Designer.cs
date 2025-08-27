namespace DigiBank.views.Admin
{
    partial class Relatorios
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbTipoClienteAtvInt = new System.Windows.Forms.ComboBox();
            this.cmbTipoClientes = new System.Windows.Forms.ComboBox();
            this.txtBuscarClientes = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTipoTP = new System.Windows.Forms.Label();
            this.lblDataH = new System.Windows.Forms.Label();
            this.lblDadosTPHoje = new System.Windows.Forms.Label();
            this.lblDataES = new System.Windows.Forms.Label();
            this.lblDadosTPSemana = new System.Windows.Forms.Label();
            this.lblDataEM = new System.Windows.Forms.Label();
            this.lblDadosTPMes = new System.Windows.Forms.Label();
            this.lblDadosVFMes = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDadosVFSemana = new System.Windows.Forms.Label();
            this.lblVFSemana = new System.Windows.Forms.Label();
            this.lblDadosVFHoje = new System.Windows.Forms.Label();
            this.lblVFHoje = new System.Windows.Forms.Label();
            this.lblTipoVF = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 100);
            this.panel1.TabIndex = 8;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(33, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(237, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Análises e estatísticas do sistema";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(171, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatórios";
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
            this.panel3.Controls.Add(this.panel2);
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
            this.panel4.Controls.Add(this.lblDadosTPMes);
            this.panel4.Controls.Add(this.lblDataEM);
            this.panel4.Controls.Add(this.lblDadosTPSemana);
            this.panel4.Controls.Add(this.lblDataES);
            this.panel4.Controls.Add(this.lblDadosTPHoje);
            this.panel4.Controls.Add(this.lblDataH);
            this.panel4.Controls.Add(this.lblTipoTP);
            this.panel4.Location = new System.Drawing.Point(11, 106);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(448, 520);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblDadosVFMes);
            this.panel2.Controls.Add(this.lblDadosVFHoje);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblTipoVF);
            this.panel2.Controls.Add(this.lblDadosVFSemana);
            this.panel2.Controls.Add(this.lblVFHoje);
            this.panel2.Controls.Add(this.lblVFSemana);
            this.panel2.Location = new System.Drawing.Point(481, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 520);
            this.panel2.TabIndex = 1;
            // 
            // lblTipoTP
            // 
            this.lblTipoTP.AutoSize = true;
            this.lblTipoTP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTipoTP.Location = new System.Drawing.Point(24, 33);
            this.lblTipoTP.Name = "lblTipoTP";
            this.lblTipoTP.Size = new System.Drawing.Size(221, 25);
            this.lblTipoTP.TabIndex = 0;
            this.lblTipoTP.Text = "Transações por Período";
            // 
            // lblDataH
            // 
            this.lblDataH.AutoSize = true;
            this.lblDataH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataH.Location = new System.Drawing.Point(29, 136);
            this.lblDataH.Name = "lblDataH";
            this.lblDataH.Size = new System.Drawing.Size(37, 19);
            this.lblDataH.TabIndex = 1;
            this.lblDataH.Text = "Hoje";
            // 
            // lblDadosTPHoje
            // 
            this.lblDadosTPHoje.AutoSize = true;
            this.lblDadosTPHoje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosTPHoje.Location = new System.Drawing.Point(354, 136);
            this.lblDadosTPHoje.Name = "lblDadosTPHoje";
            this.lblDadosTPHoje.Size = new System.Drawing.Size(37, 19);
            this.lblDadosTPHoje.TabIndex = 2;
            this.lblDadosTPHoje.Text = "Hoje";
            // 
            // lblDataES
            // 
            this.lblDataES.AutoSize = true;
            this.lblDataES.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataES.Location = new System.Drawing.Point(29, 176);
            this.lblDataES.Name = "lblDataES";
            this.lblDataES.Size = new System.Drawing.Size(86, 19);
            this.lblDataES.TabIndex = 3;
            this.lblDataES.Text = "Esta Semana";
            // 
            // lblDadosTPSemana
            // 
            this.lblDadosTPSemana.AutoSize = true;
            this.lblDadosTPSemana.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosTPSemana.Location = new System.Drawing.Point(354, 176);
            this.lblDadosTPSemana.Name = "lblDadosTPSemana";
            this.lblDadosTPSemana.Size = new System.Drawing.Size(57, 19);
            this.lblDadosTPSemana.TabIndex = 4;
            this.lblDadosTPSemana.Text = "Semana";
            // 
            // lblDataEM
            // 
            this.lblDataEM.AutoSize = true;
            this.lblDataEM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataEM.Location = new System.Drawing.Point(29, 214);
            this.lblDataEM.Name = "lblDataEM";
            this.lblDataEM.Size = new System.Drawing.Size(64, 19);
            this.lblDataEM.TabIndex = 5;
            this.lblDataEM.Text = "Este Mês";
            // 
            // lblDadosTPMes
            // 
            this.lblDadosTPMes.AutoSize = true;
            this.lblDadosTPMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosTPMes.Location = new System.Drawing.Point(354, 214);
            this.lblDadosTPMes.Name = "lblDadosTPMes";
            this.lblDadosTPMes.Size = new System.Drawing.Size(35, 19);
            this.lblDadosTPMes.TabIndex = 6;
            this.lblDadosTPMes.Text = "Mes";
            // 
            // lblDadosVFMes
            // 
            this.lblDadosVFMes.AutoSize = true;
            this.lblDadosVFMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosVFMes.Location = new System.Drawing.Point(366, 214);
            this.lblDadosVFMes.Name = "lblDadosVFMes";
            this.lblDadosVFMes.Size = new System.Drawing.Size(35, 19);
            this.lblDadosVFMes.TabIndex = 13;
            this.lblDadosVFMes.Text = "Mes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(36, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "Volume Mês";
            // 
            // lblDadosVFSemana
            // 
            this.lblDadosVFSemana.AutoSize = true;
            this.lblDadosVFSemana.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosVFSemana.Location = new System.Drawing.Point(358, 176);
            this.lblDadosVFSemana.Name = "lblDadosVFSemana";
            this.lblDadosVFSemana.Size = new System.Drawing.Size(57, 19);
            this.lblDadosVFSemana.TabIndex = 11;
            this.lblDadosVFSemana.Text = "Semana";
            // 
            // lblVFSemana
            // 
            this.lblVFSemana.AutoSize = true;
            this.lblVFSemana.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVFSemana.Location = new System.Drawing.Point(34, 176);
            this.lblVFSemana.Name = "lblVFSemana";
            this.lblVFSemana.Size = new System.Drawing.Size(107, 19);
            this.lblVFSemana.TabIndex = 10;
            this.lblVFSemana.Text = "Volume Semana";
            // 
            // lblDadosVFHoje
            // 
            this.lblDadosVFHoje.AutoSize = true;
            this.lblDadosVFHoje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDadosVFHoje.Location = new System.Drawing.Point(359, 136);
            this.lblDadosVFHoje.Name = "lblDadosVFHoje";
            this.lblDadosVFHoje.Size = new System.Drawing.Size(35, 19);
            this.lblDadosVFHoje.TabIndex = 9;
            this.lblDadosVFHoje.Text = "hoje";
            // 
            // lblVFHoje
            // 
            this.lblVFHoje.AutoSize = true;
            this.lblVFHoje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVFHoje.Location = new System.Drawing.Point(35, 136);
            this.lblVFHoje.Name = "lblVFHoje";
            this.lblVFHoje.Size = new System.Drawing.Size(87, 19);
            this.lblVFHoje.TabIndex = 8;
            this.lblVFHoje.Text = "Volume Hoje";
            // 
            // lblTipoVF
            // 
            this.lblTipoVF.AutoSize = true;
            this.lblTipoVF.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoVF.Location = new System.Drawing.Point(30, 33);
            this.lblTipoVF.Name = "lblTipoVF";
            this.lblTipoVF.Size = new System.Drawing.Size(178, 25);
            this.lblTipoVF.TabIndex = 7;
            this.lblTipoVF.Text = "Volume Financeiro";
            // 
            // Relatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Relatorios";
            this.Text = "Relatórios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbTipoClienteAtvInt;
        private System.Windows.Forms.ComboBox cmbTipoClientes;
        private System.Windows.Forms.TextBox txtBuscarClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDadosTPMes;
        private System.Windows.Forms.Label lblDataEM;
        private System.Windows.Forms.Label lblDadosTPSemana;
        private System.Windows.Forms.Label lblDataES;
        private System.Windows.Forms.Label lblDadosTPHoje;
        private System.Windows.Forms.Label lblDataH;
        private System.Windows.Forms.Label lblTipoTP;
        private System.Windows.Forms.Label lblDadosVFMes;
        private System.Windows.Forms.Label lblDadosVFHoje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTipoVF;
        private System.Windows.Forms.Label lblDadosVFSemana;
        private System.Windows.Forms.Label lblVFHoje;
        private System.Windows.Forms.Label lblVFSemana;
    }
}