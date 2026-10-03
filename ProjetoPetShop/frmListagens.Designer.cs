namespace ProjetoPetShop
{
    partial class frmListagens
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
            this.cboOpcaoListagem = new System.Windows.Forms.ComboBox();
            this.cboSubFiltroPet = new System.Windows.Forms.ComboBox();
            this.txtEspecieFiltro = new System.Windows.Forms.TextBox();
            this.cboTipoServicoFiltro = new System.Windows.Forms.ComboBox();
            this.dtpDataServicoFiltro = new System.Windows.Forms.DateTimePicker();
            this.lblSubFiltroPet = new System.Windows.Forms.Label();
            this.lblFiltroEspecie = new System.Windows.Forms.Label();
            this.lblTipoServico = new System.Windows.Forms.Label();
            this.lblDataServico = new System.Windows.Forms.Label();
            this.gridListagem = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridListagem)).BeginInit();
            this.SuspendLayout();
            // 
            // cboOpcaoListagem
            // 
            this.cboOpcaoListagem.FormattingEnabled = true;
            this.cboOpcaoListagem.Items.AddRange(new object[] {
            "Tutores",
            "Pets",
            "Serviços",
            "Consultas"});
            this.cboOpcaoListagem.Location = new System.Drawing.Point(137, 34);
            this.cboOpcaoListagem.Name = "cboOpcaoListagem";
            this.cboOpcaoListagem.Size = new System.Drawing.Size(168, 21);
            this.cboOpcaoListagem.TabIndex = 0;
            this.cboOpcaoListagem.SelectedIndexChanged += new System.EventHandler(this.cboOpcaoListagem_SelectedIndexChanged);
            // 
            // cboSubFiltroPet
            // 
            this.cboSubFiltroPet.FormattingEnabled = true;
            this.cboSubFiltroPet.Items.AddRange(new object[] {
            "Ordem Nasc",
            "Geral",
            "Espécie"});
            this.cboSubFiltroPet.Location = new System.Drawing.Point(508, 34);
            this.cboSubFiltroPet.Name = "cboSubFiltroPet";
            this.cboSubFiltroPet.Size = new System.Drawing.Size(168, 21);
            this.cboSubFiltroPet.TabIndex = 1;
            this.cboSubFiltroPet.SelectedIndexChanged += new System.EventHandler(this.cboSubFiltroPet_SelectedIndexChanged);
            // 
            // txtEspecieFiltro
            // 
            this.txtEspecieFiltro.Location = new System.Drawing.Point(508, 78);
            this.txtEspecieFiltro.Name = "txtEspecieFiltro";
            this.txtEspecieFiltro.Size = new System.Drawing.Size(168, 20);
            this.txtEspecieFiltro.TabIndex = 2;
            // 
            // cboTipoServicoFiltro
            // 
            this.cboTipoServicoFiltro.FormattingEnabled = true;
            this.cboTipoServicoFiltro.Items.AddRange(new object[] {
            "Banho",
            "Tosa"});
            this.cboTipoServicoFiltro.Location = new System.Drawing.Point(137, 114);
            this.cboTipoServicoFiltro.Name = "cboTipoServicoFiltro";
            this.cboTipoServicoFiltro.Size = new System.Drawing.Size(200, 21);
            this.cboTipoServicoFiltro.TabIndex = 3;
            // 
            // dtpDataServicoFiltro
            // 
            this.dtpDataServicoFiltro.Location = new System.Drawing.Point(137, 161);
            this.dtpDataServicoFiltro.Name = "dtpDataServicoFiltro";
            this.dtpDataServicoFiltro.Size = new System.Drawing.Size(200, 20);
            this.dtpDataServicoFiltro.TabIndex = 4;
            // 
            // lblSubFiltroPet
            // 
            this.lblSubFiltroPet.AutoSize = true;
            this.lblSubFiltroPet.Location = new System.Drawing.Point(361, 37);
            this.lblSubFiltroPet.Name = "lblSubFiltroPet";
            this.lblSubFiltroPet.Size = new System.Drawing.Size(141, 13);
            this.lblSubFiltroPet.TabIndex = 5;
            this.lblSubFiltroPet.Text = "Escolha uma opção de filtro:";
            // 
            // lblFiltroEspecie
            // 
            this.lblFiltroEspecie.AutoSize = true;
            this.lblFiltroEspecie.Location = new System.Drawing.Point(381, 81);
            this.lblFiltroEspecie.Name = "lblFiltroEspecie";
            this.lblFiltroEspecie.Size = new System.Drawing.Size(101, 13);
            this.lblFiltroEspecie.TabIndex = 6;
            this.lblFiltroEspecie.Text = "Digite uma Espécie:";
            // 
            // lblTipoServico
            // 
            this.lblTipoServico.AutoSize = true;
            this.lblTipoServico.Location = new System.Drawing.Point(2, 117);
            this.lblTipoServico.Name = "lblTipoServico";
            this.lblTipoServico.Size = new System.Drawing.Size(129, 13);
            this.lblTipoServico.TabIndex = 7;
            this.lblTipoServico.Text = "Escolha o tipo de serviço:";
            // 
            // lblDataServico
            // 
            this.lblDataServico.AutoSize = true;
            this.lblDataServico.Location = new System.Drawing.Point(2, 167);
            this.lblDataServico.Name = "lblDataServico";
            this.lblDataServico.Size = new System.Drawing.Size(133, 13);
            this.lblDataServico.TabIndex = 8;
            this.lblDataServico.Text = "Escolha a data do serviço:";
            // 
            // gridListagem
            // 
            this.gridListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListagem.Location = new System.Drawing.Point(12, 288);
            this.gridListagem.Name = "gridListagem";
            this.gridListagem.Size = new System.Drawing.Size(776, 150);
            this.gridListagem.TabIndex = 9;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(499, 182);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 58);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(497, 124);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 43);
            this.btnSair.TabIndex = 11;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmListagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.gridListagem);
            this.Controls.Add(this.lblDataServico);
            this.Controls.Add(this.lblTipoServico);
            this.Controls.Add(this.lblFiltroEspecie);
            this.Controls.Add(this.lblSubFiltroPet);
            this.Controls.Add(this.dtpDataServicoFiltro);
            this.Controls.Add(this.cboTipoServicoFiltro);
            this.Controls.Add(this.txtEspecieFiltro);
            this.Controls.Add(this.cboSubFiltroPet);
            this.Controls.Add(this.cboOpcaoListagem);
            this.Name = "frmListagens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListagens";
            this.Load += new System.EventHandler(this.frmListagens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboOpcaoListagem;
        private System.Windows.Forms.ComboBox cboSubFiltroPet;
        private System.Windows.Forms.TextBox txtEspecieFiltro;
        private System.Windows.Forms.ComboBox cboTipoServicoFiltro;
        private System.Windows.Forms.DateTimePicker dtpDataServicoFiltro;
        private System.Windows.Forms.Label lblSubFiltroPet;
        private System.Windows.Forms.Label lblFiltroEspecie;
        private System.Windows.Forms.Label lblTipoServico;
        private System.Windows.Forms.Label lblDataServico;
        private System.Windows.Forms.DataGridView gridListagem;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnSair;
    }
}