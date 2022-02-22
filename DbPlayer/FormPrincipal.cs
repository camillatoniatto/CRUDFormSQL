using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbPlayer
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Player player = new Player();
            List<Player> players = player.listPlayers();
            dgvPlayer.DataSource = players;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Inserir(txtNome.Text, txtCidade.Text, txtEmail.Text, txtCelular.Text);
            MessageBox.Show("Cadastro realizado com sucesso!");
            List<Player> players = player.listPlayers();
            dgvPlayer.DataSource = players;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Player player = new Player();
            player.Localiza(id);
            txtNome.Text = player.nome;
            txtCidade.Text = player.cidade;
            txtEmail.Text = player.email;
            txtCelular.Text = player.celular;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Player player = new Player();
            player.Atualizar(id, txtNome.Text, txtCidade.Text, txtEmail.Text, txtCelular.Text);
            MessageBox.Show("Cadastro atualizado com sucesso!");
            List<Player> players = player.listPlayers();
            dgvPlayer.DataSource = players;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Player player = new Player();
            player.Excluir(id);
            MessageBox.Show("Cadastro excluido com sucesso!");
            List<Player> players = player.listPlayers();
            dgvPlayer.DataSource = players;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }
    }
}
