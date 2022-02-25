using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBarto
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            dtpDataN.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> clientes = cliente.listClientes();
            dgvCliente.DataSource = clientes;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Inserir(txtNome.Text, dtpDataN.Value.Date, txtEmail.Text, txtCelular.Text, txtCidade.Text);
            MessageBox.Show("Cliente cadastrado com sucesso!");
            List<Cliente> clientes = cliente.listClientes();
            dgvCliente.DataSource = clientes;
            txtNome.Text = "";
            dtpDataN.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Atualizar(id, txtNome.Text, dtpDataN.Value.Date, txtEmail.Text, txtCelular.Text, txtCidade.Text);
            MessageBox.Show("Cliente atualizado com sucesso!");
            List<Cliente> clientes = cliente.listClientes();
            dgvCliente.DataSource = clientes;
            txtNome.Text = "";
            dtpDataN.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Localiza(id);
            txtNome.Text = cliente.nome;
            dtpDataN.Value = cliente.datan;
            txtEmail.Text = cliente.email;
            txtCelular.Text = cliente.celular;
            txtCidade.Text = cliente.cidade;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Excluir(id);
            MessageBox.Show("Cliente excluido com sucesso!");
            List<Cliente> clientes = cliente.listClientes();
            dgvCliente.DataSource = clientes;
            txtNome.Text = "";
            dtpDataN.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }
    }
}
