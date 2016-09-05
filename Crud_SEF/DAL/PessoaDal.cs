using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crud_SEF.Models;
using System.Data.SqlClient;

namespace Crud_SEF.DAL
{
    public class PessoaDal
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L7I6F7J;Initial Catalog=Base;Persist Security Info=True;User ID=sa;Password=anon");

        public List<Pessoa> list()
        {
            conn.Open();

            Pessoa ps;
            var listap = new List<Pessoa>();
            string select = "select id, nome, email, idade from Pessoas";
            SqlCommand comm_sel = new SqlCommand(select, conn);
            SqlDataReader dr = comm_sel.ExecuteReader();

            while (dr.Read())
            {
                ps = new Pessoa();
                ps.id = Convert.ToInt32(dr["id"]);
                ps.nome = dr["nome"].ToString();
                ps.email = dr["email"].ToString();
                ps.idade = Convert.ToInt32(dr["idade"]);
                listap.Add(ps);
            }

            conn.Close();

            return listap;           
        }

        public Pessoa getID(int id)
        {
            conn.Open();

            Pessoa ps = new Pessoa();
            string selectid = "select id, nome, email, idade from pessoas where id=" + id + "";
            SqlCommand comm_selid = new SqlCommand(selectid, conn);
            SqlDataReader dr = comm_selid.ExecuteReader();

            while (dr.Read())
            {   
                ps.id = Convert.ToInt32(dr["id"]);
                ps.nome = dr["nome"].ToString();
                ps.email = dr["email"].ToString();
                ps.idade = Convert.ToInt32(dr["idade"]);                
            }

            conn.Close();

            return ps;
        }

        public void create(Pessoa ps)
        {
            conn.Open();

            string insert = "insert into pessoas (nome, email, idade) values (@nome, @email, @idade)";
            SqlCommand comm_ins = new SqlCommand(insert, conn);

            comm_ins.Parameters.AddWithValue("@nome", ps.nome);
            comm_ins.Parameters.AddWithValue("@email", ps.email);
            comm_ins.Parameters.AddWithValue("@idade", ps.idade);

            comm_ins.ExecuteNonQuery();

            conn.Close();

        }

        public void edit(Pessoa ps)
        {
            conn.Open();

            string updade = "update pessoas set nome=@nome, email=@email, idade=@idade where id=@id";
            SqlCommand comm_up = new SqlCommand(updade, conn);

            comm_up.Parameters.AddWithValue("@id", ps.id);
            comm_up.Parameters.AddWithValue("@nome", ps.nome);
            comm_up.Parameters.AddWithValue("@email", ps.email);
            comm_up.Parameters.AddWithValue("@idade", ps.idade);

            comm_up.ExecuteNonQuery();

            conn.Close();
        }

        public void delete(int id)
        {
            conn.Open();

            string delete = "delete from pessoas where id=@id";
            SqlCommand comm_del = new SqlCommand(delete, conn);

            comm_del.Parameters.AddWithValue("@id", id);
            comm_del.ExecuteNonQuery();

            conn.Close();
        }



    }
}