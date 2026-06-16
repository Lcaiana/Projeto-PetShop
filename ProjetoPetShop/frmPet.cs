using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPetShop
{
    public partial class frmPet : Form
    {
        clsConexao Conexao = new clsConexao();
        StringBuilder ComandSql = new StringBuilder();
        DataSet DataSet;
        DataTable DataTable;
        MySqlDataReader DataReader;

        public frmPet()
        {
            InitializeComponent();
        }

        private void frmPet_Load(object sender, EventArgs e)
        {
            ChamarGrid();

            cbGenero.Items.Add("Macho");
            cbGenero.Items.Add("Femea");
        }

        private void ChamarGrid()
        {
            Conexao.StrSql = "SELECT * FROM pet";
            DataSet = Conexao.RetornarDataSet();

            DataTable = DataSet.Tables[0];
            gridPet.DataSource = DataTable;

            if (gridPet.Columns["Foto_pet"] != null)
            {
                gridPet.Columns["Foto_pet"].Visible = false;
            }
        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtCpfTutor.Clear();
            txtNome.Clear();
            txtEspecie.Clear();
            txtRaca.Clear();

            cbGenero.SelectedIndex = -1;

            dtpPet.Value = DateTime.Now;

            pbFotoPet.Image = null;
            pbFotoPet.ImageLocation = null;

            txtCpfTutor.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //verifica se o usuário selecionou uma foto
            if (string.IsNullOrEmpty(pbFotoPet.ImageLocation))
            {
                MessageBox.Show("Por favor, selecione uma foto para o pet antes de cadastrar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imagemByte = File.ReadAllBytes(pbFotoPet.ImageLocation);

            // Validação para verificar se o CPF do Tutor existe
            string queryValidar = "SELECT COUNT(*) FROM tutor WHERE CPF_tutor = @CPF_validar";
            MySqlCommand cmdValidar = new MySqlCommand(queryValidar, Conexao.comand.Connection); // Certifique-se de usar a propriedade correta de sua conexão ativa
            cmdValidar.Parameters.AddWithValue("@CPF_validar", txtCpfTutor.Text.Trim());

            try
            {
                // Abre a conexão caso esteja fechada
                if (Conexao.comand.Connection.State != ConnectionState.Open)
                    Conexao.comand.Connection.Open();

                long quantidade = Convert.ToInt64(cmdValidar.ExecuteScalar());

                if (quantidade == 0)
                {
                    MessageBox.Show("Atenção: O CPF do tutor informado não existe no sistema! Cadastre o tutor primeiro.", "Tutor não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Para a execução e não deixa cadastrar o pet
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao validar tutor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                // Fecha a conexão temporária para não travar o banco
                if (Conexao.comand.Connection.State == ConnectionState.Open)
                    Conexao.comand.Connection.Close();
            }

            //1) Limpa o StringBuilder e monta o INSERT (repare que não colocamos a coluna do código auto increment)
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("INSERT INTO pet");
            ComandSql.Append(" (CPF_tutor, Nome_pet, Especie_pet, Nasc_pet, Genero_pet, Raca_pet, Foto_pet) ");
            ComandSql.Append("Values");
            ComandSql.Append("(@CPF_tutor, @Nome_pet, @Especie_pet, @Nasc_pet, @Genero_pet, @Raca_pet, @Foto_pet)");

            //2)Limpa os parâmetros anteriores e adiciona os novos com os dados da tela Pets
            Conexao.comand.Parameters.Clear();

            //Linka o CPF do tutor para ir pra tela dos pets
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCpfTutor.Text);

            //dá valor para os itens/parâmetros/dados da tabela
            Conexao.comand.Parameters.AddWithValue("@Nome_pet", txtNome.Text);
            Conexao.comand.Parameters.AddWithValue("@Especie_pet", txtEspecie.Text);
            Conexao.comand.Parameters.AddWithValue("@Raca_pet", txtRaca.Text);
            //passa o valor no formato de data direto do DateTimePicker
            Conexao.comand.Parameters.AddWithValue("@Nasc_pet", dtpPet.Value.Date);
            //passa o valor selecionado no ComboBox
            Conexao.comand.Parameters.AddWithValue("@Genero_pet", cbGenero.SelectedItem?.ToString()??"Não Informado");
            Conexao.comand.Parameters.AddWithValue("@Foto_pet", imagemByte);

            //3) Envia o comando para a classe de conexão de executar
            Conexao.StrSql = ComandSql.ToString();

            try
            {
                if (Conexao.ExecutarComando() > 0)
                {
                    MessageBox.Show("Pet cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    pbFotoPet.ImageLocation = null;
                    pbFotoPet.Image = null;

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

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            // 1) Limpa qualquer parâmetro de consultas anteriores
            Conexao.comand.Parameters.Clear();

            // 2) Converte o código da tela para número inteiro antes de enviar
            if (int.TryParse(txtCodigo.Text.Trim(), out int codigoPet))
            {
                Conexao.comand.Parameters.AddWithValue("@Codigo_pet", codigoPet);
            }
            else
            {
                MessageBox.Show("Selecione um pet válido antes de tentar alterar!");
                return;
            }

            // 3) Adiciona os demais parâmetros limpando espaços vazios das pontas
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCpfTutor.Text.Trim());
            Conexao.comand.Parameters.AddWithValue("@Nome_pet", txtNome.Text.Trim());
            Conexao.comand.Parameters.AddWithValue("@Especie_pet", txtEspecie.Text.Trim());
            Conexao.comand.Parameters.AddWithValue("@Raca_pet", txtRaca.Text.Trim());
            Conexao.comand.Parameters.AddWithValue("@Nasc_pet", dtpPet.Value.Date);
            Conexao.comand.Parameters.AddWithValue("@Genero_pet", cbGenero.SelectedItem?.ToString() ?? "Não Informado");

            if (!string.IsNullOrEmpty(pbFotoPet.ImageLocation))
            {
                byte[] imagemByte = File.ReadAllBytes(pbFotoPet.ImageLocation);
                Conexao.comand.Parameters.AddWithValue("@Foto_pet", imagemByte);
            }
            else if (pbFotoPet.Image != null)
            {
                // Se a foto já veio da pesquisa (banco) e não mudou, pegamos ela mesma
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFotoPet.Image.Save(ms, pbFotoPet.Image.RawFormat);
                    Conexao.comand.Parameters.AddWithValue("@Foto_pet", ms.ToArray());
                }
            }
            else
            {
                // Se não tem foto nenhuma na tela, envia vazio ou nulo
                Conexao.comand.Parameters.AddWithValue("@Foto_pet", DBNull.Value);
            }

            // 4) Monta a Query de forma limpa e visível por blocos
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("UPDATE pet SET ");
            ComandSql.Append("CPF_tutor = @CPF_tutor, ");
            ComandSql.Append("Nome_pet = @Nome_pet, ");
            ComandSql.Append("Especie_pet = @Especie_pet, ");
            ComandSql.Append("Nasc_pet = @Nasc_pet, ");
            ComandSql.Append("Genero_pet = @Genero_pet, ");
            ComandSql.Append("Raca_pet = @Raca_pet, "); // Atente-se ao espaço no final dessa linha
            ComandSql.Append("Foto_pet = @Foto_pet ");
            ComandSql.Append("WHERE Codigo_pet = @Codigo_pet");

            // 5) Transmite o comando completo para a propriedade de execução
            Conexao.StrSql = ComandSql.ToString();

            // 6) Executa a ação no banco de dados
            try
            {
                if (Conexao.ExecutarComando() > 0)
                {
                    MessageBox.Show("Pet alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    pbFotoPet.Image = null;
                    pbFotoPet.ImageLocation = null;

                    ChamarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao alterar pet! Verifique se os dados não são idênticos aos já salvos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridPet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //1)pega a linha que foi clicada
                DataGridViewRow linhaAtual = gridPet.Rows[e.RowIndex];
                //2)Pega o valor do CPF da linha clicada
                txtCodigo.Text = linhaAtual.Cells["Codigo_pet"].Value.ToString();
                //3) Executa automaticamente o evento de click do botão pesquisar
                btnPesquisar_Click(sender, e);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);
            ComandSql.Append("SELECT * FROM pet");

            // SE o código estiver preenchido, busca APENAS pelo código
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                ComandSql.Append(" WHERE Codigo_pet = @Codigo_pet");
            }
            // se o código estiver vazio mas o CPF tiver dados, busca pelo CPF
            else if (!string.IsNullOrEmpty(txtCpfTutor.Text))
            {
                ComandSql.Append(" WHERE CPF_tutor = @CPF_tutor");
            }
            // Se os dois estiverem vazios, não faz sentido buscar
            else
            {
                MessageBox.Show("Digite um Código ou um CPF para pesquisar!");
                return;
            }

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@Codigo_pet", txtCodigo.Text);
            Conexao.comand.Parameters.AddWithValue("@CPF_tutor", txtCpfTutor.Text);

            Conexao.StrSql = ComandSql.ToString();
            DataReader = Conexao.RetornarDataReader();

            if (DataReader.Read())
            {
                txtCodigo.Text = DataReader["Codigo_pet"].ToString();
                txtCpfTutor.Text = DataReader["CPF_tutor"].ToString();
                txtNome.Text = DataReader["Nome_pet"].ToString();
                txtEspecie.Text = DataReader["Especie_pet"].ToString();
                txtRaca.Text = DataReader["Raca_pet"].ToString();
                if (DateTime.TryParse(DataReader["Nasc_pet"].ToString(), out DateTime dataNasc))
                {
                    dtpPet.Value = dataNasc;
                }
                else
                {
                    dtpPet.Value = DateTime.Now;
                }
                string genero = DataReader["Genero_pet"].ToString();
                cbGenero.SelectedItem = genero;

                if (DataReader["Foto_pet"] != DBNull.Value)
                {
                    try
                    {
                        // 1) Pega os bytes salvos no banco de dados
                        byte[] imagemByte = (byte[])DataReader["Foto_pet"];

                        if (imagemByte.Length > 0)
                        {
                            // 2) Cria o MemoryStream com os bytes da imagem
                            MemoryStream ms = new MemoryStream(imagemByte);

                            // 3) Cria uma cópia da imagem na memória para não depender do Stream aberto
                            Image imagemDoBanco = Image.FromStream(ms);
                            pbFotoPet.Image = new Bitmap(imagemDoBanco); // Cria um novo mapa de bits limpo

                            pbFotoPet.ImageLocation = null; // Limpa o caminho de arquivos antigos
                        }
                        else
                        {
                            pbFotoPet.Image = null;
                            pbFotoPet.ImageLocation = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Caso queira ver se deu algum erro na conversão
                        MessageBox.Show("Erro ao carregar a foto do pet: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pbFotoPet.Image = null;
                    }
                }
                else
                {
                    pbFotoPet.Image = null;
                    pbFotoPet.ImageLocation = null;
                }
            }
            else
            {
                MessageBox.Show("Pet não encontrado!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ComandSql.Remove(0, ComandSql.Length);

            ComandSql.Append("DELETE FROM pet WHERE Codigo_pet = @Codigo_pet");

            Conexao.comand.Parameters.Clear();
            Conexao.comand.Parameters.AddWithValue("@Codigo_pet", txtCodigo.Text);

            Conexao.StrSql = ComandSql.ToString();

            if (Conexao.ExecutarComando() > 0)
            {
                MessageBox.Show("Pet excluído com sucesso!");
                ChamarGrid();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao excluir pet!");
            }
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecionar Imagens";
            dialog.Filter = "Imagens|*.jpg;*.Jpeg;*.png;*.gif";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbFotoPet.ImageLocation = dialog.FileName;
            }
        }
    }
}
