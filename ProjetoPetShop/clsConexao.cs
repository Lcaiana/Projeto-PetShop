using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPetShop
{
    internal class clsConexao
    {
        MySqlConnection Conexao = new MySqlConnection();
        public MySqlCommand comand = new MySqlCommand();

        private string _StrSql;
        public string StrSql
        {
            get { return _StrSql; }
            set { _StrSql = value; }
        }

        private string _StrConexao = "datasource=localhost;username=root;password=;database=PetShop";
        
        private MySqlConnection AbrirBanco()
        {
            MySqlConnection Conexao = new MySqlConnection();
            Conexao.ConnectionString = _StrConexao;
            Conexao.Open();
            return Conexao;
        }

        private void FecharBanco(SqlConnection Conexao)
        {
            if(Conexao.State == ConnectionState.Open)
            {
                   Conexao.Close();
            }
        }

        public DataSet RetornarDataSet()
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            DataSet dataSet = new DataSet();

            try
            {
                Conexao = AbrirBanco();
                comand.CommandText = _StrSql;
                comand.CommandType = CommandType.Text;
                comand.Connection = Conexao;

                dataAdapter.SelectCommand = comand;
                dataAdapter.Fill(dataSet);
                return (dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Conexao.Close();
            }
        }

        public MySqlDataReader RetornarDataReader()
        {
            try
            {
                Conexao = AbrirBanco();
                comand.CommandText = _StrSql;
                comand.CommandType = CommandType.Text;
                comand.Connection = Conexao;

                return comand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecutarComando()
        {
            try 
            {
                Conexao = AbrirBanco();
                comand.CommandText = _StrSql;
                comand.CommandType = CommandType.Text;
                comand.Connection = Conexao;
                return comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message.ToString());
            }
            finally
                {
                    Conexao.Close();
            }
        }
    }
}
