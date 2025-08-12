namespace DigiBank.views
{
    partial class Cartoes
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
            this.btnAdicionarCartao = new System.Windows.Forms.Button();
            this.btnNotificacao = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelUltimoUso = new System.Windows.Forms.Panel();
            this.lblUltimoUso = new System.Windows.Forms.Label();
            this.lblTituloUltimoUso = new System.Windows.Forms.Label();
            this.panelCartoesAtivos = new System.Windows.Forms.Panel();
            this.lblCartoesAtivos = new System.Windows.Forms.Label();
            this.lblTituloCartoesAtivos = new System.Windows.Forms.Label();
            this.panelTotalCartoes = new System.Windows.Forms.Panel();
            this.lblTotalCartoes = new System.Windows.Forms.Label();
            this.lblTituloTotalCartoes = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBarCartoes = new System.Windows.Forms.ProgressBar();
            this.lblCartoesInativos = new System.Windows.Forms.Label();
            this.lblTituloTabela = new System.Windows.Forms.Label();
            this.dgvCartoes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelUltimoUso.SuspendLayout();
            this.panelCartoesAtivos.SuspendLayout();
            this.panelTotalCartoes.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnAdicionarCartao);
            this.panel1.Controls.Add(this.btnNotificacao);
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnAdicionarCartao
            // 
            this.btnAdicionarCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarCartao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAdicionarCartao.FlatAppearance.BorderSize = 0;
            this.btnAdicionarCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarCartao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCartao.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarCartao.Location = new System.Drawing.Point(750, 32);
            this.btnAdicionarCartao.Name = "btnAdicionarCartao";
            this.btnAdicionarCartao.Size = new System.Drawing.Size(160, 40);
            this.btnAdicionarCartao.TabIndex = 3;
            this.btnAdicionarCartao.Text = "➕ Adicionar Cartão";
            this.btnAdicionarCartao.UseVisualStyleBackColor = false;
            this.btnAdicionarCartao.Click += new System.EventHandler(this.btnAdicionarCartao_Click);
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
            this.btnNotificacao.Click += new System.EventHandler(this.btnNotificacao_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(33, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gerencie seus cartões de pagamento sem contato";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(33, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cartões NFC";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel2.Controls.Add(this.panelUltimoUso);
            this.panel2.Controls.Add(this.panelCartoesAtivos);
            this.panel2.Controls.Add(this.panelTotalCartoes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(32);
            this.panel2.Size = new System.Drawing.Size(950, 140);
            this.panel2.TabIndex = 1;
            // 
            // panelUltimoUso
            // 
            this.panelUltimoUso.BackColor = System.Drawing.Color.White;
            this.panelUltimoUso.Controls.Add(this.lblUltimoUso);
            this.panelUltimoUso.Controls.Add(this.lblTituloUltimoUso);
            this.panelUltimoUso.Location = new System.Drawing.Point(626, 32);
            this.panelUltimoUso.Name = "panelUltimoUso";
            this.panelUltimoUso.Size = new System.Drawing.Size(296, 76);
            this.panelUltimoUso.TabIndex = 2;
            // 
            // lblUltimoUso
            // 
            this.lblUltimoUso.AutoSize = true;
            this.lblUltimoUso.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoUso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblUltimoUso.Location = new System.Drawing.Point(24, 32);
            this.lblUltimoUso.Name = "lblUltimoUso";
            this.lblUltimoUso.Size = new System.Drawing.Size(100, 37);
            this.lblUltimoUso.TabIndex = 1;
            this.lblUltimoUso.Text = "Hoje";
            // 
            // lblTituloUltimoUso
            // 
            this.lblTituloUltimoUso.AutoSize = true;
            this.lblTituloUltimoUso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloUltimoUso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloUltimoUso.Location = new System.Drawing.Point(24, 12);
            this.lblTituloUltimoUso.Name = "lblTituloUltimoUso";
            this.lblTituloUltimoUso.Size = new System.Drawing.Size(75, 19);
            this.lblTituloUltimoUso.TabIndex = 0;
            this.lblTituloUltimoUso.Text = "Último Uso";
            // 
            // panelCartoesAtivos
            // 
            this.panelCartoesAtivos.BackColor = System.Drawing.Color.White;
            this.panelCartoesAtivos.Controls.Add(this.lblCartoesAtivos);
            this.panelCartoesAtivos.Controls.Add(this.lblTituloCartoesAtivos);
            this.panelCartoesAtivos.Location = new System.Drawing.Point(324, 32);
            this.panelCartoesAtivos.Name = "panelCartoesAtivos";
            this.panelCartoesAtivos.Size = new System.Drawing.Size(296, 76);
            this.panelCartoesAtivos.TabIndex = 1;
            // 
            // lblCartoesAtivos
            // 
            this.lblCartoesAtivos.AutoSize = true;
            this.lblCartoesAtivos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartoesAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblCartoesAtivos.Location = new System.Drawing.Point(24, 32);
            this.lblCartoesAtivos.Name = "lblCartoesAtivos";
            this.lblCartoesAtivos.Size = new System.Drawing.Size(32, 37);
            this.lblCartoesAtivos.TabIndex = 1;
            this.lblCartoesAtivos.Text = "2";
            // 
            // lblTituloCartoesAtivos
            // 
            this.lblTituloCartoesAtivos.AutoSize = true;
            this.lblTituloCartoesAtivos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCartoesAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloCartoesAtivos.Location = new System.Drawing.Point(24, 12);
            this.lblTituloCartoesAtivos.Name = "lblTituloCartoesAtivos";
            this.lblTituloCartoesAtivos.Size = new System.Drawing.Size(108, 19);
            this.lblTituloCartoesAtivos.TabIndex = 0;
            this.lblTituloCartoesAtivos.Text = "Cartões Ativos";
            // 
            // panelTotalCartoes
            // 
            this.panelTotalCartoes.BackColor = System.Drawing.Color.White;
            this.panelTotalCartoes.Controls.Add(this.lblTotalCartoes);
            this.panelTotalCartoes.Controls.Add(this.lblTituloTotalCartoes);
            this.panelTotalCartoes.Location = new System.Drawing.Point(22, 32);
            this.panelTotalCartoes.Name = "panelTotalCartoes";
            this.panelTotalCartoes.Size = new System.Drawing.Size(296, 76);
            this.panelTotalCartoes.TabIndex = 0;
            // 
            // lblTotalCartoes
            // 
            this.lblTotalCartoes.AutoSize = true;
            this.lblTotalCartoes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTotalCartoes.Location = new System.Drawing.Point(24, 32);
            this.lblTotalCartoes.Name = "lblTotalCartoes";
            this.lblTotalCartoes.Size = new System.Drawing.Size(32, 37);
            this.lblTotalCartoes.TabIndex = 1;
            this.lblTotalCartoes.Text = "3";
            // 
            // lblTituloTotalCartoes
            // 
            this.lblTituloTotalCartoes.AutoSize = true;
            this.lblTituloTotalCartoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTotalCartoes.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTotalCartoes.Name = "lblTituloTotalCartoes";
            this.lblTituloTotalCartoes.Size = new System.Drawing.Size(108, 19);
            this.lblTituloTotalCartoes.TabIndex = 0;
            this.lblTituloTotalCartoes.Text = "Total de Cartões";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 240);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(32);
            this.panel3.Size = new System.Drawing.Size(950, 460);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.progressBarCartoes);
            this.panel4.Controls.Add(this.lblCartoesInativos);
            this.panel4.Controls.Add(this.lblTituloTabela);
            this.panel4.Controls.Add(this.dgvCartoes);
            this.panel4.Location = new System.Drawing.Point(32, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 420);
            this.panel4.TabIndex = 0;
            // 
            // progressBarCartoes
            // 
            this.progressBarCartoes.Location = new System.Drawing.Point(24, 80);
            this.progressBarCartoes.Name = "progressBarCartoes";
            this.progressBarCartoes.Size = new System.Drawing.Size(200, 8);
            this.progressBarCartoes.TabIndex = 3;
            this.progressBarCartoes.Value = 67;
            // 
            // lblCartoesInativos
            // 
            this.lblCartoesInativos.AutoSize = true;
            this.lblCartoesInativos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartoesInativos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCartoesInativos.Location = new System.Drawing.Point(24, 52);
            this.lblCartoesInativos.Name = "lblCartoesInativos";
            this.lblCartoesInativos.Size = new System.Drawing.Size(100, 19);
            this.lblCartoesInativos.TabIndex = 2;
            this.lblCartoesInativos.Text = "1 inativo";
            // 
            // lblTituloTabela
            // 
            this.lblTituloTabela.AutoSize = true;
            this.lblTituloTabela.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloTabela.Location = new System.Drawing.Point(24, 24);
            this.lblTituloTabela.Name = "lblTituloTabela";
            this.lblTituloTabela.Size = new System.Drawing.Size(150, 25);
            this.lblTituloTabela.TabIndex = 1;
            this.lblTituloTabela.Text = "Meus Cartões";
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
            this.dgvCartoes.Location = new System.Drawing.Point(24, 100);
            this.dgvCartoes.Name = "dgvCartoes";
            this.dgvCartoes.ReadOnly = true;
            this.dgvCartoes.RowHeadersVisible = false;
            this.dgvCartoes.RowTemplate.Height = 25;
            this.dgvCartoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartoes.Size = new System.Drawing.Size(838, 300);
            this.dgvCartoes.TabIndex = 0;
            // 
            // Cartoes
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
            this.Name = "Cartoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartões NFC";
            this.Load += new System.EventHandler(this.Cartoes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelUltimoUso.ResumeLayout(false);
            this.panelUltimoUso.PerformLayout();
            this.panelCartoesAtivos.ResumeLayout(false);
            this.panelCartoesAtivos.PerformLayout();
            this.panelTotalCartoes.ResumeLayout(false);
            this.panelTotalCartoes.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoes)).EndInit();
            this.ResumeLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNotificacao;
        private System.Windows.Forms.Button btnAdicionarCartao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTotalCartoes;
        private System.Windows.Forms.Label lblTituloTotalCartoes;
        private System.Windows.Forms.Label lblTotalCartoes;
        private System.Windows.Forms.Panel panelCartoesAtivos;
        private System.Windows.Forms.Label lblTituloCartoesAtivos;
        private System.Windows.Forms.Label lblCartoesAtivos;
        private System.Windows.Forms.Panel panelUltimoUso;
        private System.Windows.Forms.Label lblTituloUltimoUso;
        private System.Windows.Forms.Label lblUltimoUso;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTituloTabela;
        private System.Windows.Forms.Label lblCartoesInativos;
        private System.Windows.Forms.ProgressBar progressBarCartoes;
        private System.Windows.Forms.DataGridView dgvCartoes;
    }
}
