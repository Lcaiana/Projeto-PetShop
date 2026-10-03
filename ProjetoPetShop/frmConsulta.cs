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
    public partial class frmConsulta : Form
    {
        clsConexao Conexao = new clsConexao();
        StringBuilder ComandSql = new StringBuilder();
        DataSet DataSet;
        DataTable DataTable;
        MySqlDataReader DataReader;
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            chamarGrid();
        }
        public void chamarGrid()
        {
            Conexao.StrSql = "SELECT * FROM consulta";
            DataSet = Conexao.RetornarDataSet();

            DataTable = DataSet.Tables[0];
            gridConsulta.DataSource = DataTable;
        }

        public void LimparCampos()
        {
            txtCodigo.Clear();
            dtpConsulta.Value = DateTime.Now;
            txtPrescricao.Clear();

            txtCodigo.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("Insert into consulta ");
            ComandSql.Append("(codigo_pet, data_consulta, prescricao_consulta) ");
            ComandSql.Append("Values ");
            ComandSql.Append("(@codigo_pet, @data_consulta, @prescricao_consulta)");

            Conexao.comand.Parameters.Clear();

            Conexao.comand.Parameters.AddWithValue("@codigo_pet", Convert.ToInt32(txtCodigo.Text));
            Conexao.comand.Parameters.AddWithValue("@prescricao_consulta", txtPrescricao.Text);
            Conexao.comand.Parameters.AddWithValue("@data_consulta", dtpConsulta.Value.Date);

            Conexao.StrSql = ComandSql.ToString();
            try
            {
                if (Conexao.ExecutarComando() > 0)
                {
                    MessageBox.Show("Consulta cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chamarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar consulta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Erros ao cadastrar consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow linhaAtual = gridConsulta.Rows[e.RowIndex];
                txtCodigo.Text = linhaAtual.Cells["codigo_pet"].Value.ToString();

                ComandSql.Remove(0, ComandSql.Length);
                ComandSql.Append("SELECT * FROM consulta");
                ComandSql.Append(" WHERE codigo_pet = @codigo_pet");

                Conexao.comand.Parameters.Clear();
                Conexao.comand.Parameters.AddWithValue("@codigo_pet", txtCodigo.Text);

                Conexao.StrSql = ComandSql.ToString();
                DataReader = Conexao.RetornarDataReader();

                if (DataReader.Read())
                {
                    txtCodigo.Text = DataReader["codigo_pet"].ToString();
                    txtPrescricao.Text = DataReader["prescricao_consulta"].ToString();
                    if (DateTime.TryParse(DataReader["data_consulta"].ToString(), out DateTime dataConsulta))
                    {
                        dtpConsulta.Value = dataConsulta;
                    }
                    else
                    {
                        dtpConsulta.Value = DateTime.Now;
                    }
                }

                else
                {
                    MessageBox.Show("Consulta não encontrada!");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaAtual = gridConsulta.SelectedRows[0];

            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("DELETE FROM consulta WHERE id_consulta = @id_consulta");

            Conexao.comand.Parameters.Clear();
            //pega o id da linha selecionada no double click
            Conexao.comand.Parameters.AddWithValue("@id_consulta", Convert.ToInt32(linhaAtual.Cells["id_consulta"].Value));

            Conexao.StrSql = ComandSql.ToString();

            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Consulta excluída com sucesso!");
                chamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao excluir a consulta!");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaAtual = gridConsulta.SelectedRows[0];

            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("Update consulta SET codigo_pet = @codigo_pet, data_consulta = @data_consulta, prescricao_consulta = @prescricao_consulta WHERE id_consulta = @id_consulta ");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@id_consulta", Convert.ToInt32(linhaAtual.Cells["id_consulta"].Value));
            Conexao.comand.Parameters.AddWithValue("@codigo_pet", txtCodigo.Text);
            Conexao.comand.Parameters.AddWithValue("@prescricao_consulta", txtPrescricao.Text);
            Conexao.comand.Parameters.AddWithValue("@data_consulta", dtpConsulta.Value.Date);

            Conexao.StrSql = ComandSql.ToString();
            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Consulta alterada com sucesso!");
                chamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao alterar Consulta!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
