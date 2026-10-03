using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPetShop
{
    public partial class frmListagens : Form
    {
        clsConexao Conexao = new clsConexao();
        StringBuilder ComandSql = new StringBuilder();
        DataSet DataSet;
        DataTable DataTable;
        MySqlDataReader DataReader;

        public frmListagens()
        {
            InitializeComponent();
        }

        private void frmListagens_Load(object sender, EventArgs e)
        {
            //Filtros do Pet
            cboSubFiltroPet.Visible = false;
            txtEspecieFiltro.Visible = false;
            lblFiltroEspecie.Visible = false;
            lblSubFiltroPet.Visible = false;

            //Filtro do Serviço
            cboTipoServicoFiltro.Visible = false;
            dtpDataServicoFiltro.Visible = false;
            lblTipoServico.Visible = false;
            lblDataServico.Visible = false;
        }

        private void cboOpcaoListagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOpcaoListagem.Text == "Pets")
            {
                cboSubFiltroPet.Visible = true;
                txtEspecieFiltro.Visible = false;
                lblFiltroEspecie.Visible = false;
                lblSubFiltroPet.Visible = true;

                
                lblTipoServico.Visible = false;
                cboTipoServicoFiltro.Visible = false;
                lblDataServico.Visible = false;
                dtpDataServicoFiltro.Visible = false;
            }
            else if (cboOpcaoListagem.Text == "Serviços")
            {
                lblTipoServico.Visible = true;
                cboTipoServicoFiltro.Visible = true;
                lblDataServico.Visible = true;
                dtpDataServicoFiltro.Visible = true;

                
                cboSubFiltroPet.Visible = false;
                txtEspecieFiltro.Visible = false;
                lblFiltroEspecie.Visible = false;
                lblSubFiltroPet.Visible = false;
            }
            else
            {

                cboSubFiltroPet.Visible = false;
                txtEspecieFiltro.Visible = false;
                lblFiltroEspecie.Visible = false;
                lblSubFiltroPet.Visible = false;

                
                cboTipoServicoFiltro.Visible = false;
                dtpDataServicoFiltro.Visible = false;
                lblTipoServico.Visible = false;
                lblDataServico.Visible = false;
            }
        }

        private void cboSubFiltroPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSubFiltroPet.Text == "Espécie")
            {
                lblFiltroEspecie.Visible=true;
                txtEspecieFiltro.Visible=true;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            Conexao.comand.Parameters.Clear();

            if (cboOpcaoListagem.Text == "Tutores")
            {
                ComandSql.Append("SELECT CPF_tutor, Nome_tutor, Celular_tutor, Email_tutor FROM tutor ORDER BY Nome_tutor ASC");
            }

            else if (cboOpcaoListagem.Text == "Serviços")
            {

                if (string.IsNullOrEmpty(cboTipoServicoFiltro.Text))
                {
                    MessageBox.Show("Por favor, selecione um tipo de serviço para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ComandSql.Append(@"SELECT s.tipo_servico, s.data_servico, t.Nome_tutor, p.Nome_pet
                           FROM servicos s
                           INNER JOIN pet p ON s.codigo_pet = p.Codigo_pet
                           INNER JOIN tutor t ON p.CPF_tutor = t.CPF_tutor
                           WHERE s.tipo_servico = @tipo AND DATE(s.data_servico) = @data
                           ORDER BY t.Nome_tutor ASC, p.Nome_pet ASC");

                // Passa os valores selecionados na tela para os parâmetros do MySQL
                Conexao.comand.Parameters.AddWithValue("@tipo", cboTipoServicoFiltro.Text);
                Conexao.comand.Parameters.AddWithValue("@data", dtpDataServicoFiltro.Value.Date);
            }

            else if (cboOpcaoListagem.Text == "Consultas")
            {
                ComandSql.Append(@"SELECT c.codigo_pet, p.Nome_pet, t.Nome_tutor, c.data_consulta, c.prescricao_consulta
                           FROM consulta c
                           INNER JOIN pet p ON c.codigo_pet = p.Codigo_pet
                           INNER JOIN tutor t ON p.CPF_tutor = t.CPF_tutor
                           ORDER BY c.data_consulta DESC");
            }

            else if (cboOpcaoListagem.Text == "Pets")
            {
                if (cboSubFiltroPet.Text == "Ordem Nasc")
                {
                    ComandSql.Append(@"SELECT p.Nome_pet, p.Nasc_pet, t.Nome_tutor 
                               FROM pet p
                               INNER JOIN tutor t ON p.CPF_tutor = t.CPF_tutor
                               ORDER BY p.Nasc_pet ASC");
                }
                else if (cboSubFiltroPet.Text == "Geral")
                {
                    ComandSql.Append(@"SELECT t.Nome_tutor, t.Celular_tutor, p.Nome_pet, p.Genero_pet, p.Raca_pet 
                               FROM pet p
                               INNER JOIN tutor t ON p.CPF_tutor = t.CPF_tutor
                               ORDER BY t.Nome_tutor ASC");
                }
                else if (cboSubFiltroPet.Text == "Espécie")
                {
                    ComandSql.Append(@"SELECT p.Nome_pet, p.Especie_pet, p.Raca_pet, t.Nome_tutor 
                               FROM pet p
                               INNER JOIN tutor t ON p.CPF_tutor = t.CPF_tutor
                               WHERE p.Especie_pet = @especie
                               ORDER BY p.Nome_pet ASC");

                    // AJUSTE: Trocado txtEspecieFiltro por cboEspecieFiltro para bater com o seu design
                    Conexao.comand.Parameters.AddWithValue("@especie", txtEspecieFiltro.Text);
                }
            }

            // --- EXECUÇÃO E PREENCHIMENTO DO GRID ---
            Conexao.StrSql = ComandSql.ToString();

            try
            {
                // O método RetornarDataTable cuida de tudo: abre, preenche e fecha o banco sozinhos!
                gridListagem.DataSource = Conexao.RetornarDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher a listagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
