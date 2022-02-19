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

namespace ResExec
{
    public partial class FormPrincipal : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\progamas\ResExec\DbFriend.mdf;Integrated Security=True");
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public void CarregaDGV()
        {
            String str = "SELECT * FROM Friend";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable friend = new DataTable();
            da.Fill(friend);
            dgvFriend.DataSource = friend;
            con.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CarregaDGV();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Inserir", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@data_n", SqlDbType.Date).Value = dtpDataN.Value.Date;
                cmd.Parameters.AddWithValue("@cidade", SqlDbType.NChar).Value = txtCidade.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cadastro realizado com sucesso!");
                txtCelular.Text = "";
                txtCidade.Text = "";
                txtNome.Text = "";
                this.dtpDataN.Value = DateTime.Now.Date;
                CarregaDGV();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Atualizar", con);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = txtID.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
                cmd.Parameters.AddWithValue("@data_n", SqlDbType.Date).Value = dtpDataN.Value.Date;
                cmd.Parameters.AddWithValue("@cidade", SqlDbType.NChar).Value = txtCidade.Text.Trim();
                cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edição realizado com sucesso!");
                txtCelular.Text = "";
                txtCidade.Text = "";
                txtNome.Text = "";
                this.dtpDataN.Value = DateTime.Now.Date;
                CarregaDGV();
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Excluir", con);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = txtID.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Excluido com sucesso!");
                txtCelular.Text = "";
                txtCidade.Text = "";
                txtNome.Text = "";
                this.dtpDataN.Value = DateTime.Now.Date;
                CarregaDGV();
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Localizar", con);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = txtID.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtNome.Text = rd["nome"].ToString();
                    txtCidade.Text = rd["cidade"].ToString();
                    txtCelular.Text = rd["cidade"].ToString();
                    dtpDataN.Value = Convert.ToDateTime(rd["data_n"]);
                }
                else
                {
                    MessageBox.Show("Registro não encontrado!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
            txtNome.Text = "";
            this.dtpDataN.Value = DateTime.Now.Date;
        }

        private void dgvFriend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvFriend.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                dtpDataN.Value = Convert.ToDateTime(row.Cells[2].Value);
                txtCidade.Text = row.Cells[3].Value.ToString();
                txtCelular.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
