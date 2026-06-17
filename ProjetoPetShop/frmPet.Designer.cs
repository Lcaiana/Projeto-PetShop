namespace ProjetoPetShop
{
    partial class frmPet
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
            this.lblCod = new System.Windows.Forms.Label();
            this.lblCPFTutor = new System.Windows.Forms.Label();
            this.lblNasc = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblRaca = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEspecie = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCpfTutor = new System.Windows.Forms.TextBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.txtRaca = new System.Windows.Forms.TextBox();
            this.dtpPet = new System.Windows.Forms.DateTimePicker();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEspecie = new System.Windows.Forms.TextBox();
            this.gridPet = new System.Windows.Forms.DataGridView();
            this.pbFotoPet = new System.Windows.Forms.PictureBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAddFoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(47, 22);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(40, 13);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "Código";
            // 
            // lblCPFTutor
            // 
            this.lblCPFTutor.AutoSize = true;
            this.lblCPFTutor.Location = new System.Drawing.Point(237, 22);
            this.lblCPFTutor.Name = "lblCPFTutor";
            this.lblCPFTutor.Size = new System.Drawing.Size(55, 13);
            this.lblCPFTutor.TabIndex = 1;
            this.lblCPFTutor.Text = "CPF Tutor";
            // 
            // lblNasc
            // 
            this.lblNasc.AutoSize = true;
            this.lblNasc.Location = new System.Drawing.Point(24, 64);
            this.lblNasc.Name = "lblNasc";
            this.lblNasc.Size = new System.Drawing.Size(63, 13);
            this.lblNasc.TabIndex = 2;
            this.lblNasc.Text = "Nascimento";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(246, 56);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 3;
            this.lblGenero.Text = "Genero";
            // 
            // lblRaca
            // 
            this.lblRaca.AutoSize = true;
            this.lblRaca.Location = new System.Drawing.Point(255, 100);
            this.lblRaca.Name = "lblRaca";
            this.lblRaca.Size = new System.Drawing.Size(33, 13);
            this.lblRaca.TabIndex = 4;
            this.lblRaca.Text = "Raça";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(47, 100);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "Nome";
            // 
            // lblEspecie
            // 
            this.lblEspecie.AutoSize = true;
            this.lblEspecie.Location = new System.Drawing.Point(42, 131);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(45, 13);
            this.lblEspecie.TabIndex = 6;
            this.lblEspecie.Text = "Espécie";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(93, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(128, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // txtCpfTutor
            // 
            this.txtCpfTutor.Location = new System.Drawing.Point(298, 19);
            this.txtCpfTutor.Name = "txtCpfTutor";
            this.txtCpfTutor.Size = new System.Drawing.Size(128, 20);
            this.txtCpfTutor.TabIndex = 8;
            // 
            // cbGenero
            // 
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(298, 56);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(128, 21);
            this.cbGenero.TabIndex = 9;
            // 
            // txtRaca
            // 
            this.txtRaca.Location = new System.Drawing.Point(298, 97);
            this.txtRaca.Name = "txtRaca";
            this.txtRaca.Size = new System.Drawing.Size(128, 20);
            this.txtRaca.TabIndex = 10;
            // 
            // dtpPet
            // 
            this.dtpPet.Location = new System.Drawing.Point(93, 58);
            this.dtpPet.Name = "dtpPet";
            this.dtpPet.Size = new System.Drawing.Size(128, 20);
            this.dtpPet.TabIndex = 11;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(93, 93);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(128, 20);
            this.txtNome.TabIndex = 12;
            // 
            // txtEspecie
            // 
            this.txtEspecie.Location = new System.Drawing.Point(93, 128);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(128, 20);
            this.txtEspecie.TabIndex = 13;
            // 
            // gridPet
            // 
            this.gridPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPet.Location = new System.Drawing.Point(12, 301);
            this.gridPet.Name = "gridPet";
            this.gridPet.RowHeadersWidth = 62;
            this.gridPet.Size = new System.Drawing.Size(776, 137);
            this.gridPet.TabIndex = 14;
            this.gridPet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPet_CellDoubleClick);
            // 
            // pbFotoPet
            // 
            this.pbFotoPet.Location = new System.Drawing.Point(529, 12);
            this.pbFotoPet.Name = "pbFotoPet";
            this.pbFotoPet.Size = new System.Drawing.Size(120, 112);
            this.pbFotoPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoPet.TabIndex = 15;
            this.pbFotoPet.TabStop = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(93, 176);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(108, 50);
            this.btnCadastrar.TabIndex = 16;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(93, 232);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(108, 50);
            this.btnAlterar.TabIndex = 17;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(207, 176);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(108, 50);
            this.btnExcluir.TabIndex = 18;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(207, 232);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(108, 50);
            this.btnPesquisar.TabIndex = 19;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnAddFoto
            // 
            this.btnAddFoto.Location = new System.Drawing.Point(336, 200);
            this.btnAddFoto.Name = "btnAddFoto";
            this.btnAddFoto.Size = new System.Drawing.Size(108, 50);
            this.btnAddFoto.TabIndex = 20;
            this.btnAddFoto.Text = "Adicionar Foto";
            this.btnAddFoto.UseVisualStyleBackColor = true;
            this.btnAddFoto.Click += new System.EventHandler(this.btnAddFoto_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddFoto);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.pbFotoPet);
            this.Controls.Add(this.gridPet);
            this.Controls.Add(this.txtEspecie);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dtpPet);
            this.Controls.Add(this.txtRaca);
            this.Controls.Add(this.cbGenero);
            this.Controls.Add(this.txtCpfTutor);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblEspecie);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblRaca);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblNasc);
            this.Controls.Add(this.lblCPFTutor);
            this.Controls.Add(this.lblCod);
            this.Name = "frmPet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPet";
            this.Load += new System.EventHandler(this.frmPet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Label lblCPFTutor;
        private System.Windows.Forms.Label lblNasc;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblRaca;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEspecie;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtCpfTutor;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.TextBox txtRaca;
        private System.Windows.Forms.DateTimePicker dtpPet;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEspecie;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.PictureBox pbFotoPet;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnAddFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}