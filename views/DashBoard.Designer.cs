namespace DigiBank.views
{
    partial class DashBoard
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
            this.btnNotificacao = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPoupanca = new System.Windows.Forms.Button();
            this.btnCorrente = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelMeusCartoes = new System.Windows.Forms.Panel();
            this.btnAdicionarCartao = new System.Windows.Forms.Button();
            this.panelListaCartoes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubtituloMeusCartoes = new System.Windows.Forms.Label();
            this.lblTituloMeusCartoes = new System.Windows.Forms.Label();
            this.panelTransacoes = new System.Windows.Forms.Panel();
            this.btnVerTodasTransacoes = new System.Windows.Forms.Button();
            this.panelListaTransacoes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubtituloTransacoes = new System.Windows.Forms.Label();
            this.lblTituloTransacoes = new System.Windows.Forms.Label();
            this.panelCartoes = new System.Windows.Forms.Panel();
            this.btnGerenciarCartoes = new System.Windows.Forms.Button();
            this.progressBarCartoes = new System.Windows.Forms.ProgressBar();
            this.lblCartoesAtivos = new System.Windows.Forms.Label();
            this.lblTotalCartoes = new System.Windows.Forms.Label();
            this.lblTituloCartoes = new System.Windows.Forms.Label();
            this.panelSaldo = new System.Windows.Forms.Panel();
            this.btnSacar = new System.Windows.Forms.Button();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblTipoConta = new System.Windows.Forms.Label();
            this.lblTituloSaldo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelMeusCartoes.SuspendLayout();
            this.panelTransacoes.SuspendLayout();
            this.panelCartoes.SuspendLayout();
            this.panelSaldo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNotificacao);
            this.panel1.Controls.Add(this.lblSubtitulo);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 100);
            this.panel1.TabIndex = 0;
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
            this.lblSubtitulo.Size = new System.Drawing.Size(150, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Bem-vindo de volta!";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(33, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnPoupanca);
            this.panel2.Controls.Add(this.btnCorrente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 98);
            this.panel2.TabIndex = 1;
            // 
            // btnPoupanca
            // 
            this.btnPoupanca.BackColor = System.Drawing.Color.White;
            this.btnPoupanca.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnPoupanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoupanca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoupanca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnPoupanca.Location = new System.Drawing.Point(200, 32);
            this.btnPoupanca.Name = "btnPoupanca";
            this.btnPoupanca.Size = new System.Drawing.Size(150, 40);
            this.btnPoupanca.TabIndex = 1;
            this.btnPoupanca.Text = "Conta Poupança";
            this.btnPoupanca.UseVisualStyleBackColor = false;
            this.btnPoupanca.Click += new System.EventHandler(this.btnPoupanca_Click);
            // 
            // btnCorrente
            // 
            this.btnCorrente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCorrente.FlatAppearance.BorderSize = 0;
            this.btnCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrente.ForeColor = System.Drawing.Color.White;
            this.btnCorrente.Location = new System.Drawing.Point(32, 32);
            this.btnCorrente.Name = "btnCorrente";
            this.btnCorrente.Size = new System.Drawing.Size(150, 40);
            this.btnCorrente.TabIndex = 0;
            this.btnCorrente.Text = "Conta Corrente";
            this.btnCorrente.UseVisualStyleBackColor = false;
            this.btnCorrente.Click += new System.EventHandler(this.btnCorrente_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panelCartoes);
            this.panel3.Controls.Add(this.panelSaldo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 198);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(950, 502);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panelMeusCartoes);
            this.panel4.Controls.Add(this.panelTransacoes);
            this.panel4.Location = new System.Drawing.Point(32, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(886, 260);
            this.panel4.TabIndex = 2;
            // 
            // panelMeusCartoes
            // 
            this.panelMeusCartoes.BackColor = System.Drawing.Color.White;
            this.panelMeusCartoes.Controls.Add(this.btnAdicionarCartao);
            this.panelMeusCartoes.Controls.Add(this.panelListaCartoes);
            this.panelMeusCartoes.Controls.Add(this.lblSubtituloMeusCartoes);
            this.panelMeusCartoes.Controls.Add(this.lblTituloMeusCartoes);
            this.panelMeusCartoes.Location = new System.Drawing.Point(456, 0);
            this.panelMeusCartoes.Name = "panelMeusCartoes";
            this.panelMeusCartoes.Size = new System.Drawing.Size(430, 245);
            this.panelMeusCartoes.TabIndex = 1;
            // 
            // btnAdicionarCartao
            // 
            this.btnAdicionarCartao.BackColor = System.Drawing.Color.White;
            this.btnAdicionarCartao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnAdicionarCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarCartao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCartao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnAdicionarCartao.Location = new System.Drawing.Point(24, 198);
            this.btnAdicionarCartao.Name = "btnAdicionarCartao";
            this.btnAdicionarCartao.Size = new System.Drawing.Size(381, 32);
            this.btnAdicionarCartao.TabIndex = 3;
            this.btnAdicionarCartao.Text = "Adicionar Cartão";
            this.btnAdicionarCartao.UseVisualStyleBackColor = false;
            // 
            // panelListaCartoes
            // 
            this.panelListaCartoes.AutoScroll = true;
            this.panelListaCartoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panelListaCartoes.Location = new System.Drawing.Point(24, 64);
            this.panelListaCartoes.Name = "panelListaCartoes";
            this.panelListaCartoes.Size = new System.Drawing.Size(381, 128);
            this.panelListaCartoes.TabIndex = 2;
            // 
            // lblSubtituloMeusCartoes
            // 
            this.lblSubtituloMeusCartoes.AutoSize = true;
            this.lblSubtituloMeusCartoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtituloMeusCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtituloMeusCartoes.Location = new System.Drawing.Point(24, 42);
            this.lblSubtituloMeusCartoes.Name = "lblSubtituloMeusCartoes";
            this.lblSubtituloMeusCartoes.Size = new System.Drawing.Size(216, 19);
            this.lblSubtituloMeusCartoes.TabIndex = 1;
            this.lblSubtituloMeusCartoes.Text = "Cartões vinculados às suas contas";
            // 
            // lblTituloMeusCartoes
            // 
            this.lblTituloMeusCartoes.AutoSize = true;
            this.lblTituloMeusCartoes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMeusCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloMeusCartoes.Location = new System.Drawing.Point(24, 17);
            this.lblTituloMeusCartoes.Name = "lblTituloMeusCartoes";
            this.lblTituloMeusCartoes.Size = new System.Drawing.Size(202, 25);
            this.lblTituloMeusCartoes.TabIndex = 0;
            this.lblTituloMeusCartoes.Text = "💳 Meus Cartões NFC";
            // 
            // panelTransacoes
            // 
            this.panelTransacoes.BackColor = System.Drawing.Color.White;
            this.panelTransacoes.Controls.Add(this.btnVerTodasTransacoes);
            this.panelTransacoes.Controls.Add(this.panelListaTransacoes);
            this.panelTransacoes.Controls.Add(this.lblSubtituloTransacoes);
            this.panelTransacoes.Controls.Add(this.lblTituloTransacoes);
            this.panelTransacoes.Location = new System.Drawing.Point(0, 0);
            this.panelTransacoes.Name = "panelTransacoes";
            this.panelTransacoes.Size = new System.Drawing.Size(430, 245);
            this.panelTransacoes.TabIndex = 0;
            // 
            // btnVerTodasTransacoes
            // 
            this.btnVerTodasTransacoes.BackColor = System.Drawing.Color.White;
            this.btnVerTodasTransacoes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnVerTodasTransacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodasTransacoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTodasTransacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnVerTodasTransacoes.Location = new System.Drawing.Point(24, 198);
            this.btnVerTodasTransacoes.Name = "btnVerTodasTransacoes";
            this.btnVerTodasTransacoes.Size = new System.Drawing.Size(381, 32);
            this.btnVerTodasTransacoes.TabIndex = 3;
            this.btnVerTodasTransacoes.Text = "Ver Todas as Transações";
            this.btnVerTodasTransacoes.UseVisualStyleBackColor = false;
            this.btnVerTodasTransacoes.Click += new System.EventHandler(this.btnVerTodasTransacoes_Click);
            // 
            // panelListaTransacoes
            // 
            this.panelListaTransacoes.AutoScroll = true;
            this.panelListaTransacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panelListaTransacoes.Location = new System.Drawing.Point(24, 64);
            this.panelListaTransacoes.Name = "panelListaTransacoes";
            this.panelListaTransacoes.Size = new System.Drawing.Size(381, 128);
            this.panelListaTransacoes.TabIndex = 2;
            // 
            // lblSubtituloTransacoes
            // 
            this.lblSubtituloTransacoes.AutoSize = true;
            this.lblSubtituloTransacoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtituloTransacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtituloTransacoes.Location = new System.Drawing.Point(24, 42);
            this.lblSubtituloTransacoes.Name = "lblSubtituloTransacoes";
            this.lblSubtituloTransacoes.Size = new System.Drawing.Size(212, 19);
            this.lblSubtituloTransacoes.TabIndex = 1;
            this.lblSubtituloTransacoes.Text = "Últimas movimentações da conta";
            // 
            // lblTituloTransacoes
            // 
            this.lblTituloTransacoes.AutoSize = true;
            this.lblTituloTransacoes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTransacoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloTransacoes.Location = new System.Drawing.Point(24, 17);
            this.lblTituloTransacoes.Name = "lblTituloTransacoes";
            this.lblTituloTransacoes.Size = new System.Drawing.Size(219, 25);
            this.lblTituloTransacoes.TabIndex = 0;
            this.lblTituloTransacoes.Text = "📊 Transações Recentes";
            // 
            // panelCartoes
            // 
            this.panelCartoes.BackColor = System.Drawing.Color.White;
            this.panelCartoes.Controls.Add(this.btnGerenciarCartoes);
            this.panelCartoes.Controls.Add(this.progressBarCartoes);
            this.panelCartoes.Controls.Add(this.lblCartoesAtivos);
            this.panelCartoes.Controls.Add(this.lblTotalCartoes);
            this.panelCartoes.Controls.Add(this.lblTituloCartoes);
            this.panelCartoes.Location = new System.Drawing.Point(626, 32);
            this.panelCartoes.Name = "panelCartoes";
            this.panelCartoes.Size = new System.Drawing.Size(296, 200);
            this.panelCartoes.TabIndex = 1;
            // 
            // btnGerenciarCartoes
            // 
            this.btnGerenciarCartoes.BackColor = System.Drawing.Color.White;
            this.btnGerenciarCartoes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnGerenciarCartoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarCartoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnGerenciarCartoes.Location = new System.Drawing.Point(24, 160);
            this.btnGerenciarCartoes.Name = "btnGerenciarCartoes";
            this.btnGerenciarCartoes.Size = new System.Drawing.Size(264, 32);
            this.btnGerenciarCartoes.TabIndex = 4;
            this.btnGerenciarCartoes.Text = "Gerenciar Cartões";
            this.btnGerenciarCartoes.UseVisualStyleBackColor = false;
            // 
            // progressBarCartoes
            // 
            this.progressBarCartoes.Location = new System.Drawing.Point(24, 140);
            this.progressBarCartoes.Name = "progressBarCartoes";
            this.progressBarCartoes.Size = new System.Drawing.Size(264, 8);
            this.progressBarCartoes.TabIndex = 3;
            // 
            // lblCartoesAtivos
            // 
            this.lblCartoesAtivos.AutoSize = true;
            this.lblCartoesAtivos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartoesAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCartoesAtivos.Location = new System.Drawing.Point(24, 90);
            this.lblCartoesAtivos.Name = "lblCartoesAtivos";
            this.lblCartoesAtivos.Size = new System.Drawing.Size(33, 37);
            this.lblCartoesAtivos.TabIndex = 2;
            this.lblCartoesAtivos.Text = "0";
            // 
            // lblTotalCartoes
            // 
            this.lblTotalCartoes.AutoSize = true;
            this.lblTotalCartoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTotalCartoes.Location = new System.Drawing.Point(24, 60);
            this.lblTotalCartoes.Name = "lblTotalCartoes";
            this.lblTotalCartoes.Size = new System.Drawing.Size(108, 21);
            this.lblTotalCartoes.TabIndex = 1;
            this.lblTotalCartoes.Text = "Cartões ativos";
            // 
            // lblTituloCartoes
            // 
            this.lblTituloCartoes.AutoSize = true;
            this.lblTituloCartoes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCartoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloCartoes.Location = new System.Drawing.Point(24, 24);
            this.lblTituloCartoes.Name = "lblTituloCartoes";
            this.lblTituloCartoes.Size = new System.Drawing.Size(149, 25);
            this.lblTituloCartoes.TabIndex = 0;
            this.lblTituloCartoes.Text = "💳 Cartões NFC";
            // 
            // panelSaldo
            // 
            this.panelSaldo.BackColor = System.Drawing.Color.White;
            this.panelSaldo.Controls.Add(this.btnSacar);
            this.panelSaldo.Controls.Add(this.btnDepositar);
            this.panelSaldo.Controls.Add(this.btnTransferir);
            this.panelSaldo.Controls.Add(this.lblSaldo);
            this.panelSaldo.Controls.Add(this.lblTipoConta);
            this.panelSaldo.Controls.Add(this.lblTituloSaldo);
            this.panelSaldo.Location = new System.Drawing.Point(32, 32);
            this.panelSaldo.Name = "panelSaldo";
            this.panelSaldo.Size = new System.Drawing.Size(570, 200);
            this.panelSaldo.TabIndex = 0;
            // 
            // btnSacar
            // 
            this.btnSacar.BackColor = System.Drawing.Color.White;
            this.btnSacar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnSacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnSacar.Location = new System.Drawing.Point(256, 160);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(100, 32);
            this.btnSacar.TabIndex = 5;
            this.btnSacar.Text = "Sacar";
            this.btnSacar.UseVisualStyleBackColor = false;
            // 
            // btnDepositar
            // 
            this.btnDepositar.BackColor = System.Drawing.Color.White;
            this.btnDepositar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnDepositar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepositar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepositar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnDepositar.Location = new System.Drawing.Point(140, 160);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(100, 32);
            this.btnDepositar.TabIndex = 4;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = false;
            // 
            // btnTransferir
            // 
            this.btnTransferir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTransferir.FlatAppearance.BorderSize = 0;
            this.btnTransferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferir.ForeColor = System.Drawing.Color.White;
            this.btnTransferir.Location = new System.Drawing.Point(24, 160);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(100, 32);
            this.btnTransferir.TabIndex = 3;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblSaldo.Location = new System.Drawing.Point(24, 90);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(177, 59);
            this.lblSaldo.TabIndex = 2;
            this.lblSaldo.Text = "R$ 0,00";
            // 
            // lblTipoConta
            // 
            this.lblTipoConta.AutoSize = true;
            this.lblTipoConta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoConta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTipoConta.Location = new System.Drawing.Point(24, 60);
            this.lblTipoConta.Name = "lblTipoConta";
            this.lblTipoConta.Size = new System.Drawing.Size(191, 21);
            this.lblTipoConta.TabIndex = 1;
            this.lblTipoConta.Text = "Conta Corrente • 12345-6";
            // 
            // lblTituloSaldo
            // 
            this.lblTituloSaldo.AutoSize = true;
            this.lblTituloSaldo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloSaldo.Location = new System.Drawing.Point(24, 24);
            this.lblTituloSaldo.Name = "lblTituloSaldo";
            this.lblTituloSaldo.Size = new System.Drawing.Size(141, 25);
            this.lblTituloSaldo.TabIndex = 0;
            this.lblTituloSaldo.Text = "💰 Saldo Atual";
            // 
            // DashBoard
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
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelMeusCartoes.ResumeLayout(false);
            this.panelMeusCartoes.PerformLayout();
            this.panelTransacoes.ResumeLayout(false);
            this.panelTransacoes.PerformLayout();
            this.panelCartoes.ResumeLayout(false);
            this.panelCartoes.PerformLayout();
            this.panelSaldo.ResumeLayout(false);
            this.panelSaldo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNotificacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPoupanca;
        private System.Windows.Forms.Button btnCorrente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelSaldo;
        private System.Windows.Forms.Label lblTituloSaldo;
        private System.Windows.Forms.Label lblTipoConta;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Button btnSacar;
        private System.Windows.Forms.Panel panelCartoes;
        private System.Windows.Forms.Label lblTituloCartoes;
        private System.Windows.Forms.Label lblTotalCartoes;
        private System.Windows.Forms.Label lblCartoesAtivos;
        private System.Windows.Forms.ProgressBar progressBarCartoes;
        private System.Windows.Forms.Button btnGerenciarCartoes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelTransacoes;
        private System.Windows.Forms.Label lblTituloTransacoes;
        private System.Windows.Forms.Label lblSubtituloTransacoes;
        private System.Windows.Forms.FlowLayoutPanel panelListaTransacoes;
        private System.Windows.Forms.Button btnVerTodasTransacoes;
        private System.Windows.Forms.Panel panelMeusCartoes;
        private System.Windows.Forms.Label lblTituloMeusCartoes;
        private System.Windows.Forms.Label lblSubtituloMeusCartoes;
        private System.Windows.Forms.FlowLayoutPanel panelListaCartoes;
        private System.Windows.Forms.Button btnAdicionarCartao;
    }
}