namespace DigiBank
{
    partial class Main
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
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.Panel();
            this.lblIniciais = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.Panel();
            this.lblIconeLogo = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnTransacoes = new System.Windows.Forms.Button();
            this.btnCartoes = new System.Windows.Forms.Button();
            this.btnTerminalPOS = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelLateral.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            this.picAvatar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.picLogo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.White;
            this.panelLateral.Controls.Add(this.panelUsuario);
            this.panelLateral.Controls.Add(this.panelLogo);
            this.panelLateral.Controls.Add(this.panelMenu);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(250, 700);
            this.panelLateral.TabIndex = 0;
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.White;
            this.panelUsuario.Controls.Add(this.lblCPF);
            this.panelUsuario.Controls.Add(this.lblNomeUsuario);
            this.panelUsuario.Controls.Add(this.picAvatar);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUsuario.Location = new System.Drawing.Point(0, 620);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(250, 80);
            this.panelUsuario.TabIndex = 2;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCPF.Location = new System.Drawing.Point(80, 40);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(108, 13);
            this.lblCPF.TabIndex = 2;
            this.lblCPF.Text = "CPF: 123.456.789-00";
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblNomeUsuario.Location = new System.Drawing.Point(80, 20);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(77, 19);
            this.lblNomeUsuario.TabIndex = 1;
            this.lblNomeUsuario.Text = "João Silva";
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.picAvatar.Controls.Add(this.lblIniciais);
            this.picAvatar.Location = new System.Drawing.Point(24, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(40, 40);
            this.picAvatar.TabIndex = 0;
            // 
            // lblIniciais
            // 
            this.lblIniciais.AutoSize = true;
            this.lblIniciais.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblIniciais.Location = new System.Drawing.Point(8, 10);
            this.lblIniciais.Name = "lblIniciais";
            this.lblIniciais.Size = new System.Drawing.Size(23, 19);
            this.lblIniciais.TabIndex = 0;
            this.lblIniciais.Text = "JS";
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Controls.Add(this.picLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 86);
            this.panelLogo.TabIndex = 1;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblLogo.Location = new System.Drawing.Point(80, 25);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(117, 32);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "DigiBank";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.picLogo.Controls.Add(this.lblIconeLogo);
            this.picLogo.Location = new System.Drawing.Point(24, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(40, 40);
            this.picLogo.TabIndex = 0;
            // 
            // lblIconeLogo
            // 
            this.lblIconeLogo.AutoSize = true;
            this.lblIconeLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconeLogo.ForeColor = System.Drawing.Color.White;
            this.lblIconeLogo.Location = new System.Drawing.Point(8, 8);
            this.lblIconeLogo.Name = "lblIconeLogo";
            this.lblIconeLogo.Size = new System.Drawing.Size(44, 30);
            this.lblIconeLogo.TabIndex = 0;
            this.lblIconeLogo.Text = "⚡";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.btnTransacoes);
            this.panelMenu.Controls.Add(this.btnCartoes);
            this.panelMenu.Controls.Add(this.btnTerminalPOS);
            this.panelMenu.Controls.Add(this.btnConfiguracoes);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 700);
            this.panelMenu.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDashboard.Location = new System.Drawing.Point(0, 92);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(250, 50);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "🏠 Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnTransacoes
            // 
            this.btnTransacoes.BackColor = System.Drawing.Color.White;
            this.btnTransacoes.FlatAppearance.BorderSize = 0;
            this.btnTransacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransacoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnTransacoes.Location = new System.Drawing.Point(0, 152);
            this.btnTransacoes.Name = "btnTransacoes";
            this.btnTransacoes.Size = new System.Drawing.Size(250, 50);
            this.btnTransacoes.TabIndex = 1;
            this.btnTransacoes.Text = "📊 Transações";
            this.btnTransacoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransacoes.UseVisualStyleBackColor = false;
            this.btnTransacoes.Click += new System.EventHandler(this.btnTransacoes_Click);
            // 
            // btnCartoes
            // 
            this.btnCartoes.BackColor = System.Drawing.Color.White;
            this.btnCartoes.FlatAppearance.BorderSize = 0;
            this.btnCartoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnCartoes.Location = new System.Drawing.Point(0, 212);
            this.btnCartoes.Name = "btnCartoes";
            this.btnCartoes.Size = new System.Drawing.Size(250, 50);
            this.btnCartoes.TabIndex = 2;
            this.btnCartoes.Text = "💳 Cartões NFC";
            this.btnCartoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartoes.UseVisualStyleBackColor = false;
            this.btnCartoes.Click += new System.EventHandler(this.btnCartoes_Click);
            // 
            // btnTerminalPOS
            // 
            this.btnTerminalPOS.BackColor = System.Drawing.Color.White;
            this.btnTerminalPOS.FlatAppearance.BorderSize = 0;
            this.btnTerminalPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminalPOS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminalPOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnTerminalPOS.Location = new System.Drawing.Point(0, 272);
            this.btnTerminalPOS.Name = "btnTerminalPOS";
            this.btnTerminalPOS.Size = new System.Drawing.Size(250, 50);
            this.btnTerminalPOS.TabIndex = 3;
            this.btnTerminalPOS.Text = "📱 Terminal POS";
            this.btnTerminalPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminalPOS.UseVisualStyleBackColor = false;
            this.btnTerminalPOS.Click += new System.EventHandler(this.btnTerminalPOS_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.White;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 332);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(250, 50);
            this.btnConfiguracoes.TabIndex = 4;
            this.btnConfiguracoes.Text = "⚙️ Configurações";
            this.btnConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracoes.UseVisualStyleBackColor = false;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(250, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(950, 700);
            this.panelPrincipal.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelLateral);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1216, 739);
            this.MinimumSize = new System.Drawing.Size(1216, 739);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DigiBank - Sistema Bancário";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.picAvatar.ResumeLayout(false);
            this.picAvatar.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.picLogo.ResumeLayout(false);
            this.picLogo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnTransacoes;
        private System.Windows.Forms.Button btnCartoes;
        private System.Windows.Forms.Button btnTerminalPOS;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel picLogo;
        private System.Windows.Forms.Label lblIconeLogo;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.Panel picAvatar;
        private System.Windows.Forms.Label lblIniciais;
    }
}

