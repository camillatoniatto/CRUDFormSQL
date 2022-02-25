using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDBarto
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public DateTime datan { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string cidade { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\CRUDBarto\DbCliente.mdf;Integrated Security=True");

        public List<Cliente> listClientes()
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM Cliente";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.datan = Convert.ToDateTime(dr["datan"]);
                c.email = dr["email"].ToString();
                c.celular = dr["celular"].ToString();
                c.cidade = dr["cidade"].ToString();
                li.Add(c);
            }
            return li;
        }

        public void Inserir(string nome, DateTime datan, string email, string celular, string cidade)
        {
            string dateString = datan.ToString("dd/MM/yyyy");
            string sql = "INSERT INTO Cliente(nome,datan,email,celular,cidade) VALUES ('" + nome + "','" + dateString + "','" + email + "','" + celular + "','" + cidade + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localiza(int id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = (int)dr["Id"];
                nome = dr["nome"].ToString();
                datan = Convert.ToDateTime(dr["datan"]);
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
                cidade = dr["cidade"].ToString();
            }
        }

        public void Atualizar(int id, string nome, DateTime datan, string email, string celular, string cidade)
        {
            string dateString = datan.ToString("MM-dd-yyyy");
            string sql = "UPDATE Cliente SET nome='" + nome + "', datan='" + dateString + "', email='" + email + "', celular='" + celular + "', cidade='" + cidade + "' WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM Cliente WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
