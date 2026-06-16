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
    public partial class frmTutor : Form
    {
        clsConexao Conexao = new clsConexao();
        StringBuilder ComandSql = new StringBuilder();
        DataSet DataSet;
        DataTable DataTable;
        MySqlDataReader DataReader;

        public frmTutor()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("SELECT * FROM tutor");
            ComandSql.Append(" WHERE CPF_tutor = @CPF_tutor");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCPF.Text);

            Conexao.StrSql = ComandSql.ToString();
            DataReader = Conexao.RetornarDataReader();

            if (DataReader.Read())
            {
                txtNome.Text = DataReader["Nome_tutor"].ToString();
                txtCelular.Text = DataReader["Celular_tutor"].ToString();
                txtEmail.Text = DataReader["Email_tutor"].ToString();
                txtCPF.Text = DataReader["CPF_tutor"].ToString();
            }

            else 
            {
                MessageBox.Show("Tutor não encontrado!");
            }
        }
        private void ChamarGrid()
        {
          Conexao.StrSql = "SELECT * FROM tutor";
            DataSet = Conexao.RetornarDataSet();

            DataTable = DataSet.Tables[0];
            gridTutor.DataSource = DataTable;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtCelular.Clear();
            txtEmail.Clear();

            txtCPF.Focus();
        }
        private void frmTutor_Load(object sender, EventArgs e)
        {
            ChamarGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("INSERT INTO tutor");
            ComandSql.Append("(Nome_tutor, CPF_tutor, Celular_tutor, Email_tutor)");
            ComandSql.Append("VALUES");
            ComandSql.Append("(@Nome_tutor, @CPF_tutor, @Celular_tutor, @Email_tutor)");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@Nome_tutor", txtNome.Text);
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCPF.Text);
            Conexao.comand.Parameters.AddWithValue("@Celular_tutor", txtCelular.Text);
            Conexao.comand.Parameters.AddWithValue("@Email_tutor", txtEmail.Text);

            Conexao.StrSql = ComandSql.ToString();
            // Colocamos um try-catch aqui para capturar o erro do banco de dados
            try
            {
                if (Conexao.ExecutarComando() > 0)
                {
                    MessageBox.Show("Pet cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChamarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar o pet!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Se o erro for da Chave Estrangeira (Foreign Key) do MySQL
                if (ex.Message.Contains("foreign key constraint fails"))
                {
                    MessageBox.Show("Atenção: O CPF do tutor informado não existe no sistema!", "Tutor não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Qualquer outro erro inesperado do banco
                    MessageBox.Show("Ocorreu um erro no banco de dados: " + ex.Message, "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("DELETE FROM tutor WHERE CPF_tutor = @CPF_tutor");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCPF.Text);

            Conexao.StrSql = ComandSql.ToString();

            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Tutor excluído com sucesso!");
                ChamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao excluir tutor!");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("UPDATE tutor SET CPF_tutor = @CPF_tutor, Nome_tutor = @Nome_tutor, Celular_tutor = @Celular_tutor, Email_tutor = @Email_tutor WHERE CPF_tutor = @CPF_tutor ");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@Nome_tutor", txtNome.Text);
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCPF.Text);
            Conexao.comand.Parameters.AddWithValue("@Celular_tutor", txtCelular.Text);
            Conexao.comand.Parameters.AddWithValue("@Email_tutor", txtEmail.Text);

            Conexao.StrSql = ComandSql.ToString();

            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Tutor alterado com sucesso!");
                ChamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao alterar tutor!");
            }
        }

        private void gridTutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                //1)pega a linha que foi clicada
                DataGridViewRow linhaAtual = gridTutor.Rows[e.RowIndex];
                //2)Pega o valor do CPF da linha clicada
                txtCPF.Text = linhaAtual.Cells["CPF_tutor"].Value.ToString();
                //3) Executa automaticamente o evento de click do botão pesquisar
                btnPesquisar_Click(sender, e);
            }
        }
    }
}
