using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUDSQL2022
{
    public partial class FormCRUD : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\progamas\CRUDSQL2022\DBPessoa.mdf;Integrated Security=True");
        public FormCRUD()
        {
            InitializeComponent();
        }

        public void CarregaDBGV()
        {
            String str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\progamas\CRUDSQL2022\DBPessoa.mdf;Integrated Security=True";
            //comando query
            String query = "SELECT * FROM Pessoa";
            //conexão com string de conexão
            SqlConnection con = new SqlConnection(str);
            //realiza query em memoria
            SqlCommand cmd = new SqlCommand(query, con);
            //abre db
            con.Open();
            //diz que o comando do db é tipo texto
            cmd.CommandType = CommandType.Text;
            //adapta os registros da query de um array para tabela
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //nova tabela para jogar os dados no datagGidView
            DataTable pessoa = new DataTable();
            //joga na tabela
            da.Fill(pessoa);
            //coloca no banco de dados
            dbgvPessoa.DataSource = pessoa;
            //fecha banco
            con.Close();
        }

        private void FormCRUD_Load(object sender, EventArgs e)
        {
            CarregaDBGV();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Inserir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCPF.Text.Trim();
            cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
            cmd.Parameters.AddWithValue("@endereco", SqlDbType.NChar).Value = txtEndereco.Text.Trim();
            cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
            cmd.Parameters.AddWithValue("@email", SqlDbType.NChar).Value = txtEmail.Text.Trim();
            cmd.ExecuteNonQuery();
            CarregaDBGV();
            MessageBox.Show("Pessoa cadastrada com sucesso!", "Cadastro de Pessoas");
            txtCPF.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            con.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Atualizar", con);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCPF.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@endereco", SqlDbType.NChar).Value = txtEndereco.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.Parameters.AddWithValue("@email", SqlDbType.NChar).Value = txtEmail.Text.Trim();
                cmd.ExecuteNonQuery();
                CarregaDBGV();
                MessageBox.Show("Pessoa atualizada com sucesso!", "Cadastro de Pessoas");
                txtCPF.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Excluir", con);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCPF.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                CarregaDBGV();
                MessageBox.Show("Pessoa excluida com sucesso!", "Cadastro de Pessoas");
                txtCPF.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Localizar", con);
                cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCPF.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtCPF.Text = dr["cpf"].ToString();
                    txtNome.Text = dr["nome"].ToString();
                    txtEndereco.Text = dr["endereco"].ToString();
                    txtCelular.Text = dr["celular"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado!");
                }
            }
            finally
            {
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
        }
    }
}
