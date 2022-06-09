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

namespace Exercicio_MySql_Loja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conexao = "Server=localHost;Database=loja;Uid=root;Pwd=root;";

            MySqlConnection conexaoMySql = new MySqlConnection(conexao);

            string insert = $@"insert into produtos (nome, preço_kg)
            values ('{txtNome.Text}','{txtPreco.Text}')";

            try
            {
                conexaoMySql.Open();

                MySqlCommand cmd = new MySqlCommand(insert, conexaoMySql);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto Cadastrado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoMySql.Close();
            } 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
        }
    }
}
