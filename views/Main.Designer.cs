namespace DigiBank
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUsuarioLogado = new System.Windows.Forms.Label();
            this.btnTerminalPOS = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnCartoes = new System.Windows.Forms.Button();
            this.btnTransacoes = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.painelPrincipal = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelUsuarioLogado);
            this.panel1.Controls.Add(this.btnTerminalPOS);
            this.panel1.Controls.Add(this.btnConfiguracoes);
            this.panel1.Controls.Add(this.btnCartoes);
            this.panel1.Controls.Add(this.btnTransacoes);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 859);
            this.panel1.TabIndex = 0;
            // 
            // labelUsuarioLogado
            // 
            this.labelUsuarioLogado.AutoSize = true;
            this.labelUsuarioLogado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.labelUsuarioLogado.Location = new System.Drawing.Point(31, 782);
            this.labelUsuarioLogado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsuarioLogado.Name = "labelUsuarioLogado";
            this.labelUsuarioLogado.Size = new System.Drawing.Size(183, 23);
            this.labelUsuarioLogado.TabIndex = 7;
            this.labelUsuarioLogado.Text = "DESENVOLVEDOR";
            // 
            // btnTerminalPOS
            // 
            this.btnTerminalPOS.BackColor = System.Drawing.Color.White;
            this.btnTerminalPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTerminalPOS.FlatAppearance.BorderSize = 0;
            this.btnTerminalPOS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnTerminalPOS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnTerminalPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminalPOS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminalPOS.Image = global::DigiBank.Properties.Resources.botao_movel;
            this.btnTerminalPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminalPOS.Location = new System.Drawing.Point(31, 343);
            this.btnTerminalPOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTerminalPOS.Name = "btnTerminalPOS";
            this.btnTerminalPOS.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnTerminalPOS.Size = new System.Drawing.Size(293, 74);
            this.btnTerminalPOS.TabIndex = 6;
            this.btnTerminalPOS.Text = "   Terminal POS";
            this.btnTerminalPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminalPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTerminalPOS.UseVisualStyleBackColor = false;
            this.btnTerminalPOS.Click += new System.EventHandler(this.btnTerminalPOS_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.White;
            this.btnConfiguracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnConfiguracoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.Image = global::DigiBank.Properties.Resources.definicoes;
            this.btnConfiguracoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.Location = new System.Drawing.Point(31, 425);
            this.btnConfiguracoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnConfiguracoes.Size = new System.Drawing.Size(293, 74);
            this.btnConfiguracoes.TabIndex = 5;
            this.btnConfiguracoes.Text = "   Configurações";
            this.btnConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracoes.UseVisualStyleBackColor = false;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnCartoes
            // 
            this.btnCartoes.BackColor = System.Drawing.Color.White;
            this.btnCartoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCartoes.FlatAppearance.BorderSize = 0;
            this.btnCartoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnCartoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnCartoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartoes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartoes.Image = global::DigiBank.Properties.Resources.cartao_de_credito;
            this.btnCartoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartoes.Location = new System.Drawing.Point(31, 274);
            this.btnCartoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCartoes.Name = "btnCartoes";
            this.btnCartoes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCartoes.Size = new System.Drawing.Size(293, 74);
            this.btnCartoes.TabIndex = 3;
            this.btnCartoes.Text = "   Cartões";
            this.btnCartoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCartoes.UseVisualStyleBackColor = false;
            this.btnCartoes.Click += new System.EventHandler(this.btnCartoes_Click);
            // 
            // btnTransacoes
            // 
            this.btnTransacoes.BackColor = System.Drawing.Color.White;
            this.btnTransacoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTransacoes.FlatAppearance.BorderSize = 0;
            this.btnTransacoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnTransacoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnTransacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransacoes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransacoes.Image = global::DigiBank.Properties.Resources.tempo_passado;
            this.btnTransacoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransacoes.Location = new System.Drawing.Point(31, 206);
            this.btnTransacoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTransacoes.Name = "btnTransacoes";
            this.btnTransacoes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnTransacoes.Size = new System.Drawing.Size(293, 74);
            this.btnTransacoes.TabIndex = 2;
            this.btnTransacoes.Text = "   Transações";
            this.btnTransacoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransacoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransacoes.UseVisualStyleBackColor = false;
            this.btnTransacoes.Click += new System.EventHandler(this.btnTransacoes_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Image = global::DigiBank.Properties.Resources.casa__2_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(31, 137);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(293, 74);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::DigiBank.Properties.Resources.logoooDigibank;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // painelPrincipal
            // 
            this.painelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPrincipal.Location = new System.Drawing.Point(347, 0);
            this.painelPrincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.painelPrincipal.Name = "painelPrincipal";
            this.painelPrincipal.Size = new System.Drawing.Size(957, 859);
            this.painelPrincipal.TabIndex = 1;
            this.painelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.painelPrincipal_Paint);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1304, 859);
            this.Controls.Add(this.painelPrincipal);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1319, 896);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCartoes;
        private System.Windows.Forms.Button btnTransacoes;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnTerminalPOS;
        private System.Windows.Forms.Panel painelPrincipal;
        private System.Windows.Forms.Label labelUsuarioLogado;
    }
}

