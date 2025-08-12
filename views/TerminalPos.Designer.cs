namespace DigiBank.views
{
    partial class TerminalPosForm
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
            this.panelPagamentosAprovados = new System.Windows.Forms.Panel();
            this.lblPagamentosAprovados = new System.Windows.Forms.Label();
            this.lblTituloPagamentosAprovados = new System.Windows.Forms.Label();
            this.panelTotalPagamentos = new System.Windows.Forms.Panel();
            this.lblTotalPagamentos = new System.Windows.Forms.Label();
            this.lblTituloTotalPagamentos = new System.Windows.Forms.Label();
            this.panelTerminaisAtivos = new System.Windows.Forms.Panel();
            this.lblTerminaisAtivos = new System.Windows.Forms.Label();
            this.lblTituloTerminaisAtivos = new System.Windows.Forms.Label();
            this.panelTotalTerminais = new System.Windows.Forms.Panel();
            this.lblTotalTerminais = new System.Windows.Forms.Label();
            this.lblTituloTotalTerminais = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTerminal = new System.Windows.Forms.Panel();
            this.panelStatusPagamento = new System.Windows.Forms.Panel();
            this.panelErro = new System.Windows.Forms.Panel();
            this.lblErro = new System.Windows.Forms.Label();
            this.panelSucesso = new System.Windows.Forms.Panel();
            this.lblValorAprovado = new System.Windows.Forms.Label();
            this.lblSucesso = new System.Windows.Forms.Label();
            this.panelProcessando = new System.Windows.Forms.Panel();
            this.lblProcessando = new System.Windows.Forms.Label();
            this.panelIdle = new System.Windows.Forms.Panel();
            this.btnSimularPagamento = new System.Windows.Forms.Button();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValorTransacao = new System.Windows.Forms.Label();
            this.lblTituloTerminal = new System.Windows.Forms.Label();
            this.lblUidCartao = new System.Windows.Forms.Label();
            this.txtUidCartao = new System.Windows.Forms.TextBox();
            this.panelPagamentosRecentes = new System.Windows.Forms.Panel();
            this.lblTituloPagamentosRecentes = new System.Windows.Forms.Label();
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPagamentosAprovados.SuspendLayout();
            this.panelTotalPagamentos.SuspendLayout();
            this.panelTerminaisAtivos.SuspendLayout();
            this.panelTotalTerminais.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTerminal.SuspendLayout();
            this.panelStatusPagamento.SuspendLayout();
            this.panelErro.SuspendLayout();
            this.panelSucesso.SuspendLayout();
            this.panelProcessando.SuspendLayout();
            this.panelIdle.SuspendLayout();
            this.panelPagamentosRecentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
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
            this.btnNotificacao.Click += new System.EventHandler(this.btnNotificacao_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(33, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(270, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Receba pagamentos de qualquer cartão NFC";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitulo.Location = new System.Drawing.Point(33, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Maquininha POS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel2.Controls.Add(this.panelPagamentosAprovados);
            this.panel2.Controls.Add(this.panelTotalPagamentos);
            this.panel2.Controls.Add(this.panelTerminaisAtivos);
            this.panel2.Controls.Add(this.panelTotalTerminais);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(32);
            this.panel2.Size = new System.Drawing.Size(950, 140);
            this.panel2.TabIndex = 1;
            // 
            // panelPagamentosAprovados
            // 
            this.panelPagamentosAprovados.BackColor = System.Drawing.Color.White;
            this.panelPagamentosAprovados.Controls.Add(this.lblPagamentosAprovados);
            this.panelPagamentosAprovados.Controls.Add(this.lblTituloPagamentosAprovados);
            this.panelPagamentosAprovados.Location = new System.Drawing.Point(626, 32);
            this.panelPagamentosAprovados.Name = "panelPagamentosAprovados";
            this.panelPagamentosAprovados.Size = new System.Drawing.Size(296, 76);
            this.panelPagamentosAprovados.TabIndex = 3;
            // 
            // lblPagamentosAprovados
            // 
            this.lblPagamentosAprovados.AutoSize = true;
            this.lblPagamentosAprovados.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamentosAprovados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblPagamentosAprovados.Location = new System.Drawing.Point(24, 32);
            this.lblPagamentosAprovados.Name = "lblPagamentosAprovados";
            this.lblPagamentosAprovados.Size = new System.Drawing.Size(33, 37);
            this.lblPagamentosAprovados.TabIndex = 1;
            this.lblPagamentosAprovados.Text = "3";
            // 
            // lblTituloPagamentosAprovados
            // 
            this.lblTituloPagamentosAprovados.AutoSize = true;
            this.lblTituloPagamentosAprovados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPagamentosAprovados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloPagamentosAprovados.Location = new System.Drawing.Point(24, 12);
            this.lblTituloPagamentosAprovados.Name = "lblTituloPagamentosAprovados";
            this.lblTituloPagamentosAprovados.Size = new System.Drawing.Size(155, 19);
            this.lblTituloPagamentosAprovados.TabIndex = 0;
            this.lblTituloPagamentosAprovados.Text = "Pagamentos Aprovados";
            // 
            // panelTotalPagamentos
            // 
            this.panelTotalPagamentos.BackColor = System.Drawing.Color.White;
            this.panelTotalPagamentos.Controls.Add(this.lblTotalPagamentos);
            this.panelTotalPagamentos.Controls.Add(this.lblTituloTotalPagamentos);
            this.panelTotalPagamentos.Location = new System.Drawing.Point(324, 32);
            this.panelTotalPagamentos.Name = "panelTotalPagamentos";
            this.panelTotalPagamentos.Size = new System.Drawing.Size(296, 76);
            this.panelTotalPagamentos.TabIndex = 2;
            // 
            // lblTotalPagamentos
            // 
            this.lblTotalPagamentos.AutoSize = true;
            this.lblTotalPagamentos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTotalPagamentos.Location = new System.Drawing.Point(24, 32);
            this.lblTotalPagamentos.Name = "lblTotalPagamentos";
            this.lblTotalPagamentos.Size = new System.Drawing.Size(33, 37);
            this.lblTotalPagamentos.TabIndex = 1;
            this.lblTotalPagamentos.Text = "4";
            // 
            // lblTituloTotalPagamentos
            // 
            this.lblTituloTotalPagamentos.AutoSize = true;
            this.lblTituloTotalPagamentos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalPagamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTotalPagamentos.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTotalPagamentos.Name = "lblTituloTotalPagamentos";
            this.lblTituloTotalPagamentos.Size = new System.Drawing.Size(118, 19);
            this.lblTituloTotalPagamentos.TabIndex = 0;
            this.lblTituloTotalPagamentos.Text = "Total Pagamentos";
            // 
            // panelTerminaisAtivos
            // 
            this.panelTerminaisAtivos.BackColor = System.Drawing.Color.White;
            this.panelTerminaisAtivos.Controls.Add(this.lblTerminaisAtivos);
            this.panelTerminaisAtivos.Controls.Add(this.lblTituloTerminaisAtivos);
            this.panelTerminaisAtivos.Location = new System.Drawing.Point(22, 32);
            this.panelTerminaisAtivos.Name = "panelTerminaisAtivos";
            this.panelTerminaisAtivos.Size = new System.Drawing.Size(296, 76);
            this.panelTerminaisAtivos.TabIndex = 1;
            // 
            // lblTerminaisAtivos
            // 
            this.lblTerminaisAtivos.AutoSize = true;
            this.lblTerminaisAtivos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminaisAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTerminaisAtivos.Location = new System.Drawing.Point(24, 32);
            this.lblTerminaisAtivos.Name = "lblTerminaisAtivos";
            this.lblTerminaisAtivos.Size = new System.Drawing.Size(33, 37);
            this.lblTerminaisAtivos.TabIndex = 1;
            this.lblTerminaisAtivos.Text = "1";
            // 
            // lblTituloTerminaisAtivos
            // 
            this.lblTituloTerminaisAtivos.AutoSize = true;
            this.lblTituloTerminaisAtivos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTerminaisAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTerminaisAtivos.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTerminaisAtivos.Name = "lblTituloTerminaisAtivos";
            this.lblTituloTerminaisAtivos.Size = new System.Drawing.Size(108, 19);
            this.lblTituloTerminaisAtivos.TabIndex = 0;
            this.lblTituloTerminaisAtivos.Text = "Terminais Ativos";
            // 
            // panelTotalTerminais
            // 
            this.panelTotalTerminais.BackColor = System.Drawing.Color.White;
            this.panelTotalTerminais.Controls.Add(this.lblTotalTerminais);
            this.panelTotalTerminais.Controls.Add(this.lblTituloTotalTerminais);
            this.panelTotalTerminais.Location = new System.Drawing.Point(22, 32);
            this.panelTotalTerminais.Name = "panelTotalTerminais";
            this.panelTotalTerminais.Size = new System.Drawing.Size(296, 76);
            this.panelTotalTerminais.TabIndex = 0;
            // 
            // lblTotalTerminais
            // 
            this.lblTotalTerminais.AutoSize = true;
            this.lblTotalTerminais.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTerminais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTotalTerminais.Location = new System.Drawing.Point(24, 32);
            this.lblTotalTerminais.Name = "lblTotalTerminais";
            this.lblTotalTerminais.Size = new System.Drawing.Size(33, 37);
            this.lblTotalTerminais.TabIndex = 1;
            this.lblTotalTerminais.Text = "2";
            // 
            // lblTituloTotalTerminais
            // 
            this.lblTituloTotalTerminais.AutoSize = true;
            this.lblTituloTotalTerminais.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalTerminais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTituloTotalTerminais.Location = new System.Drawing.Point(24, 12);
            this.lblTituloTotalTerminais.Name = "lblTituloTotalTerminais";
            this.lblTituloTotalTerminais.Size = new System.Drawing.Size(99, 19);
            this.lblTituloTotalTerminais.TabIndex = 0;
            this.lblTituloTotalTerminais.Text = "Total Terminais";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.panelTerminal);
            this.panel3.Controls.Add(this.panelPagamentosRecentes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 240);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(32);
            this.panel3.Size = new System.Drawing.Size(950, 460);
            this.panel3.TabIndex = 2;
            // 
            // panelTerminal
            // 
            this.panelTerminal.BackColor = System.Drawing.Color.White;
            this.panelTerminal.Controls.Add(this.panelStatusPagamento);
            this.panelTerminal.Controls.Add(this.txtUidCartao);
            this.panelTerminal.Controls.Add(this.lblUidCartao);
            this.panelTerminal.Controls.Add(this.txtValor);
            this.panelTerminal.Controls.Add(this.lblValorTransacao);
            this.panelTerminal.Controls.Add(this.lblTituloTerminal);
            this.panelTerminal.Location = new System.Drawing.Point(32, 0);
            this.panelTerminal.Name = "panelTerminal";
            this.panelTerminal.Size = new System.Drawing.Size(400, 420);
            this.panelTerminal.TabIndex = 0;
            // 
            // panelStatusPagamento
            // 
            this.panelStatusPagamento.Controls.Add(this.panelErro);
            this.panelStatusPagamento.Controls.Add(this.panelSucesso);
            this.panelStatusPagamento.Controls.Add(this.panelProcessando);
            this.panelStatusPagamento.Controls.Add(this.panelIdle);
            this.panelStatusPagamento.Location = new System.Drawing.Point(24, 180);
            this.panelStatusPagamento.Name = "panelStatusPagamento";
            this.panelStatusPagamento.Size = new System.Drawing.Size(352, 280);
            this.panelStatusPagamento.TabIndex = 3;
            // 
            // panelErro
            // 
            this.panelErro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelErro.Controls.Add(this.lblErro);
            this.panelErro.Location = new System.Drawing.Point(0, 0);
            this.panelErro.Name = "panelErro";
            this.panelErro.Size = new System.Drawing.Size(352, 280);
            this.panelErro.TabIndex = 3;
            this.panelErro.Visible = false;
            // 
            // lblErro
            // 
            this.lblErro.AutoSize = true;
            this.lblErro.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblErro.Location = new System.Drawing.Point(100, 120);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(231, 25);
            this.lblErro.TabIndex = 0;
            this.lblErro.Text = "❌ Pagamento Recusado";
            // 
            // panelSucesso
            // 
            this.panelSucesso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.panelSucesso.Controls.Add(this.lblValorAprovado);
            this.panelSucesso.Controls.Add(this.lblSucesso);
            this.panelSucesso.Location = new System.Drawing.Point(0, 0);
            this.panelSucesso.Name = "panelSucesso";
            this.panelSucesso.Size = new System.Drawing.Size(352, 280);
            this.panelSucesso.TabIndex = 2;
            this.panelSucesso.Visible = false;
            // 
            // lblValorAprovado
            // 
            this.lblValorAprovado.AutoSize = true;
            this.lblValorAprovado.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAprovado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblValorAprovado.Location = new System.Drawing.Point(120, 160);
            this.lblValorAprovado.Name = "lblValorAprovado";
            this.lblValorAprovado.Size = new System.Drawing.Size(91, 30);
            this.lblValorAprovado.TabIndex = 1;
            this.lblValorAprovado.Text = "R$ 0,00";
            // 
            // lblSucesso
            // 
            this.lblSucesso.AutoSize = true;
            this.lblSucesso.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucesso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblSucesso.Location = new System.Drawing.Point(100, 120);
            this.lblSucesso.Name = "lblSucesso";
            this.lblSucesso.Size = new System.Drawing.Size(241, 25);
            this.lblSucesso.TabIndex = 0;
            this.lblSucesso.Text = "✅ Pagamento Aprovado!";
            // 
            // panelProcessando
            // 
            this.panelProcessando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.panelProcessando.Controls.Add(this.lblProcessando);
            this.panelProcessando.Location = new System.Drawing.Point(0, 0);
            this.panelProcessando.Name = "panelProcessando";
            this.panelProcessando.Size = new System.Drawing.Size(352, 280);
            this.panelProcessando.TabIndex = 1;
            this.panelProcessando.Visible = false;
            // 
            // lblProcessando
            // 
            this.lblProcessando.AutoSize = true;
            this.lblProcessando.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProcessando.Location = new System.Drawing.Point(80, 120);
            this.lblProcessando.Name = "lblProcessando";
            this.lblProcessando.Size = new System.Drawing.Size(274, 25);
            this.lblProcessando.TabIndex = 0;
            this.lblProcessando.Text = "⏳ Processando pagamento...";
            // 
            // panelIdle
            // 
            this.panelIdle.Controls.Add(this.btnSimularPagamento);
            this.panelIdle.Controls.Add(this.lblInstrucao);
            this.panelIdle.Location = new System.Drawing.Point(0, 0);
            this.panelIdle.Name = "panelIdle";
            this.panelIdle.Size = new System.Drawing.Size(352, 280);
            this.panelIdle.TabIndex = 0;
            // 
            // btnSimularPagamento
            // 
            this.btnSimularPagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSimularPagamento.FlatAppearance.BorderSize = 0;
            this.btnSimularPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimularPagamento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimularPagamento.ForeColor = System.Drawing.Color.White;
            this.btnSimularPagamento.Location = new System.Drawing.Point(24, 200);
            this.btnSimularPagamento.Name = "btnSimularPagamento";
            this.btnSimularPagamento.Size = new System.Drawing.Size(304, 40);
            this.btnSimularPagamento.TabIndex = 1;
            this.btnSimularPagamento.Text = "💳 Aproximar Cartão";
            this.btnSimularPagamento.UseVisualStyleBackColor = false;
            this.btnSimularPagamento.Click += new System.EventHandler(this.btnSimularPagamento_Click);
            // 
            // lblInstrucao
            // 
            this.lblInstrucao.AutoSize = true;
            this.lblInstrucao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInstrucao.Location = new System.Drawing.Point(80, 160);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(250, 21);
            this.lblInstrucao.TabIndex = 0;
            this.lblInstrucao.Text = "Digite valor e UID do cartão e clique para aproximar";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(24, 80);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(352, 32);
            this.txtValor.TabIndex = 2;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValorTransacao
            // 
            this.lblValorTransacao.AutoSize = true;
            this.lblValorTransacao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTransacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblValorTransacao.Location = new System.Drawing.Point(24, 60);
            this.lblValorTransacao.Name = "lblValorTransacao";
            this.lblValorTransacao.Size = new System.Drawing.Size(123, 19);
            this.lblValorTransacao.TabIndex = 1;
            this.lblValorTransacao.Text = "Valor da Transação";

            // 
            // lblUidCartao
            // 
            this.lblUidCartao.AutoSize = true;
            this.lblUidCartao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUidCartao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblUidCartao.Location = new System.Drawing.Point(24, 120);
            this.lblUidCartao.Name = "lblUidCartao";
            this.lblUidCartao.Size = new System.Drawing.Size(118, 19);
            this.lblUidCartao.TabIndex = 4;
            this.lblUidCartao.Text = "UID do Cartão NFC";

            // 
            // txtUidCartao
            // 
            this.txtUidCartao.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUidCartao.Location = new System.Drawing.Point(24, 140);
            this.txtUidCartao.Name = "txtUidCartao";
            this.txtUidCartao.Size = new System.Drawing.Size(352, 32);
            this.txtUidCartao.TabIndex = 5;
            // 
            // lblTituloTerminal
            // 
            this.lblTituloTerminal.AutoSize = true;
            this.lblTituloTerminal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTerminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloTerminal.Location = new System.Drawing.Point(24, 24);
            this.lblTituloTerminal.Name = "lblTituloTerminal";
            this.lblTituloTerminal.Size = new System.Drawing.Size(222, 25);
            this.lblTituloTerminal.TabIndex = 0;
            this.lblTituloTerminal.Text = "Maquininha de Cartão";
            // 
            // panelPagamentosRecentes
            // 
            this.panelPagamentosRecentes.BackColor = System.Drawing.Color.White;
            this.panelPagamentosRecentes.Controls.Add(this.lblTituloPagamentosRecentes);
            this.panelPagamentosRecentes.Controls.Add(this.dgvPagamentos);
            this.panelPagamentosRecentes.Location = new System.Drawing.Point(456, 0);
            this.panelPagamentosRecentes.Name = "panelPagamentosRecentes";
            this.panelPagamentosRecentes.Size = new System.Drawing.Size(462, 420);
            this.panelPagamentosRecentes.TabIndex = 2;
            // 
            // lblTituloPagamentosRecentes
            // 
            this.lblTituloPagamentosRecentes.AutoSize = true;
            this.lblTituloPagamentosRecentes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPagamentosRecentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTituloPagamentosRecentes.Location = new System.Drawing.Point(24, 24);
            this.lblTituloPagamentosRecentes.Name = "lblTituloPagamentosRecentes";
            this.lblTituloPagamentosRecentes.Size = new System.Drawing.Size(205, 25);
            this.lblTituloPagamentosRecentes.TabIndex = 1;
            this.lblTituloPagamentosRecentes.Text = "Pagamentos Recentes";
            // 
            // dgvPagamentos
            // 
            this.dgvPagamentos.AllowUserToAddRows = false;
            this.dgvPagamentos.AllowUserToDeleteRows = false;
            this.dgvPagamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPagamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagamentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvPagamentos.Location = new System.Drawing.Point(24, 60);
            this.dgvPagamentos.Name = "dgvPagamentos";
            this.dgvPagamentos.ReadOnly = true;
            this.dgvPagamentos.RowHeadersVisible = false;
            this.dgvPagamentos.RowTemplate.Height = 25;
            this.dgvPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagamentos.Size = new System.Drawing.Size(414, 340);
            this.dgvPagamentos.TabIndex = 0;
            // 
            // TerminalPosForm
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
            this.Name = "TerminalPosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal POS";
            this.Load += new System.EventHandler(this.TerminalPosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelPagamentosAprovados.ResumeLayout(false);
            this.panelPagamentosAprovados.PerformLayout();
            this.panelTotalPagamentos.ResumeLayout(false);
            this.panelTotalPagamentos.PerformLayout();
            this.panelTerminaisAtivos.ResumeLayout(false);
            this.panelTerminaisAtivos.PerformLayout();
            this.panelTotalTerminais.ResumeLayout(false);
            this.panelTotalTerminais.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelTerminal.ResumeLayout(false);
            this.panelTerminal.PerformLayout();
            this.panelStatusPagamento.ResumeLayout(false);
            this.panelErro.ResumeLayout(false);
            this.panelErro.PerformLayout();
            this.panelSucesso.ResumeLayout(false);
            this.panelSucesso.PerformLayout();
            this.panelProcessando.ResumeLayout(false);
            this.panelProcessando.PerformLayout();
            this.panelIdle.ResumeLayout(false);
            this.panelIdle.PerformLayout();
            this.panelPagamentosRecentes.ResumeLayout(false);
            this.panelPagamentosRecentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNotificacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTotalTerminais;
        private System.Windows.Forms.Label lblTituloTotalTerminais;
        private System.Windows.Forms.Label lblTotalTerminais;
        private System.Windows.Forms.Panel panelTerminaisAtivos;
        private System.Windows.Forms.Label lblTituloTerminaisAtivos;
        private System.Windows.Forms.Label lblTerminaisAtivos;
        private System.Windows.Forms.Panel panelTotalPagamentos;
        private System.Windows.Forms.Label lblTituloTotalPagamentos;
        private System.Windows.Forms.Label lblTotalPagamentos;
        private System.Windows.Forms.Panel panelPagamentosAprovados;
        private System.Windows.Forms.Label lblTituloPagamentosAprovados;
        private System.Windows.Forms.Label lblPagamentosAprovados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelTerminal;
        private System.Windows.Forms.Label lblTituloTerminal;
        private System.Windows.Forms.Label lblValorTransacao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblUidCartao;
        private System.Windows.Forms.TextBox txtUidCartao;
        private System.Windows.Forms.Panel panelStatusPagamento;
        private System.Windows.Forms.Panel panelIdle;
        private System.Windows.Forms.Label lblInstrucao;
        private System.Windows.Forms.Button btnSimularPagamento;
        private System.Windows.Forms.Panel panelProcessando;
        private System.Windows.Forms.Label lblProcessando;
        private System.Windows.Forms.Panel panelSucesso;
        private System.Windows.Forms.Label lblSucesso;
        private System.Windows.Forms.Label lblValorAprovado;
        private System.Windows.Forms.Panel panelErro;
        private System.Windows.Forms.Label lblErro;
        private System.Windows.Forms.Panel panelPagamentosRecentes;
        private System.Windows.Forms.Label lblTituloPagamentosRecentes;
        private System.Windows.Forms.DataGridView dgvPagamentos;
    }
}
