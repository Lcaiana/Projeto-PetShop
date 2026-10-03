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
    public partial class frmServiços : Form
    {
        clsConexao Conexao = new clsConexao();
        StringBuilder ComandSql = new StringBuilder();
        DataSet DataSet;
        DataTable DataTable;
        MySqlDataReader DataReader;
        public frmServiços()
        {
            InitializeComponent();
        }

        private void frmServiços_Load(object sender, EventArgs e)
        {
            ChamarGrid();

            cboTipoServico.Items.Add("Banho");
            cboTipoServico.Items.Add("Tosa");

            txtCodigo.Focus();
        }

        public void ChamarGrid()
        {
            Conexao.StrSql = "SELECT * FROM servicos";
            DataSet = Conexao.RetornarDataSet();

            DataTable = DataSet.Tables[0];
            gridServicos.DataSource = DataTable;
        }

        public void LimparCampos()
        {
            txtCodigo.Clear();
            cboTipoServico.SelectedIndex = -1;
            dtpData.Value = DateTime.Now;
            txtValor.Clear();

            txtCodigo.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cboTipoServico.SelectedIndex == -1 || string.IsNullOrEmpty(txtValor.Text) || string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("Insert into servicos ");
            ComandSql.Append("(codigo_pet, tipo_servico, valor_servico, data_servico) ");
            ComandSql.Append("Values ");
            ComandSql.Append("(@codigo_pet, @tipo_servico, @valor_servico, @data_servico)");

            Conexao.comand.Parameters.Clear();

            Conexao.comand.Parameters.AddWithValue("@codigo_pet", Convert.ToInt32(txtCodigo.Text));
            Conexao.comand.Parameters.AddWithValue("@tipo_servico", cboTipoServico.Text);
            Conexao.comand.Parameters.AddWithValue("@valor_servico", Convert.ToDecimal(txtValor.Text));
            Conexao.comand.Parameters.AddWithValue("@data_servico", dtpData.Value.Date);

            Conexao.StrSql = ComandSql.ToString();
            try
            {
                if (Conexao.ExecutarComando() > 0)
                {
                    MessageBox.Show("Serviço cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ChamarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar serviço!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Erros ao cadastrar serviço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridServicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow linhaAtual = gridServicos.Rows[e.RowIndex];
                txtCodigo.Text = linhaAtual.Cells["codigo_pet"].Value.ToString();

                ComandSql.Remove(0, ComandSql.Length);
                ComandSql.Append("SELECT * FROM servicos");
                ComandSql.Append(" WHERE codigo_pet = @codigo_pet");

                Conexao.comand.Parameters.Clear();
                Conexao.comand.Parameters.AddWithValue("@codigo_pet", txtCodigo.Text);

                Conexao.StrSql = ComandSql.ToString();
                DataReader = Conexao.RetornarDataReader();

                if (DataReader.Read())
                {
                    txtCodigo.Text = DataReader["codigo_pet"].ToString();
                    txtValor.Text = DataReader["valor_servico"].ToString();
                    if (DateTime.TryParse(DataReader["data_servico"].ToString(), out DateTime dataServico))
                    {
                        dtpData.Value = dataServico;
                    }
                    else
                    {
                        dtpData.Value = DateTime.Now;
                    }
                    string tipoServico = DataReader["tipo_servico"].ToString();
                    cboTipoServico.SelectedItem = tipoServico;
                }

                else
                {
                    MessageBox.Show("Serviço não encontrado!");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // PROTEÇÃO: Verifica se o usuário realmente selecionou uma linha no Grid
            if (gridServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, clique em uma linha da tabela abaixo antes de tentar alterar!",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow linhaAtual = gridServicos.SelectedRows[0];

            ComandSql.Remove(0,ComandSql.Length);
            ComandSql.Append("Update servicos SET codigo_pet = @codigo_pet, tipo_servico = @tipo_servico, valor_servico = @valor_servico, data_servico = @data_servico WHERE id_servico = @id_servico ");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@id_servico", Convert.ToInt32(linhaAtual.Cells["id_servico"].Value));
            Conexao.comand.Parameters.AddWithValue("@codigo_pet", txtCodigo.Text);
            Conexao.comand.Parameters.AddWithValue("@tipo_servico" , cboTipoServico.Text);
            Conexao.comand.Parameters.AddWithValue("@valor_servico", txtValor.Text);
            Conexao.comand.Parameters.AddWithValue("@data_servico", dtpData.Value.Date);

            Conexao.StrSql = ComandSql.ToString();
            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Serviço alterado com sucesso!");
                ChamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao alterar Serviço!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            // PROTEÇÃO: Verifica se o usuário realmente selecionou uma linha no Grid
            if (gridServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, clique em uma linha da tabela abaixo antes de tentar alterar!",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow linhaAtual = gridServicos.SelectedRows[0];

            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("DELETE FROM servicos WHERE id_servico = @id_servico");

            Conexao.comand.Parameters.Clear();
            //pega o id da linha selecionada no double click
            Conexao.comand.Parameters.AddWithValue("@id_servico", Convert.ToInt32(linhaAtual.Cells["id_servico"].Value));

            Conexao.StrSql = ComandSql.ToString();

            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Serviço excluído com sucesso!");
                ChamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao excluir Serviço!");
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