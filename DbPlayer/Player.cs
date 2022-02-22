using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DbPlayer
{
    public class Player
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string  email { get; set; }
        public string celular { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\DbPlayer\DbPlayer.mdf;Integrated Security=True");
        
        public List<Player> listPlayers()
        {
            List<Player> li = new List<Player>();
            string sql = "SELECT * FROM Player";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Player p = new Player();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.cidade = dr["cidade"].ToString();
                p.email = dr["email"].ToString();
                p.celular = dr["celular"].ToString();
                li.Add(p);
            }
            return li;
        }

        public void Inserir(string nome, string cidade, string email, string celular)
        {
            string sql = "INSERT INTO Player(nome,cidade,email,celular) VALUES ('"+nome+ "','" + cidade + "','" + email + "','" + celular + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localiza(int id)
        {
            string sql = "SELECT * FROM Player WHERE Id = '"+id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
            }
        }

        public void Atualizar(int id, string nome, string cidade, string email, string celular)
        {
            string sql = "UPDATE Player SET nome='" + nome + "', cidade='" + cidade + "', email='" + email + "', celular='" + celular + "' WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM Player WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
