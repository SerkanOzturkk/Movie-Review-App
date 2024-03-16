using Npgsql;
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

namespace Database_Project
{
    public partial class AdminAllStars : Form
    {
        public AdminAllStars()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=project; user ID=postgres; password=pass");

        private void AdminAllStars_Load(object sender, EventArgs e)
        {
            //Stars
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from actors", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbStar.DisplayMember = "name";
            cmbStar.ValueMember = "actor_id";
            cmbStar.DataSource = dt;
            connection.Close();

            //Movie
            connection.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from movies", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cmbMovie.DisplayMember = "title";
            cmbMovie.ValueMember = "movie_id";
            cmbMovie.DataSource = dt1;
            connection.Close();
        }

        private void btnAddtoMovie_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand command = new NpgsqlCommand("insert into movie_actor (movie_id,actor_id) values (@p1,@p2)", connection);
            NpgsqlCommand command = new NpgsqlCommand("call insert_movie_actor(@p1,@p2)", connection);
            connection.Open();
            command.Parameters.AddWithValue("@p1", Convert.ToInt16(cmbMovie.SelectedValue));
            command.Parameters.AddWithValue("@p2", Convert.ToInt16(cmbStar.SelectedValue));
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Oyuncu Filme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into actors (name,birth_date,country) values (@p1,@p2,@p3)", connection);
            connection.Open();
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", DateTime.Parse(mskBirthDate.Text));
            command.Parameters.AddWithValue("@p3", txtCountry.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Oyuncu Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Stars
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from actors", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbStar.DisplayMember = "name";
            cmbStar.ValueMember = "actor_id";
            cmbStar.DataSource = dt;
            connection.Close();

            //Movie
            connection.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from movies", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cmbMovie.DisplayMember = "title";
            cmbMovie.ValueMember = "movie_id";
            cmbMovie.DataSource = dt1;
            connection.Close();
        }
    }
}
